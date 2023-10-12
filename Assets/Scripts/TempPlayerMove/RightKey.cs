using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightKey : MonoBehaviour
{
	public static int rightKeyDialogueIndex = 0;
	private void OnDisable()
	{
        PlayerMovement.isInteract = false;
        PlayerMovement.instance.startKTalk(this.gameObject);
	}
}
