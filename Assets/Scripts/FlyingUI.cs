using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlyingUI : MonoBehaviour {

	private GUIStyle textStyle;

	void OnGUI()
	{
		textStyle = new GUIStyle ();
		textStyle.normal.textColor = Color.black;
		textStyle.fontSize = 22;
		GUI.Label (new Rect (10, 10, 400, 10), "SCORE 0000", textStyle);
	}
}
