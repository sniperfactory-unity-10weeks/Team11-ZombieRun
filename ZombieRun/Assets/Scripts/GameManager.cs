using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤 패턴
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public bool isGameOver = false; //게임 오버가 되면 true
    public GameObject CameraSet;

    private void Start()
    {
        CameraSet.SetActive(false);
    }

    void Update()
    {
        if (isGameOver)
        {
            CameraSet.SetActive(true);
        }
    }
}
