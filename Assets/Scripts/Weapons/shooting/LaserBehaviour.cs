using UnityEngine;
using System.Collections;

public class LaserBehaviour : ProjectileBehaviour {
    [SerializeField]
    protected float heightModifier;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject)
        {
                transform.localScale -= new Vector3(0, heightModifier, 0);
            transform.localScale.Normalize();
            Debug.Log(transform.localScale);          
            
        }
	}

    
}
