using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    // ����� ��ư Ŭ��, ���� Scene �ε�
    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    // ������ ��ư Ŭ��, ���� Scene �ε�
    public void Exit()
    {
        SceneManager.LoadScene("Start");
    }
}
