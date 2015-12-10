using UnityEngine;
using System.Collections;

public class LaserBehaviour : ProjectileBehaviour {
    [SerializeField]
    protected float heightModifier;

    bool growing;
	// Use this for initialization
	void Start () {
        growing = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject)
        {
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
            
        }
	}

    
}
