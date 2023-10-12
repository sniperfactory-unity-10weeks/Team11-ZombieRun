using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    // 재시작 버튼 클릭, 메인 Scene 로드
    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    // 나가기 버튼 클릭, 시작 Scene 로드
    public void Exit()
    {
        SceneManager.LoadScene("Start");
    }
}
