using UnityEngine;
using System.Collections.Generic;

public class GunWrapper : MonoBehaviour {


    [SerializeField]
    private KeyCode shoot;

    [SerializeField]
    List<AbstractShooter> shotList;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(shoot))
        {
            foreach (AbstractShooter sh in shotList)
            {
                sh.Shoot();
            }
        }

	}
}
