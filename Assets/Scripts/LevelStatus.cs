using UnityEngine;
using System.Collections;

public class LevelStatus : MonoBehaviour 
{
	[SerializeField]
	private HQ hq;

	[SerializeField]
	private float currentHealth;

	public float maxHealth;

	private GUIStyle outerBoxStyle;
	private GUIStyle innerBoxStyle;
	private GUIStyle innerBoxStylePlayer;
	private GUIStyle textStyle;

	void Start () 
	{
		LevelManager.levelManager.GoldCoins = 50;
		maxHealth = currentHealth;
	}
	
	void Update () 
	{
		if (currentHealth <= 0)
			Application.LoadLevel ("mapScene");
	}

	/* Used for drawing enemy status bar */
	void OnGUI()
	{
		/* Setup styles */
		outerBoxStyle = new GUIStyle (GUI.skin.box);
		outerBoxStyle.normal.background = MakeTex (1, 1, Color.black);

		innerBoxStyle = new GUIStyle (GUI.skin.box);
		innerBoxStyle.normal.background = MakeTex (1, 1, Color.red);

		innerBoxStylePlayer = new GUIStyle (GUI.skin.box);
		innerBoxStylePlayer.normal.background = MakeTex (1, 1, Color.green);

		textStyle = new GUIStyle (GUI.skin.textArea);
		textStyle.normal.textColor = Color.black;
	
		/* Enemy health bar */
		GUI.TextField (new Rect (new Vector2 (40, 20), new Vector2(100,50)), "Enemy health", textStyle);
		GUI.Box(new Rect(new Vector2(40,40), new Vector2(100, 30)), "", outerBoxStyle);
		GUI.Box (new Rect (new Vector2 (50, 50), new Vector2 (currentHealth >= 0 ? currentHealth / maxHealth * 80.0f : 0, 10)), "", innerBoxStyle);

		/* Player health bar */
		GUI.TextField (new Rect (new Vector2 (200, 20), new Vector2(100,50)), "Player health", textStyle);
		GUI.Box(new Rect(new Vector2(200,40), new Vector2(100, 30)), "", outerBoxStyle);
		GUI.Box (new Rect (new Vector2 (210, 50), new Vector2 (hq.CurrentHealth >= 0 ? hq.CurrentHealth / hq.InitHealth * 80.0f : 0, 10)), "", innerBoxStylePlayer);


	}

	public static Texture2D MakeTex( int width, int height, Color col )
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

	public void DecrementHealth()
	{
		currentHealth -= 5;
	}
}
