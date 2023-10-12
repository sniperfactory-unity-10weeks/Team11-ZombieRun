using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerHP = 10f;
    public float health { get; protected set; }
    public AudioClip dieSound; // 사망 시 재생할 소리
    public AudioClip hitSound; // 피격 시 재생할 소리

    public AudioClip damageSound; // 피격 사운드를 위한 AudioClip
    public AudioClip deathSound; // 사망 사운드를 위한 AudioClip

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

                audioSource.PlayOneShot(hitSound); // 피격 효과음 재생
            }
        }
    }

    private void Die()
    {
        GameManager.instance.isGameOver = true;
        PlayerMove pm = GetComponent<PlayerMove>();
        pm.playerAnimator.SetTrigger("isDead");
        audioSource.PlayOneShot(dieSound); // Die효과음 재생

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