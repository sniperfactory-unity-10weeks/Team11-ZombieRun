using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSet : MonoBehaviour
{

    public GameObject PlayerCam;
    public GameObject GameOverCam;

    void Start()
    {
        GameOverCam.SetActive(false);
        PlayerCam.SetActive(true);
    }

    //플레이어 사망시 활성화
    void OnEnable()
    {
        GameOverCam.SetActive(true);
        PlayerCam.SetActive(false);
    }
}
