using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
     //사용자 입력 감지

    //--Axis name--//
    string moveVerticalName = "Vertical";   //앞뒤 움직임
    string moveHorizontalName = "Horizontal";   //좌우 움직임
    string rotateXName = "Mouse X"; //마우스 우클릭으로 좌우 회전
    //값 할당은 내부에서만 가능, private
    public float moveV { get; private set; }
    public float moveH { get; private set; }
    public float mouseLeft { get; private set; }
    public float rotateX { get; private set; }

    void FixedUpdate()
    {
        //todo: 게임 오버 상태가 되면 입력 감지 받지 않는다
        //상하좌우 입력 감지
        moveV = Input.GetAxis(moveVerticalName);
        moveH = Input.GetAxis(moveHorizontalName);
        //오른쪽 드래그로 카메라 회전
        if (Input.GetMouseButton(1))
        {
            rotateX = Input.GetAxis(rotateXName);
        }
        else
        {
            rotateX = 0;
        }

    }
     

}
