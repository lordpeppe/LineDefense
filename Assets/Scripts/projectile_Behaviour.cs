using UnityEngine;
using System.Collections;

public class projectile_Behaviour : MonoBehaviour {
    public float damage;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().takeDamage(damage);
            gameObject.SetActive(false);            
        }
    }
}
