using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    // 처음으로 버튼 클릭, 시작 Scene 로드
    public void LoadStart()
    {
        SceneManager.LoadScene("Start");
    }
}
