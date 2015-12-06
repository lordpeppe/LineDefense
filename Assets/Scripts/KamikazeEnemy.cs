using UnityEngine;
using System.Collections;

public class KamikazeEnemy : Enemy 
{
	[SerializeField]
	private Transform hq;
	[SerializeField]
	GameObject explosionPrefab;

	void Start () {
		initHealth = 5;
		speed = 3;
		if (hq == null)
			hq = GameObject.FindGameObjectWithTag ("HQ").transform;
	}

	void Awake()
	{
		if (hq == null)
			hq = GameObject.FindGameObjectWithTag ("HQ").transform;
	}

	void Update()
	{
		if (!IsDestroyed())
		{
			Move(hq.transform.position.x , hq.transform.position.y);
		}
		else
		{
			GameObject.FindGameObjectWithTag ("level").GetComponent<LevelStatus>().DecrementHealth();
			StartCoroutine(Explode());
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "HQ")
		{
			other.gameObject.GetComponent<HQ>().TakeDamage(damage);
			StartCoroutine(Explode());
		}
	}

	IEnumerator Explode()	
	{
		gameObject.SetActive(false);
		GameObject explosion = Instantiate (explosionPrefab, transform.position, Quaternion.identity) as GameObject;
		yield return new WaitForSeconds (0.8f);
		Destroy (explosion);
	}

}
