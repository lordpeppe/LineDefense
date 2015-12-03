using UnityEngine;
using System.Collections;

public class HQ : MonoBehaviour {
    
	[SerializeField]
	private float initHealth;
    
	private float currentHealth;

	void Start () {
        gameObject.SetActive(true);
        currentHealth = initHealth;
 
	}
	
	void Update () {
        if (IsDestroyed())
        {
            gameObject.SetActive(false);
        }
        
    }

  public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    bool IsDestroyed()
    {
		return currentHealth <= 0;
    }
    
    
}
