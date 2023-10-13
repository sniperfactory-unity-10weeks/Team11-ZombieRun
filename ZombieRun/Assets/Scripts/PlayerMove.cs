using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float moveSpeed = 5f;
    float rotateSpeed = 10f;

    PlayerInput playerInput; //플레이어 입력 감지
    Rigidbody playerRigidbody;
    public Animator playerAnimator;

    public AudioClip footstep;

    private AudioSource audioSourcefoot;

    float nowRotate;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        audioSourcefoot = GetComponent<AudioSource>();
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
        //WASD : player move
        Vector3 moveDistance = new Vector3();
        //if input
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

        if (isMove && !audioSourcefoot.isPlaying) {
        // audioSourcefoot.clip = footstep;
        audioSourcefoot.PlayOneShot(footstep);
        
        }
    }

    private void Rotate()
    {
        if (playerInput.rotateX != 0)
        {
            nowRotate += playerInput.rotateX * rotateSpeed;
            transform.eulerAngles = new Vector3(0, nowRotate, 0);

        }
        else
        {
            transform.eulerAngles = new Vector3(0, nowRotate, 0);
        }
    }
     
}