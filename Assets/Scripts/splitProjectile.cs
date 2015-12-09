using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SplitProjectile : ProjectileBehaviour 
{

    public  Rigidbody2D projectileBody;
    public int splitProjectileLimit;
    Resource splitProjectilePool;
    List<Vector3> directionsList;
    Vector3 destination;
    public float explosionSpeed;
    public Rigidbody2D powerUp;

    [SerializeField]
    float explosionDistance;

    float deltaTime;

	// Use this for initialization
	void Start () {

        explosionSpeed = Mathf.Max(explosionSpeed, 1);
        directionsList = new List<Vector3>();
        directionsList.Add(new Vector3(Mathf.Cos(0), Mathf.Sin(0), 0));
        directionsList.Add(new Vector3(Mathf.Cos(22.5f * Mathf.Deg2Rad), Mathf.Sin(22.5f * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(45 * Mathf.Deg2Rad), Mathf.Sin(45 * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(67.5f * Mathf.Deg2Rad), Mathf.Sin(67.5f * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(90 * Mathf.Deg2Rad), Mathf.Sin(90 * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(112.5f * Mathf.Deg2Rad), Mathf.Sin(112.5f * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(135 * Mathf.Deg2Rad), Mathf.Sin(135 * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(157.5f * Mathf.Deg2Rad), Mathf.Sin(157.5f * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(180 * Mathf.Deg2Rad), Mathf.Sin(180 * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(202.5f * Mathf.Deg2Rad), Mathf.Sin(202.5f * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(225 * Mathf.Deg2Rad), Mathf.Sin(225 * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(257.5f * Mathf.Deg2Rad), Mathf.Sin(257.5f * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(270 * Mathf.Deg2Rad), Mathf.Sin(270 * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(292.5f * Mathf.Deg2Rad), Mathf.Sin(292.5f * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(315 * Mathf.Deg2Rad), Mathf.Sin(315 * Mathf.Deg2Rad), 0));
        directionsList.Add(new Vector3(Mathf.Cos(337.5f * Mathf.Deg2Rad), Mathf.Sin(337.5f * Mathf.Deg2Rad), 0));


        splitProjectilePool = new Resource(projectileBody, splitProjectileLimit, transform.position);

	}
	
	// Update is called once per frame
	void Update ()
    {
        deltaTime += Time.deltaTime;
        
	    if(deltaTime >= explosionDistance)
        {
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
            temp.velocity = directionsList[i] * explosionSpeed;
            temp.GetComponent<ProjectileBehaviour>().Despawner();
            
        }
        gameObject.SetActive(false);


    }

    public void setDestination(Vector3 destination)
    {
        this.destination = destination;
    }

    void OnCollision2D(Collision2D other)
    {
        split();
    }

  
}
