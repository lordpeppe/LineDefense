using UnityEngine;
using System.Collections;

public class LevelStatus : MonoBehaviour 
{

	public int currentHealth { get; set; }

	private GUIStyle outerBoxStyle;
	private GUIStyle innerBoxStyle;

	void Start () 
	{
		outerBoxStyle = new GUIStyle (GUI.skin.box);
		outerBoxStyle.normal.background = MakeTex (1, 1, Color.blue);
		innerBoxStyle = new GUIStyle (GUI.skin.box);
		innerBoxStyle.normal.background = MakeTex (1, 1, Color.red);

	}
	
	void Update () 
	{
		
	}

	/* Used for drawing enemy status bar */
	void OnGUI()
	{
		outerBoxStyle = new GUIStyle (GUI.skin.box);
		outerBoxStyle.normal.background = MakeTex (1, 1, Color.black);
		innerBoxStyle = new GUIStyle (GUI.skin.box);
		innerBoxStyle.normal.background = MakeTex (1, 1, Color.red);

		GUI.Box(new Rect(new Vector2(40,40), new Vector2(100, 30)), "", outerBoxStyle);
		GUI.Box (new Rect (new Vector2 (50, 50), new Vector2 (80, 10)), "", innerBoxStyle);
	}

	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}
}
