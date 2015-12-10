using UnityEngine;
using System.Collections;
using System;


<<<<<<< HEAD
public class LaserWeapon : AbstractShooter 
{
=======
	

public class LaserWeapon : AbstractShooter {



>>>>>>> ba28a99658083d012c2d801a23fd5389ac7d3530
    public override void AuxShoot(Resource projectilePool, float speed)
    {

        Rigidbody2D projectile = projectilePool.GetNext();
        projectile.transform.position = transform.position;
        projectile.gameObject.SetActive(true);
        projectile.velocity = new Vector2(speed, 0);
    }

    void Start () 
	{
        Init();
	}
	
	void Update () 
	{
	
	}
}
