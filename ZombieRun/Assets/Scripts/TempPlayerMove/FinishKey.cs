using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishKey : MonoBehaviour
{
	public static int finishKeyDialogueIndex = 0;
	private void OnDisable()
	{
		PlayerMovement.instance.startKTalk(this.gameObject);
	}
}
