using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerHP = 10f;
    public float health { get; protected set; }


    public AudioClip hitSound; // 피격시 사운드 클립
    public AudioClip dieSound; // 사망 사운드

    private AudioSource audioSource; // 플레이어의 AudioSource

    void Start()
    {
        health = playerHP;
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDamage(float damage)
    {
        Debug.Log("피격!");

        if (!GameManager.instance.isGameOver)
        {
            // 피격 사운드 재생
            PlaySound(damageSound);

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
        // 사망 사운드 재생
        PlaySound(deathSound);
    }

    private void PlaySound(AudioClip sound)
    {
        if (audioSource != null && sound != null)
        {
            audioSource.PlayOneShot(sound);

        }

    }
}