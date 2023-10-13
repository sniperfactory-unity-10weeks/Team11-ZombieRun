using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerHP = 10f;
    public float health { get; protected set; }

    public AudioClip hitSound; // 피격시 사운드 클립
    public AudioClip dieSound; // 사망 사운드

    private AudioSource audioSource; // 사용할 오디오 컴포넌트 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        health = playerHP;
    }

    public void OnDamage(float damage)
    {
        Debug.Log("피격!");

        if (!GameManager.instance.isGameOver)
        {

            UIManager.instance.Attacked();
            playerHP -= damage;
            UIManager.instance.UpdateHealthBar(damage);

            if (playerHP <= 0)
            {
                UIManager.instance.GameOver();
                Die();
            }
            audioSource.PlayOneShot(hitSound);
            
        }
    }

    private void Die()
    {
        GameManager.instance.isGameOver = true;
        PlayerMove pm = GetComponent<PlayerMove>();
        pm.playerAnimator.SetTrigger("isDead");
        audioSource.PlayOneShot(dieSound);
    }
}