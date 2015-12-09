using UnityEngine;
using System.Collections;

public class Carrier : Enemy 
{	
	[SerializeField]
	private Transform startDestination;
	[SerializeField]
	private Transform endDestination;
	[SerializeField]
	private GameObject spawnPrefab;

	private Vector2 position;
	private bool GoingToFirst { get; set; }

	void Start () 
	{
		xp = 100;
		currentHealth = 100;
		enemyTag = "CARRIER";
		GoingToFirst = true;
		position = transform.position;
		StartCoroutine (SpawnSpawn ());
	}
	
	void Update () 
	{
		if (!IsDestroyed ()) 
		{
			if (GoingToFirst) 
			{
				if (Mathf.Abs (startDestination.position.x - transform.position.x) > 0.05f && Mathf.Abs (startDestination.position.y - transform.position.y) > 0.05f) 
				{
					Vector3 direction = (startDestination.position - transform.position).normalized;

					transform.position += (direction * speed * Time.deltaTime);
				} 
				else
					GoingToFirst = false;
			} 
			else 
			{
				if (Mathf.Abs (endDestination.position.x - transform.position.x) > 0.05f && Mathf.Abs (endDestination.position.y - transform.position.y) > 0.05f) 
				{
					Vector3 direction = (endDestination.position - transform.position).normalized;
					transform.position += (direction * speed * Time.deltaTime);
				} 
				else
					GoingToFirst = true;
			}
		} 
		else 
		{
			GameObject.FindGameObjectWithTag ("level").GetComponent<LevelStatus>().DecrementHealth();
			Destroy (gameObject);
		}
	}

	IEnumerator SpawnSpawn()
	{
		GameObject enemy = Instantiate (spawnPrefab, transform.position, Quaternion.identity) as GameObject;
		enemy.GetComponent<KamikazeEnemy> ().ResetHealth ();
		yield return new WaitForSeconds(Random.Range(1,5));
		StartCoroutine (SpawnSpawn ());
	}
}
