using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHP = 10f; // ���� ü�� 
    public float health { get; protected set; }
    public AudioClip dieSound; // 사망 시 재생할 소리
    public AudioClip hitSound; // 피격 시 재생할 소리


    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // ü���� ����ü������ �ʱ�ȭ
        health = playerHP;
    }

    // ������� �Դ� ���
    public void OnDamage(float damage)
    {
        Debug.Log("�����!");
        //���� ���� �ʾҴٸ� ü�� ���� ó�� ����
        if (!GameManager.instance.isGameOver)
        {
            // �������ŭ ü�� ����
            playerHP -= damage;
            //���� ü���� 0 ���϶��, ���
            if (playerHP <= 0)
            {
                Die();
            }
            audioSource.PlayOneShot(hitSound); // 피격 효과음 재생
        }
    }


    // ��� ó��
    private void Die()
    {
        // ��� ���¸� ������ ����
        GameManager.instance.isGameOver = true;
        PlayerMove pm = GetComponent<PlayerMove>();
        pm.playerAnimator.SetTrigger("isDead");

        audioSource.PlayOneShot(dieSound); // Die효과음 재생
    }
}