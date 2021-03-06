﻿using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	[SerializeField]
	private KeyCode up, down, left, right;
	private SpriteRenderer spriteRenderer;

	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update () 
	{
		if (Input.GetKey (up)) 
		{
			if(transform.position.y < Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight)).y - spriteRenderer.bounds.extents.y)
				transform.Translate(Vector2.up * 10 * Time.deltaTime);
		} 
		else if (Input.GetKey (down)) 
		{
			if(transform.position.y > Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y + spriteRenderer.bounds.extents.y)
				transform.Translate(Vector2.up * -10 * Time.deltaTime);
		} 
		else if (Input.GetKey (left)) 
		{
			if (transform.position.x > Camera.main.ScreenToWorldPoint (new Vector2(50, 9)).x)
				transform.Translate (Vector2.right * -10 * Time.deltaTime);
		} 
		else if (Input.GetKey (right)) 
		{
			if (transform.position.x < Camera.main.ScreenToWorldPoint (new Vector2(Camera.main.pixelWidth, 9)).x - spriteRenderer.bounds.extents.x)
				transform.Translate (Vector2.right * 10 * Time.deltaTime);
		}
	}
}
