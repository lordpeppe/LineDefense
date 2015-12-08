using UnityEngine;
using System.Collections;

public class SwingingEnemy : Enemy 
{
	[SerializeField]
	private GameObject explosionPrefab;

	void Start () 
	{
		currentHealth = initHealth;
	}
	
	void Update () 
	{
		if (IsDestroyed ()) 
		{
			StartCoroutine(Explode());
		}
	}

	IEnumerator Explode()	
	{
		gameObject.SetActive(false);
//		GameObject text = Instantiate (xpText, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity) as GameObject;
//		text.GetComponent<XPText> ().Show (xp);
		GameObject explosion = Instantiate (explosionPrefab, transform.position, Quaternion.identity) as GameObject;
		yield return new WaitForSeconds (0.8f);
		Destroy (explosion);
	}

	public void FollowPath(string pathName)
	{
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "time", 10, "easetype", iTween.EaseType.linear));
	}
}
