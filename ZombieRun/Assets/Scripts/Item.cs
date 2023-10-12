using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemNum; //GameManager.EItem 참조

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.inventory[ItemNum] = true;   //인벤토리에 추가
            gameObject.SetActive(false);                  //오브젝트 비활성화
            //todo: 해당 아이템 ui 활성화
        }
    }
}
