using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHP = 10f; // 시작 체력 
    public float health { get; protected set; }

    Rigidbody rb;

    void Start()
    {
        // 체력을 시작체력으로 초기화
        health = playerHP;

        rb = GetComponent<Rigidbody>();
    }

    // 대미지를 입는 기능
    public void OnDamage(float damage)
    {
        Debug.Log("대미지!");
        //아직 죽지 않았다면 체력 감소 처리 실행
        if (!GameManager.instance.isGameOver)
        {
            // 화면 일시적으로 붉어짐 효과
            UIManager.instance.Attacked();
            // 대미지만큼 체력 감소
            playerHP -= damage;
            //만약 체력이 0 이하라면, 사망
            if (playerHP <= 0)
            {
                Die();
			}
        }
    }

	private void FixedUpdate()
	{
		if (playerHP <= 0)
		{
			this.transform.rotation = Quaternion.Euler(Vector3.zero);
		}
	}

	// 사망 처리
	private void Die()
    {
        // 사망 상태를 참으로 변경
        GameManager.instance.isGameOver = true;
		PlayerMove pm = GetComponent<PlayerMove>();
        pm.playerAnimator.SetTrigger("isDead");
    }
}