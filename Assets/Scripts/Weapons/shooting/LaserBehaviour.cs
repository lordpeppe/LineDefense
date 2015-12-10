using UnityEngine;
using System.Collections;

public class LaserBehaviour : ProjectileBehaviour {
    
	[SerializeField]
    protected float heightModifier;

<<<<<<< HEAD
	void Start () 
	{
	
=======
    bool growing;
	// Use this for initialization
	void Start () {
        growing = false;
>>>>>>> ba28a99658083d012c2d801a23fd5389ac7d3530
	}
	
	void Update () 
	{
        if (gameObject)
        {
<<<<<<< HEAD
            transform.localScale -= new Vector3(0, heightModifier, 0);
            transform.localScale.Normalize();            
=======
            if (transform.localScale.y < 1)
            {
                if (growing)
                {
                    transform.localScale += new Vector3(0, heightModifier, 0);
                    transform.localScale.Normalize();

                }
            }
            else
            {
                growing = false;
            }
            if (transform.localScale.y > 0)
            {
                if (!growing)
                {
                    transform.localScale -= new Vector3(0, heightModifier, 0);
                    transform.localScale.Normalize();
                    Debug.Log(transform.localScale);
                }
            }
            else
            {
                growing = true;
            }
            
>>>>>>> ba28a99658083d012c2d801a23fd5389ac7d3530
        }
		/* Adjusts the size of the BoxCollider to fit the scaled sprite */
		Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
		gameObject.GetComponent<BoxCollider2D>().size = S;
		gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);
	}

    
}
