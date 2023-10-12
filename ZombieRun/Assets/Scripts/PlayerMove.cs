using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float moveSpeed = 5f;
    float rotateSpeed = 10f;

    PlayerInput playerInput; //�÷��̾��� �Է��� �˷��ִ� ������Ʈ
    Rigidbody playerRigidbody;
    public Animator playerAnimator;

    Quaternion nowRotate;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }
        Move();
        Rotate();
    }

    private void Move()
    {
        bool isMove = false;
        //WASD �����¿� �̵�
        Vector3 moveDistance = new Vector3();
        //���� �̵�
        if (playerInput.moveV != 0)
        {
            isMove = true;
            moveDistance += playerInput.moveV * transform.forward * moveSpeed * Time.deltaTime;
        }
        if(playerInput.moveH != 0)
        {
            isMove = true;
            moveDistance += playerInput.moveH * transform.right * moveSpeed * Time.deltaTime;
        }

        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
        playerAnimator.SetBool("isWalk", isMove);
    }

    private void Rotate()
    {
        if (playerInput.rotateX != 0)
        {
            transform.Rotate(0, playerInput.rotateX * rotateSpeed, 0);
            nowRotate = transform.rotation;
        }
        else
        {
            transform.rotation = nowRotate;
        }
    }
     

}
