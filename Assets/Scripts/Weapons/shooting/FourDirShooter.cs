using UnityEngine;
using System.Collections;

public class FourDirShooter : AbstractShooter {

    void Start()
    {
        Init();
    }

    void Update()
    {


    }

    public override void AuxShoot(Resource projectilePool, float speed)
    {

        Rigidbody2D projectile = projectilePool.GetNext();
        projectile.transform.position = transform.position - new Vector3(0, 0.7f, 0);
        projectile.gameObject.SetActive(true);
        projectile.velocity = new Vector2(speed, 0);

        Rigidbody2D projectile2 = projectilePool.GetNext();
        projectile.transform.position = transform.position - new Vector3(0, 0.7f, 0);
        projectile.gameObject.SetActive(true);
        projectile.velocity = new Vector2(speed, 0);

        Rigidbody2D projectile3 = projectilePool.GetNext();
        projectile.transform.position = transform.position - new Vector3(0, 0.7f, 0);
        projectile.gameObject.SetActive(true);
        projectile.velocity = new Vector2(speed/1.5f, speed);

        Rigidbody2D projectile4 = projectilePool.GetNext();
        projectile2.transform.position = transform.position + new Vector3(0, 0.7f, 0);
        projectile2.gameObject.SetActive(true);
        projectile2.velocity = new Vector2(speed/1.5f, -speed);

    }

}
