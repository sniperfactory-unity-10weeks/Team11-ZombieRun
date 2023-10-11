using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float moveSpeed = 5f;

    PlayerInput playerInput; //�÷��̾��� �Է��� �˷��ִ� ������Ʈ
    Rigidbody playerRigidbody;
    Animator playerAnimator;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        //WASD �����¿� �̵�
        Vector3 moveDistance = new Vector3();
        //���� �̵�
        if (playerInput.moveV != 0)
        {
            moveDistance += playerInput.moveV * transform.forward * moveSpeed * Time.deltaTime;
        }
        if(playerInput.moveH != 0)
        {
            moveDistance += playerInput.moveH * transform.right * moveSpeed * Time.deltaTime;
        }

        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }
}
