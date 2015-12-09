using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class XPText : MonoBehaviour 
{
	private Text text;

	void Start () 
	{
		transform.parent = LevelManager.levelManager.canvas.transform;
	}
	
	void Update () 
	{
	
	}

	public void Show(int points)
	{
		gameObject.GetComponent<Text> ().text = points + "";
		StartCoroutine(DestroyText ());
	}

	IEnumerator DestroyText()
	{
		for (int i = 0; i < 20; i++) 
		{
			yield return new WaitForSeconds (0.05f);
			transform.position = new Vector2 (transform.position.x, transform.position.y + 0.5f);
		}
			Destroy (gameObject);
	}
		
}
