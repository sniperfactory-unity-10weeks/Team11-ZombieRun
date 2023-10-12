using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MsgDisp : MonoBehaviour
{
	public static string playerWhoTalk;
	public static string msg;
	public static bool flagDiaplay = false;
	public GUIStyle guiDisplay;
	public static int msgLen;
	public static bool eventText;

	private float nextTime = 0;
	private Rect rtDisplay = new Rect();

	

	private void OnGUI()
	{
		const float guiScreen = 1280;
		const float guiWidth = 800; //너비
		const float guiHeight = 200; //높이
		const float guiLeft = (guiScreen - guiWidth) / 2; //왼쪽에서 얼마나 띄울지
		const float guiTop = 720 - guiHeight - 20; //하단에서 얼머나 띄울지

		//현재화면과 비율
		float gui_scale = Screen.width / guiScreen;

		//메세지창 위치 
		rtDisplay.x = guiLeft * gui_scale;
		rtDisplay.y = guiTop * gui_scale;
		rtDisplay.width = guiWidth * gui_scale;
		rtDisplay.height = guiHeight * gui_scale;

		GUIStyle msgFont = new GUIStyle
		{
			fontSize = (int)(30 * gui_scale),
			wordWrap = true
		};

		if (eventText && !flagDiaplay)
		{
			msgFont.normal.textColor = Color.black;
			rtDisplay.x = (guiLeft + 30) * gui_scale;
			rtDisplay.y = (guiTop + 60) * gui_scale;
			GUI.Label(rtDisplay, "E를 눌러 상호작용!!", msgFont);
		}

		if (flagDiaplay)
		{
			//현재화면과 비율
			gui_scale = Screen.width / guiScreen;

			//메세지창 위치 
			rtDisplay.x = guiLeft * gui_scale;
			rtDisplay.y = guiTop * gui_scale;
			rtDisplay.width = guiWidth * gui_scale;
			rtDisplay.height = guiHeight * gui_scale;
			//메세지창
			GUI.Box(rtDisplay, "", guiDisplay);

			msgFont.normal.textColor = Color.black;
			rtDisplay.x = (guiLeft + 20) * gui_scale;
			rtDisplay.y = (guiTop + 15) * gui_scale;
			GUI.Label(rtDisplay, playerWhoTalk, msgFont);


			//메세지 그림자
			msgFont.normal.textColor = Color.black;
			rtDisplay.x = (guiLeft + 30) * gui_scale;
			rtDisplay.y = (guiTop + 60) * gui_scale;
			GUI.Label(rtDisplay, msg.Substring(0, msgLen), msgFont);

			//메세지 출력
			msgFont.normal.textColor = Color.white;
			rtDisplay.x = (guiLeft + 28) * gui_scale;
			rtDisplay.y = (guiTop + 58) * gui_scale;
			GUI.Label(rtDisplay, msg.Substring(0, msgLen), msgFont);
		}
	}

	//외부에사 메세지 받기
	public static void ShowMessage(string msg)
	{
		MsgDisp.msg = msg;
		flagDiaplay = true;
		msgLen = 0;
	}

	IEnumerator Typing()
	{
		yield return null;
	}

	//Behaviour를 상속한 경우 Update문 이용
	private void Update()
	{
		if (flagDiaplay && Time.time > nextTime)
		{
			if (msgLen < msg.Length) msgLen++;
			nextTime = Time.time + 0.02f;
		}
	}
}