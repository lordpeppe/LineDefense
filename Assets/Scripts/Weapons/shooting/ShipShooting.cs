using UnityEngine;
using System.Collections;

public class ShipShooting : MonoBehaviour 
{

	private Resource projectilePool;

	[SerializeField]
	private Rigidbody2D defaultProjectile;

	[SerializeField]
	private int projectileLimit = 20;

	private float speed = 15;

	private bool CanShoot { get; set; }

	private float cooldownTime = 0.2f;

	void Start () 
	{
        transform.position = transform.parent.position;
		CanShoot = true;
		projectilePool = new Resource(defaultProjectile, projectileLimit, transform.position);
	}
	
	void Update () 
	{
		

	}

	public void Shoot()
	{
		if (CanShoot) {
			Rigidbody2D projectile = projectilePool.GetNext ();
			projectile.transform.position = transform.position - new Vector3 (0, 0.7f, 0);
			projectile.gameObject.SetActive (true);
			projectile.velocity = new Vector2 (speed, 0);

			Rigidbody2D projectile2 = projectilePool.GetNext ();
			projectile2.transform.position = transform.position + new Vector3 (0, 0.7f, 0);
			projectile2.gameObject.SetActive (true);
			projectile2.velocity = new Vector2 (speed, 0);
			StartCoroutine (BulletCooldown ());
			CanShoot = false;
		}
	}

	IEnumerator BulletCooldown()
	{
		yield return new WaitForSeconds (cooldownTime);
		CanShoot = true;
	}


}
