using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    // ó������ ��ư Ŭ��, ���� Scene �ε�
    public void LoadStart()
    {
        SceneManager.LoadScene("Start");
    }
}
