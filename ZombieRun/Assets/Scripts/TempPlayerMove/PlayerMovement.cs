using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
	public static PlayerMovement instance;

    public float MoveSmoothTime;
    public float GravityStrength;
    public float JumpStrength;
    public float WalkSpeed;
    public float RunSpeed;
	public static bool isTalk = false;
	public static GameObject whoTalk;
	public static Animator anim;
	public static bool isInteract;

    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;

    private Vector3 CurrentForecVelocity;

	[SerializeField] private GameObject LKey;
	[SerializeField] private GameObject RKey;
	[SerializeField] private GameObject FKey;

	private void Awake()
	{
		if(instance == null) PlayerMovement.instance = this;
		anim = GetComponent<Animator>();
	}

	void Start()
    {
        Controller = GetComponent<CharacterController>();
    }
    
    void PlayerInput()
    {
		//움직임
		Vector3 PlayerInput = new Vector3
		{
			x = Input.GetAxisRaw("Horizontal"),
			y = 0f,
			z = Input.GetAxisRaw("Vertical")
		};

		if (PlayerInput.magnitude > 1f)
			PlayerInput.Normalize();

		Vector3 MoveVector = transform.TransformDirection(PlayerInput);
		float CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;

		
		CurrentMoveVelocity = Vector3.SmoothDamp(
			CurrentMoveVelocity,
			MoveVector * CurrentSpeed,
			ref MoveDampVelocity,
			MoveSmoothTime);
		


        //점프
        Ray groundCheckRay = new Ray(transform.position, Vector3.down);

		if (Physics.Raycast(groundCheckRay, 1.1f))
		{
			CurrentForecVelocity.y = -2f;

			if (Input.GetKey(KeyCode.Space))
			{
				CurrentForecVelocity.y = JumpStrength;
			}
		}
		else
		{
			CurrentForecVelocity.y -= GravityStrength * Time.deltaTime;
		}

		//상호작용 버튼!
		if (Input.GetKeyDown(KeyCode.E)
			&& !isTalk
			&& !MsgDisp.flagDiaplay
			&& whoTalk != null)
		{
			StartCoroutine(StartTalk(whoTalk));
			isInteract = true;

        }
	}

	void PlayerMove()
	{
		
		if(!isTalk)
        {
			//앞뒤좌우
            Controller.Move(CurrentMoveVelocity * Time.deltaTime);
            //점프
            Controller.Move(CurrentForecVelocity * Time.deltaTime);
        }
		
	}

    void Update()
    {
		PlayerInput();
		PlayerMove();
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "LeftKey"
			|| other.tag == "RightKey"
			|| other.tag == "FinishKey")
		{
			MsgDisp.eventText = true;
			whoTalk = other.gameObject;
		}
	}

	

	

	IEnumerator Wait(GameObject crrntObj)
	{
		yield return new WaitForSeconds(3f);
		StartCoroutine(StartTalk(crrntObj));
	}

	public void startKTalk(GameObject gameObject)
	{
		MsgDisp.flagDiaplay = false;
		PlayerMovement.isTalk = false;
		MsgDisp.eventText = false;
		StartCoroutine(Wait(gameObject));
	}

	public IEnumerator StartTalk(GameObject objectTag)
	{
		MsgDisp.flagDiaplay = true; //화면띄울지 말지 정하는 변수
		isTalk = true; //플레이어 상호작용E키 남발 방지용
		MsgDisp.eventText = true;//상호작용 텍스트 올려주는 놈

		if (objectTag.tag == "LeftKey")
		{
			for (int i = LeftKey.leftKeyDialogueIndex; i < DialogueManager.Instance.itemsAllData.LeftKey.Length; i++)
			{
				LeftKey.leftKeyDialogueIndex++;
				Debug.Log(DialogueManager.Instance.itemsAllData.LeftKey[i].dialogue);
				
				MsgDisp.playerWhoTalk = DialogueManager.Instance.itemsAllData.LeftKey[i].name;
				MsgDisp.ShowMessage(DialogueManager.Instance.itemsAllData.LeftKey[i].dialogue);
				yield return new WaitForSeconds(2f);
				
				//대화창 띄우고 다음줄 점검 이번줄이 막줄이거나 다음줄이 branch가 다르거나
				if (LeftKey.leftKeyDialogueIndex == DialogueManager.Instance.itemsAllData.LeftKey.Length)
				{
					Debug.Log("막줄");
					break;
				}
				if (DialogueManager.Instance.itemsAllData.LeftKey[i + 1].branch
					!= DialogueManager.Instance.itemsAllData.LeftKey[i].branch)
				{
					Debug.Log("브랜치넘음");
					break;
				}
			}
			//대화 끝나고 아이템 먹을 때 함수 한 번 더 호출해서 대화창 띄우고 변수초기화하고 끝
			if (whoTalk != null)
			{
				whoTalk.SetActive(false);
				UIManager.instance.UpdateKeys(0);
				whoTalk = null;
			}
			else
			{
				MsgDisp.flagDiaplay = false;
				isTalk = false;
				MsgDisp.eventText = false;
			}
		}
		else if(objectTag.tag == "RightKey")
		{
			for (int i = RightKey.rightKeyDialogueIndex; i < DialogueManager.Instance.itemsAllData.RightKey.Length; i++)
			{
				RightKey.rightKeyDialogueIndex++;
				MsgDisp.playerWhoTalk = DialogueManager.Instance.itemsAllData.RightKey[i].name;
				MsgDisp.ShowMessage(DialogueManager.Instance.itemsAllData.RightKey[i].dialogue);
				yield return new WaitForSeconds(2f);

				//대화창 띄우고 다음줄 점검 이번줄이 막줄이거나 다음줄이 branch가 다르거나
				if (RightKey.rightKeyDialogueIndex == DialogueManager.Instance.itemsAllData.RightKey.Length)
				{
					Debug.Log("막줄");
					break;
				}
					
				if (DialogueManager.Instance.itemsAllData.RightKey[i + 1].branch
					!= DialogueManager.Instance.itemsAllData.RightKey[i].branch)
				{
					Debug.Log("브랜치넘음");
					break;
				}
					
			}
			//whoTalk.gameObject.SetActive(false);
			if (whoTalk != null)
			{
				whoTalk.SetActive(false);
				UIManager.instance.UpdateKeys(1);
				whoTalk = null;
			}
			else
			{
				MsgDisp.flagDiaplay = false;
				isTalk = false;
				MsgDisp.eventText = false;
			}

		}	
		else if(objectTag.tag == "FinishKey")
		{
			for (int i = FinishKey.finishKeyDialogueIndex; i < DialogueManager.Instance.itemsAllData.FinishKey.Length; i++)
			{
				FinishKey.finishKeyDialogueIndex++;
				MsgDisp.playerWhoTalk = DialogueManager.Instance.itemsAllData.FinishKey[i].name;
				MsgDisp.ShowMessage(DialogueManager.Instance.itemsAllData.FinishKey[i].dialogue);
				yield return new WaitForSeconds(2f);

				//대화창 띄우고 다음줄 점검 이번줄이 막줄이거나 다음줄이 branch가 다르거나
				if (FinishKey.finishKeyDialogueIndex == DialogueManager.Instance.itemsAllData.FinishKey.Length)
				{
					Debug.Log("막줄");
					break;
				}

				if (DialogueManager.Instance.itemsAllData.FinishKey[i + 1].branch
					!= DialogueManager.Instance.itemsAllData.FinishKey[i].branch)
				{
					Debug.Log("브랜치넘음");
					break;
				}

			}
			//whoTalk.gameObject.SetActive(false);
			if (whoTalk != null)
			{
				whoTalk.SetActive(false);
				UIManager.instance.UpdateKeys(2);
				whoTalk = null;
			}
			else
			{
				MsgDisp.flagDiaplay = false;
				isTalk = false;
				MsgDisp.eventText = false;
			}
		}


	}
}
