using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    // 게임 시작 버튼 클릭, 메인 Scene 로드
    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }
}
