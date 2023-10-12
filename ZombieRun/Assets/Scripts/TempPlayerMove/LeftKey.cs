using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftKey : MonoBehaviour
{
	public static int leftKeyDialogueIndex = 0;
	private void OnDisable()
	{
		
		PlayerMovement.instance.startKTalk(this.gameObject);
	}
}
