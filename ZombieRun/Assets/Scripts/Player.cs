using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHP = 10f; // ���� ü�� 
    public float health { get; protected set; }

    Rigidbody rb;

    void Start()
    {
        // ü���� ����ü������ �ʱ�ȭ
        health = playerHP;

        rb = GetComponent<Rigidbody>();
    }

    // ������� �Դ� ���
    public void OnDamage(float damage)
    {
        Debug.Log("�����!");
        //���� ���� �ʾҴٸ� ü�� ���� ó�� ����
        if (!GameManager.instance.isGameOver)
        {
            // ȭ�� �Ͻ������� �Ӿ��� ȿ��
            UIManager.instance.Attacked();
            // �������ŭ ü�� ����
            playerHP -= damage;
            //���� ü���� 0 ���϶��, ���
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

	// ��� ó��
	private void Die()
    {
        // ��� ���¸� ������ ����
        GameManager.instance.isGameOver = true;
		PlayerMove pm = GetComponent<PlayerMove>();
        pm.playerAnimator.SetTrigger("isDead");
    }
}