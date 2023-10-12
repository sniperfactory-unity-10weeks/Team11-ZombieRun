using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftKey : MonoBehaviour
{
	public static int leftKeyDialogueIndex = 0;
	private void OnDisable()
	{
        PlayerMovement.isInteract = false;
        PlayerMovement.instance.startKTalk(this.gameObject);
	}
}
