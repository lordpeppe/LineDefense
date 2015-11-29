using UnityEngine;
using System.Collections;

public class KamikazeEnemy : Enemy {

	// Use this for initialization
	void Start () {
	
	}

	void Update()
	{
		if (!IsDestroyed())
		{
			Move(-5.74f , -1.08f);
		}
		else
		{
			gameObject.SetActive(false);
		}
	}
}
