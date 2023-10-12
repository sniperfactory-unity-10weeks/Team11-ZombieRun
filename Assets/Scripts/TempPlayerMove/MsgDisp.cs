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
		const float guiWidth = 800; //�ʺ�
		const float guiHeight = 200; //����
		const float guiLeft = (guiScreen - guiWidth) / 2; //���ʿ��� �󸶳� �����
		const float guiTop = 720 - guiHeight - 20; //�ϴܿ��� ��ӳ� �����

		//����ȭ��� ����
		float gui_scale = Screen.width / guiScreen;

		//�޼���â ��ġ 
		rtDisplay.x = guiLeft * gui_scale;
		rtDisplay.y = guiTop * gui_scale;
		rtDisplay.width = guiWidth * gui_scale;
		rtDisplay.height = guiHeight * gui_scale;

		GUIStyle msgFont = new GUIStyle
		{
			fontSize = (int)(30 * gui_scale),
			wordWrap = true,
		};

		if (eventText && !flagDiaplay)
		{
			msgFont.normal.textColor = Color.white;
			rtDisplay.x = (guiLeft + 30) * gui_scale;
			rtDisplay.y = (guiTop + 60) * gui_scale;
			GUI.Label(rtDisplay, "E�� ���� ��ȣ�ۿ�!!", msgFont);
		}

		if (flagDiaplay)
		{
			//����ȭ��� ����
			gui_scale = Screen.width / guiScreen;

			//�޼���â ��ġ 
			rtDisplay.x = guiLeft * gui_scale;
			rtDisplay.y = guiTop * gui_scale;
			rtDisplay.width = guiWidth * gui_scale;
			rtDisplay.height = guiHeight * gui_scale;
			//�޼���â
			GUI.Box(rtDisplay, "", guiDisplay);

			msgFont.normal.textColor = Color.black;
			rtDisplay.x = (guiLeft + 20) * gui_scale;
			rtDisplay.y = (guiTop + 15) * gui_scale;
			GUI.Label(rtDisplay, playerWhoTalk, msgFont);


			//�޼��� �׸���
			msgFont.normal.textColor = Color.black;
			rtDisplay.x = (guiLeft + 30) * gui_scale;
			rtDisplay.y = (guiTop + 60) * gui_scale;
			GUI.Label(rtDisplay, msg.Substring(0, msgLen), msgFont);

			//�޼��� ���
			msgFont.normal.textColor = Color.white;
			rtDisplay.x = (guiLeft + 28) * gui_scale;
			rtDisplay.y = (guiTop + 58) * gui_scale;
			GUI.Label(rtDisplay, msg.Substring(0, msgLen), msgFont);
		}
	}

	//�ܺο��� �޼��� �ޱ�
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

	//Behaviour�� ����� ��� Update�� �̿�
	private void Update()
	{
		if (flagDiaplay && Time.time > nextTime)
		{
			if (msgLen < msg.Length) msgLen++;
			nextTime = Time.time + 0.02f;
		}
	}
}