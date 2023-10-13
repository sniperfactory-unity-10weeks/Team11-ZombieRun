using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
     //����� �Է� ����

    //--Axis name--//
    string moveVerticalName = "Vertical";   //�յ� ������
    string moveHorizontalName = "Horizontal";   //�¿� ������
    string rotateXName = "Mouse X"; //���콺 ��Ŭ������ �¿� ȸ��
    //�� �Ҵ��� ���ο����� ����, private
    public float moveV { get; private set; }
    public float moveH { get; private set; }
    public float mouseLeft { get; private set; }
    public float rotateX { get; private set; }

    public AudioClip footstepSound; // 발소리를 위한 AudioClip
    private AudioSource audioSource; // AudioSource 컴포넌트

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //todo: ���� ���� ���°� �Ǹ� �Է� ���� ���� �ʴ´�
        //�����¿� �Է� ����
        moveV = Input.GetAxis(moveVerticalName);
        moveH = Input.GetAxis(moveHorizontalName);
        //������ �巡�׷� ī�޶� ȸ��
        if (Input.GetMouseButton(1))
        {
            rotateX = Input.GetAxis(rotateXName);
        }
        else
        {
            rotateX = 0;
        }
         if (moveV != 0 || moveH != 0)
        {
            PlayFootstepSound();
        }
    }

    void PlayFootstepSound()
    {
        if (audioSource != null && footstepSound != null)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(footstepSound);
            }
        }
    }
}
