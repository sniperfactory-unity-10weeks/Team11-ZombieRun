using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // HP바
    [SerializeField] private Slider slider;

    // Key 오브젝트들
    [SerializeField] private GameObject KeyL;
    [SerializeField] private GameObject KeyL_Null;
    [SerializeField] private GameObject KeyR;
    [SerializeField] private GameObject KeyR_Null;
    [SerializeField] private GameObject KeyF;
    [SerializeField] private GameObject KeyF_Null;

    // HP바 설정, Player 스크립트에서 공격 받을 시 호출
    public void UpdateHealthBar(float damage)
    {
        slider.value -= damage;
        if (slider.value <= 0)
            slider.value = 0;
    }

    // Kye 관리, Player 스크립트나 열쇠 스크립트로부터 정보를 받아 호출
    public void UpdateKeys(int value)
    {
        switch (value)
        {
            case 0:
                KeyL_Null.SetActive(false);
                KeyL.SetActive(true);   // 열쇠 이미지 활성화
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
}