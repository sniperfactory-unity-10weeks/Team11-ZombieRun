using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSet : MonoBehaviour
{

    public Camera PlayerCam;
    public Camera GameOverCam;
	private void OnDisable()
	{
		PlayerCam.enabled = true;
		GameOverCam.enabled = false;
	}

	//�÷��̾� ����� Ȱ��ȭ
	void OnEnable()
    {
		GameOverCam.enabled = true;
		PlayerCam.enabled = false;
    }
}
