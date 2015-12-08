using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EnemyType 
{
	Swinger = 0
}

public class Spawner : MonoBehaviour 
{
	/* Can't be serialized. The data is hardcoded and should be read from txt-file or something */
	//[SerializeField]
	private Dictionary<EnemyType, List<string>> paths;

	/* EnemyPrefabs */
	[SerializeField]
	private GameObject swingerPrefab;

	void Start () 
	{
		paths = new Dictionary<EnemyType, List<string>> ();
		List<string> p = new List<string> ();
		p.Add ("midtop");
		p.Add ("midbot");
		paths.Add (EnemyType.Swinger, p);
		StartCoroutine(Spawn ());
	}
	
	void Update () 
	{
		
	}

	IEnumerator Spawn()
	{
		yield return new WaitForSeconds(Random.Range(1,15));
		string path = paths [EnemyType.Swinger] [Random.Range (0, paths [EnemyType.Swinger].Count)];
		GameObject g = Instantiate (swingerPrefab, transform.position, Quaternion.identity) as GameObject;
		g.GetComponent<SwingingEnemy> ().FollowPath (path);
		StartCoroutine(Spawn());

	}
}
