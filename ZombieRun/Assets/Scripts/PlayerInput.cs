using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //����� �Է� ����

    //--Axis name--//
    string moveVerticalName = "Vertical";   //�յ� ������
    string moveHorizontalName = "Horizontal";   //�¿� ������

    //�� �Ҵ��� ���ο����� ����, private
    public float moveV { get; private set; }
    public float moveH { get; private set; }

    void FixedUpdate()
    {
        //todo: ���� ���� ���°� �Ǹ� �Է� ���� ���� �ʴ´�
        //�����¿� �Է� ����
        moveV = Input.GetAxis(moveVerticalName);
        moveH = Input.GetAxis(moveHorizontalName);
        Debug.Log(moveV);

    }
}
