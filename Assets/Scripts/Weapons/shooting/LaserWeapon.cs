using UnityEngine;
using System.Collections;
using System;


	

public class LaserWeapon : AbstractShooter {



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
