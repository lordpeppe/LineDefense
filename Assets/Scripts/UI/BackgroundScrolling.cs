using UnityEngine;
using System.Collections;

public class BackgroundScrolling : MonoBehaviour {

	[SerializeField]
	private Transform[] backgrounds;
	private float startX;
	private Vector2 endPosition;
	private float backgroundWidth;

	void Start () 
	{
		backgroundWidth = backgrounds [0].gameObject.GetComponent<SpriteRenderer> ().bounds.extents.x * 2;
		startX = backgrounds [0].position.x;
		endPosition = backgrounds [backgrounds.Length - 1].position;
	}
	
	void Update ()
	{
		for (int i = 0; i < backgrounds.Length; i++) 
		{
			if (backgrounds [i].position.x <= startX - backgroundWidth)
				backgrounds [i].position = i == 0 ? backgrounds[2].position + new Vector3(backgroundWidth, 0, 0) : backgrounds[i - 1].position + new Vector3(backgroundWidth, 0, 0);

			backgrounds [i].Translate (new Vector2 (-5, 0) * Time.deltaTime);
		}
	}
}
