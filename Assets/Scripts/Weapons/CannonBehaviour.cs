using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CannonBehaviour : MonoBehaviour
{

    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;
    public Rigidbody2D Default_Projectile;
    public Rigidbody2D splitProjectile;
    private float speed = 10;
    public int projectileLimit;
    private Resource projectilePool;
    private Resource splitProjectilePool;
    private Resource activePool;



    // Use this for initialization
    void Start()
    {
        projectilePool = new Resource(Default_Projectile, projectileLimit, transform.position);
        splitProjectilePool = new Resource(splitProjectile, projectileLimit, transform.position);
        activePool = projectilePool;

    }

    void Update()
    {
        Vector3 mouse_pos = Input.mousePosition;
        Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

        // Need to subtract player pos to get cannon rotation right
        mouse_pos.x = mouse_pos.x - player_pos.x;
        mouse_pos.y = mouse_pos.y - player_pos.y;

        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (Input.GetMouseButtonDown(0))
        {
            shoot(mouse_pos, player_pos);
        }

        if (Input.GetKeyDown("o"))
        {
            activePool = splitProjectilePool;
        }
        else if (Input.GetKeyDown("p"))
        {
            activePool = projectilePool;
        }

    }

    void shoot(Vector2 dir, Vector2 player)
    {
        Vector3 dirPrime = dir.normalized;
        Rigidbody2D projectile = activePool.GetNext();
        projectile.transform.position = transform.position;
        projectile.gameObject.SetActive(true);
        projectile.velocity = (dirPrime * speed);

        if (activePool.Equals(splitProjectilePool))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(dir.x + player.x, dir.y + player.y, 0));
            mousePos = new Vector3(mousePos.x, mousePos.y, 0);

        }


    }
}