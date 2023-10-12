using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // �˾� â, �ؽ�Ʈ
    [SerializeField] private GameObject CreditPopUp;
    [SerializeField] private GameObject LicencePopUp;
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
        CreditPopUp.SetActive(true);  // �˾�â ����
    }

    // ���̼��� ��ư Ŭ��,
    public void Licence()
    {
        ButtonPanel.SetActive(false);   // ��ư ��Ȱ��ȭ
        LicencePopUp.SetActive(true);  // �˾�â ����
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

    // ũ���� �˾� ���� ��ư Ŭ��,
    public void CloseCreditPopUp()
    {
        ButtonPanel.SetActive(true);   // ��ư Ȱ��ȭ
        CreditPopUp.SetActive(false);  // �˾�â �����
    }

    // ���̼��� �˾� ���� ��ư Ŭ��,
    public void CloseLecencePopUp()
    {
        ButtonPanel.SetActive(true);   // ��ư Ȱ��ȭ
        LicencePopUp.SetActive(false);   // �˾�â �����
    }
}
