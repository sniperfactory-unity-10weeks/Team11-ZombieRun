using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int DoorNum; //GameManager.EItem ����

    public AudioClip door;

    private AudioSource doorhandle;

    void Start()
    {
       doorhandle = GetComponent<AudioSource>();
    }

    //todo: eŰ�� ���� ������ �������ּ���
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameManager.instance.inventory[DoorNum])
        {
            this.gameObject.SetActive(false);
        }
        //Ż�⿡ �������� ���
        if(DoorNum == (int)GameManager.EItem.ExitKey)
        {
            //���� ������ �̵��մϴ�.
        }

        doorhandle.Play();
    }
}
