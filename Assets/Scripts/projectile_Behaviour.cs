using UnityEngine;
using System.Collections;

public class projectile_Behaviour : MonoBehaviour {
    public float damage;
    public float despawnTime;


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

    public void Despawner()
    {
        StartCoroutine(Despawn());
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(despawnTime);
        gameObject.SetActive(false);
    }
}
