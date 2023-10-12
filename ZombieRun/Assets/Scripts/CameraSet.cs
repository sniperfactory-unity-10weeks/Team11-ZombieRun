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

	//플레이어 사망시 활성화
	void OnEnable()
    {
		GameOverCam.enabled = true;
		PlayerCam.enabled = false;
    }
}
