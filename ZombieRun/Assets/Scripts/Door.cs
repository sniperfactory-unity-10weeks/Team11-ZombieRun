using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int DoorNum; //GameManager.EItem 참조

    public AudioClip door;

    private AudioSource doorhandle;

    void Start()
    {
       doorhandle = GetComponent<AudioSource>();
    }

    //todo: e키를 눌러 열도록 변경해주세요

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameManager.instance.inventory[DoorNum])
        {
            this.gameObject.SetActive(false);
        }
        //탈출에 성공했을 경우
        if(DoorNum == (int)GameManager.EItem.ExitKey)
        {
            //엔딩 씬으로 이동합니다.
            SceneManager.LoadScene("Scenes/Ending");
        }

        doorhandle.Play();
    }
}
