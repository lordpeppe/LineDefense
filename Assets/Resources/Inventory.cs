using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour 
{
	private bool inventoryOpen;
	private GUIStyle blueBoxStyle;
	private GUIStyle textStyle;

	[SerializeField]
	private Texture texture;

	void Start () 
	{
		inventoryOpen = false;
	}
	
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.I)) 
		{
			/* Inventory */
			inventoryOpen = !inventoryOpen;
		}
	}

	void OnGUI()
	{
		if (inventoryOpen) 
		{
			blueBoxStyle = new GUIStyle (GUI.skin.box);
			blueBoxStyle.normal.background = LevelStatus.MakeTex (1, 1, Color.white);
			GUI.Box (new Rect(Camera.main.pixelWidth / 2 - 100,200,200,200), "", blueBoxStyle);
			GUI.DrawTexture (new Rect (Camera.main.pixelWidth / 2 - 100 + 10, 200, 30, 30), texture);

			textStyle = new GUIStyle ();
			textStyle.normal.textColor = Color.black;
			GUI.Label (new Rect (Camera.main.pixelWidth / 2 - 100 + 50, 210, 100, 100), LevelManager.levelManager.GoldCoins + "", textStyle);
		}
	}

}
