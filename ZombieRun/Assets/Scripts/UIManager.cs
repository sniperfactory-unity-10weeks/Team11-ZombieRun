using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }
            return m_instance;
        }
    }

    private static UIManager m_instance;

    // HP바
    [SerializeField] private Slider slider;

    // Key 오브젝트들
    [SerializeField] private GameObject KeyL;
    [SerializeField] private GameObject KeyL_Null;
    [SerializeField] private GameObject KeyR;
    [SerializeField] private GameObject KeyR_Null;
    [SerializeField] private GameObject KeyF;
    [SerializeField] private GameObject KeyF_Null;
    [SerializeField] private GameObject Ring;
    [SerializeField] private GameObject Ring_Null;

    // OpenDoor 팝업
    [SerializeField] private GameObject DoorPopUp;
    // Propose 팝업
    [SerializeField] private GameObject ProposePopUp;

    // 공격 받으면 화면 붉어짐
    [SerializeField] private GameObject AttackedEffectPanel;

    // 게임오버
    [SerializeField] private GameObject GameOverPanel;


    // HP바 설정, Player 스크립트에서 공격 받을 시 호출
    public void UpdateHealthBar(float damage)
    {
        slider.value -= damage;
        if (slider.value <= 0)
            slider.value = 0;
    }

    // Kye 관리, Player 스크립트나 열쇠 스크립트로부터 정보를 받아 호출
    public void UpdateKeys(int value)
    {
        switch (value)
        {
            case 0:
                KeyL_Null.SetActive(false);
                KeyL.SetActive(true);   // 열쇠 이미지 활성화
                break;
            case 1:
                KeyR_Null.SetActive(false);
                KeyR.SetActive(true);
                break;
            case 2:
                KeyF_Null.SetActive(false);
                KeyF.SetActive(true);
                break;
            case 3:
                Ring_Null.SetActive(false);
                Ring.SetActive(true);
                break;
        }
    }

    // 문 클릭 시 팝업 활성화
    public void DoorEndingPopUp()
    {
        DoorPopUp.SetActive(true);
    }
    // 팝업 yes, 엔딩 씬 로드
    public void OpenDoor()
    {
        SceneManager.LoadScene("Ending");
    }
    // 팝업 No, 팝업 지우기
    public void ClosePopUp()
    {
        DoorPopUp.SetActive(false);
    }

    // 반지 들고 문 클릭 시 팝업 활성화
    public void ProposeEndingPopUp()
    {
        ProposePopUp.SetActive(true);
    }
    // 팝업 yes, 히든 엔딩 씬 로드
    public void ProposeYes()
    {
        SceneManager.LoadScene("HiddenEnding");
    }
    // 팝업 No, 팝업 지우기
    public void ProposeNo()
    {
        ProposePopUp.SetActive(false);
    }




    // 공격 받을 시 화면 붉어짐
    public void Attacked()
    {
        StartCoroutine("AttackedEffect");
    }




    // 2초 동안 화면 붉어짐 효과 코루틴
    IEnumerator AttackedEffect()
    {
        AttackedEffectPanel.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        AttackedEffectPanel.SetActive(false);
    }

    
    // GameOver //
    // 게임 오버 패널 활성화
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
    // 재시작 버튼 클릭, 메인 Scene 로드
    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    // 나가기 버튼 클릭, 시작 Scene 로드
    public void Exit()
    {
        SceneManager.LoadScene("Start");
    }
}