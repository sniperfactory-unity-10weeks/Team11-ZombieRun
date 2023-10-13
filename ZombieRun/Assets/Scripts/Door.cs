using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int DoorNum; //GameManager.EItem ����

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
    }
}
