using UnityEngine;
using System.Collections;

public class HQ : MonoBehaviour {
    public float initHealth;
    private float currentHealth;
	// Use this for initialization
	void Start () {
        gameObject.SetActive(true);
        currentHealth = initHealth;
 
	}
	
	// Update is called once per frame
	void Update () {
        if (isDestroyed())
        {
            gameObject.SetActive(false);
        }
        
    }

  public  void takeDamage(float damage)
    {
        currentHealth -= damage;
    }

    bool isDestroyed()
    {
        if (currentHealth <= 0)
        {
            return true;
        }
        else return false;
    }
    
    
}
