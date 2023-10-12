using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerHP = 10f;
    public float health { get; protected set; }

    void Start()
    {
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
        }
    }

    private void Die()
    {
        GameManager.instance.isGameOver = true;
        PlayerMove pm = GetComponent<PlayerMove>();
        pm.playerAnimator.SetTrigger("isDead");
    }
}