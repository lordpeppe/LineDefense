using UnityEngine;
using System.Collections.Generic;

public class GunWrapper : MonoBehaviour {

	[SerializeField]
	private bool shooterAreDeactived = false;
    [SerializeField]
    private KeyCode shoot;

	[SerializeField]
	private GameObject laserBeam;

    [SerializeField]
    List<AbstractShooter> shotList;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (shoot)) 
		{
			if (!shooterAreDeactived) 
			{
				foreach (AbstractShooter sh in shotList) 
				{
					sh.Shoot ();
				}
			}
		} 

	}

}
