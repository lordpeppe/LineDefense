using UnityEngine;
using System.Collections;

public class ShipShooting : MonoBehaviour 
{
	[SerializeField]
	private KeyCode shoot;

	private Resource projectilePool;

	[SerializeField]
	private Rigidbody2D defaultProjectile;

	[SerializeField]
	private int projectileLimit = 20;

	private float speed = 15;

	void Start () 
	{
		projectilePool = new Resource(defaultProjectile, projectileLimit, transform.position);
	}
	
	void Update () 
	{
		if (Input.GetKeyDown (shoot)) 
		{
			Shoot ();
		}
	}

	void Shoot()
	{
		Rigidbody2D projectile = projectilePool.getNext();
		projectile.transform.position = transform.position - new Vector3(0, 0.7f, 0);
		projectile.gameObject.SetActive(true);
		projectile.velocity = new Vector2(speed, 0);

		Rigidbody2D projectile2 = projectilePool.getNext();
		projectile2.transform.position = transform.position + new Vector3(0, 0.7f, 0);
		projectile2.gameObject.SetActive(true);
		projectile2.velocity = new Vector2(speed, 0);
	}

}
