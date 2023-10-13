using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemNum; // GameManager.EItem에 해당하는 값

    private AudioSource KeyDrop;

    void Start()
    {
        KeyDrop = GetComponentInParent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            GameManager.instance.inventory[ItemNum] = true;   // 아이템 획득 처리
            
            // 해당 아이템에 대한 UI 업데이트
            UIManager.instance.UpdateKeys(ItemNum);

            if (ItemNum == (int)GameManager.EItem.Ring)
            {
                //팝업 생성
                UIManager.instance.ProposeEndingPopUp();
            }
            else
            {
                // 아이템 획득 시 소리 재생
                KeyDrop.Play();
            }

            gameObject.SetActive(false);                  // 아이템 비활성화
        }
    }
}