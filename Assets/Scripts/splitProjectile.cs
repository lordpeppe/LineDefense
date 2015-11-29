using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class splitProjectile : projectile_Behaviour {
   public  Rigidbody2D projectileBody;
    public int splitProjectileLimit;
    Resource splitProjectilePool;
    List<Vector3> directionsList;
    Vector3 destination;
    public float explosionSpeed;
    public Rigidbody2D powerUp;

	// Use this for initialization
	void Start () {

        explosionSpeed = Mathf.Max(explosionSpeed, 1);
        directionsList = new List<Vector3>();
        directionsList.Add(new Vector3(1 * explosionSpeed, 0, 0));
        directionsList.Add(new Vector3(0, 1 * explosionSpeed, 0));
        directionsList.Add(new Vector3(0, -1 * explosionSpeed, 0));
        directionsList.Add(new Vector3(-1 * explosionSpeed, 0, 0));
        splitProjectilePool = new Resource(projectileBody, splitProjectileLimit, transform.position);

	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(destination, transform.position);
	    if(distance < 0.5f)
        {
            Debug.Log("Splitting");
            split();
        }
	}

    void split()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        
        for (int i = 0; i < splitProjectileLimit; i++)
        {
            Rigidbody2D temp = splitProjectilePool.getNext();
            temp.gameObject.transform.position = transform.position;
            temp.gameObject.SetActive(true);
            temp.velocity = directionsList[i];
            
        }
        gameObject.SetActive(false);


    }

    public void setDestination(Vector3 destination)
    {
        this.destination = destination;
    }
}
