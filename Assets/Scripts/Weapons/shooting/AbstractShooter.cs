using UnityEngine;
using System.Collections;

public abstract class AbstractShooter : MonoBehaviour {

    private Resource projectilePool;

    [SerializeField]
    private Rigidbody2D defaultProjectile;

    [SerializeField]
    private int projectileLimit = 20;

    [SerializeField]
    private float speed = 15;

    private bool CanShoot { get; set; }

    [SerializeField]
    private float cooldownTime = 0.2f;


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
