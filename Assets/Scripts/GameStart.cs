using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // �˾� â, �ؽ�Ʈ
    [SerializeField] private GameObject PopUp;
    [SerializeField] private Text txt;
    [SerializeField] private Text Title;

    // ��ư �г�
    [SerializeField] private GameObject ButtonPanel;

    // ���� ���� �˾�
    [SerializeField] private GameObject ExitPopUp;

    // ���� ���� ��ư Ŭ��, ���� Scene �ε�
    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    // ũ���� ��ư Ŭ��,
    public void Credit()
    {
        ButtonPanel.SetActive(false);   // ��ư ��Ȱ��ȭ
        PopUp.SetActive(true);  // �˾�â ����
        txt.text = "Credit Credit";
        Title.text = "Credit";
    }

    // ���̼��� ��ư Ŭ��,
    public void Licence()
    {
        ButtonPanel.SetActive(false);   // ��ư ��Ȱ��ȭ
        PopUp.SetActive(true);  // �˾�â ����
        txt.text = "Licence Licence";
        Title.text = "Licence";
    }

    // ���� ���� ��ư Ŭ��,
    public void ClickExit()
    {
        ExitPopUp.SetActive(true);

    }
    // ���� ���� �ϱ�
    public void ExitGame()
    {
        Application.Quit(); // �����Ϳ����� ���� XXX
    }
    // ���� ���� �� �ϱ�
    public void CloseExitPopUp()
    {
        ButtonPanel.SetActive(true);   // ��ư ��Ȱ��ȭ
        ExitPopUp.SetActive(false);  // �˾�â ����
    }

    // �˾� ���� ��ư Ŭ��,
    public void ClosePopUp()
    {
        ButtonPanel.SetActive(true);   // ��ư ��Ȱ��ȭ
        PopUp.SetActive(false);  // �˾�â ����
    }
}
