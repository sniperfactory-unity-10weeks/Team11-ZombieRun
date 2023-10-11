using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	public static DialogueManager Instance;

	public TextAsset Items;
	public ItemsAllData itemsAllData;


	private void OnEnable()
	{
		itemsAllData = JsonUtility.FromJson<ItemsAllData>(Items.text);
	}

	private void Awake()
	{
		if (Instance == null) DialogueManager.Instance = this;
		else Destroy(Instance);
	}
}


[System.Serializable]
public class ItemsAllData
{
	public ItemData[] LeftKey;
	public ItemData[] RightKey;
	public ItemData[] FinishKey;
}

[System.Serializable]
public class ItemData
{
	public int branch;
	public string name;
	public string dialogue;
	public int itemCode;
}
