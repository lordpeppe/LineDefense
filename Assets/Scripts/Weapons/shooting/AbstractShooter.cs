using UnityEngine;
using System.Collections;

public abstract class AbstractShooter : MonoBehaviour {

    protected Resource projectilePool;

    [SerializeField]
    protected Rigidbody2D defaultProjectile;

    [SerializeField]
    protected int projectileLimit = 20;

    [SerializeField]
    protected float speed = 15;

    protected bool CanShoot { get; set; }

    [SerializeField]
    protected float cooldownTime = 0.2f;


    public void Init()
    {
        CanShoot = true;
        transform.position = transform.parent.position;
        projectilePool = new Resource(defaultProjectile, projectileLimit, transform.position);
    }

    void Update()
    {


    }

    public void Shoot()
    {
        if (CanShoot)
        {
            AuxShoot(projectilePool, speed);
            StartCoroutine(BulletCooldown());
            CanShoot = false;
        }
    }

    public abstract void AuxShoot(Resource projectilePool, float speed);

    IEnumerator BulletCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        CanShoot = true;
    }
}
