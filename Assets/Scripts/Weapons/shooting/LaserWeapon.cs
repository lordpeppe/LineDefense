using UnityEngine;
using System.Collections;
using System;

<<<<<<< HEAD
public class LaserWeapon : AbstractShooter 
{
	
=======
public class LaserWeapon : AbstractShooter {


>>>>>>> bcd280e05da96225d48ae805f828c583b2d34c5e
    public override void AuxShoot(Resource projectilePool, float speed)
    {

        Rigidbody2D projectile = projectilePool.GetNext();
        projectile.transform.position = transform.position;
        projectile.gameObject.SetActive(true);
        projectile.velocity = new Vector2(speed, 0);

       
    }

    // Use this for initialization
    void Start () 
	{
        Init();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
