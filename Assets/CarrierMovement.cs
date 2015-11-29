﻿using UnityEngine;
using System.Collections;

public class CarrierMovement : MonoBehaviour 
{
	[SerializeField]
	private Transform startDestination;
	[SerializeField]
	private Transform endDestination;
	[SerializeField]
	private GameObject spawnPrefab;
	[SerializeField]
	private float speed;
	private Vector2 position;
	private bool GoingToFirst { get; set; }

	void Start () 
	{
		GoingToFirst = true;
		position = transform.position;
		StartCoroutine (SpawnSpawn ());
	}
	
	void Update () 
	{
		if (GoingToFirst) {
			if (Mathf.Abs (startDestination.position.x - transform.position.x) > 0.05f && Mathf.Abs (startDestination.position.y - transform.position.y) > 0.05f) {
				Vector3 direction = (startDestination.position - transform.position).normalized;
				transform.position += (direction * speed * Time.deltaTime);
			}
			else
				GoingToFirst = false;
		}
		else 
		{
			if (Mathf.Abs (endDestination.position.x - transform.position.x) > 0.05f && Mathf.Abs (endDestination.position.y - transform.position.y) > 0.05f) {
				Vector3 direction = (endDestination.position - transform.position).normalized;
				transform.position += (direction * speed * Time.deltaTime);
			}
			else
				GoingToFirst = true;
		}
	}

	IEnumerator SpawnSpawn()
	{
		Instantiate (spawnPrefab, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(1f);
		StartCoroutine (SpawnSpawn ());
	}
}
