using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }
            return m_instance;
        }
    }

    private static UIManager m_instance;

    // HP��
    [SerializeField] private Slider slider;

    // Key ������Ʈ��
    [SerializeField] private GameObject KeyL;
    [SerializeField] private GameObject KeyL_Null;
    [SerializeField] private GameObject KeyR;
    [SerializeField] private GameObject KeyR_Null;
    [SerializeField] private GameObject KeyF;
    [SerializeField] private GameObject KeyF_Null;

    // OpenDoor �˾�
    [SerializeField] private GameObject DoorPopUp;

    // ���� ������ ȭ�� �Ӿ���
    [SerializeField] private GameObject AttackedEffectPanel;

    // HP�� ����, Player ��ũ��Ʈ���� ���� ���� �� ȣ��
    public void UpdateHealthBar(float damage)
    {
        slider.value -= damage;
        if (slider.value <= 0)
            slider.value = 0;
    }

    // Kye ����, Player ��ũ��Ʈ�� ���� ��ũ��Ʈ�κ��� ������ �޾� ȣ��
    public void UpdateKeys(int value)
    {
        switch (value)
        {
            case 0:
                KeyL_Null.SetActive(false);
                KeyL.SetActive(true);   // ���� �̹��� Ȱ��ȭ
                break;
            case 1:
                KeyR_Null.SetActive(false);
                KeyR.SetActive(true);
                break;
            case 2:
                KeyF_Null.SetActive(false);
                KeyF.SetActive(true);
                break;
        }
    }

    // �� Ŭ�� �� �˾� Ȱ��ȭ
    public void PopUp()
    {
        DoorPopUp.SetActive(true);
    }
    // �˾� yes, ���� �� �ε�
    public void OpenDoor()
    {
        // SceneManager.LoadScene("Ending");
    }
    // �˾� No, �˾� �����
    public void ClosePopUp()
    {
        DoorPopUp.SetActive(false);
    }

    
    // ���� ���� �� ȭ�� �Ӿ���
    public void Attacked()
    {
        StartCoroutine("AttackedEffect");
    }

    // 2�� ���� ȭ�� �Ӿ��� ȿ�� �ڷ�ƾ
    IEnumerator AttackedEffect()
    {
        AttackedEffectPanel.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        AttackedEffectPanel.SetActive(false);
    }
}