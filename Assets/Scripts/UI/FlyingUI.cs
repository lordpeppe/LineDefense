using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlyingUI : MonoBehaviour {

	private GUIStyle levelRect;
	private GUIStyle playerPositionCircle;
	private GUIStyle textStyle;

	[SerializeField]
	private Texture playerTexture;
	private Vector2 oldPosition;
	private Vector2 newPosition;

	[SerializeField]
	private FlyingLevelStatus flyingLevelStatus;

	void Start()
	{
		oldPosition = new Vector2 (10, 15);
	}
		
	void OnGUI()
	{
		Debug.Log ("LOOOL");
		levelRect = new GUIStyle (GUI.skin.box);
		levelRect.normal.background = LevelStatus.MakeTex (1, 1, Color.grey);
		GUI.Box (new Rect (10, 10, 200, 20), "", levelRect);

		playerPositionCircle = new GUIStyle (GUI.skin.box);
		playerPositionCircle.normal.background = LevelStatus.MakeTex (1, 1, Color.red);

		newPosition = new Vector2 (10 + (flyingLevelStatus.PercentOfDistance * 200), 15);
		GUI.DrawTexture (new Rect (Vector2.Lerp(oldPosition, newPosition, 10 * Time.deltaTime), new Vector2(10, 10)), playerTexture);
		oldPosition = newPosition;
//		textStyle = new GUIStyle ();
//		textStyle.normal.textColor = Color.black;
//		textStyle.fontSize = 22;
//		GUI.Label (new Rect (10, 10, 400, 10), "SCORE 0000", textStyle);
	}
}
