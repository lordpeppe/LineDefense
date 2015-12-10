using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour 
{
	[SerializeField]
	private int health;

	[SerializeField]
	private float damageCoolDownTime;

	public float Health { get { return health; } }

	private bool InCoolDown { get; set; }

	void Start () 
	{
		InCoolDown = false;
	}
	
	void Update () 
	{
		if (health <= 0)
			Application.LoadLevel ("FlyingDeath");
	}
		
	void OnCollisionEnter2D(Collision2D other)
	{
		if (!InCoolDown && other.gameObject.tag == "Enemy")
		{
			health -= 5;

		}
	}

	IEnumerator StartCoolDown()
	{
		InCoolDown = true;
		yield return new WaitForSeconds (damageCoolDownTime);
		InCoolDown = false;
	}

}
