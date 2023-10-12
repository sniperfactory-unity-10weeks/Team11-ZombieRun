using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // 팝업 창, 텍스트
    [SerializeField] private GameObject PopUp;
    [SerializeField] private Text txt;
    [SerializeField] private Text Title;

    // 버튼 패널
    [SerializeField] private GameObject ButtonPanel;

    // 게임 종료 팝업
    [SerializeField] private GameObject ExitPopUp;

    // 게임 시작 버튼 클릭, 메인 Scene 로드
    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    // 크레딧 버튼 클릭,
    public void Credit()
    {
        ButtonPanel.SetActive(false);   // 버튼 비활성화
        PopUp.SetActive(true);  // 팝업창 띄우기
        txt.text = "Credit Credit";
        Title.text = "Credit";
    }

    // 라이선스 버튼 클릭,
    public void Licence()
    {
        ButtonPanel.SetActive(false);   // 버튼 비활성화
        PopUp.SetActive(true);  // 팝업창 띄우기
        txt.text = "Licence Licence";
        Title.text = "Licence";
    }

    // 게임 종료 버튼 클릭,
    public void ClickExit()
    {
        ExitPopUp.SetActive(true);

    }
    // 게임 종료 하기
    public void ExitGame()
    {
        Application.Quit(); // 에디터에서는 실행 XXX
    }
    // 게임 종료 안 하기
    public void CloseExitPopUp()
    {
        ButtonPanel.SetActive(true);   // 버튼 비활성화
        ExitPopUp.SetActive(false);  // 팝업창 띄우기
    }

    // 팝업 종료 버튼 클릭,
    public void ClosePopUp()
    {
        ButtonPanel.SetActive(true);   // 버튼 비활성화
        PopUp.SetActive(false);  // 팝업창 띄우기
    }
}
