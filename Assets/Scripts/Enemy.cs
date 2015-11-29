using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	[SerializeField]
    private float speed;
    [SerializeField]
	private float initHealth;
    [SerializeField]
	private float currentHealth;
    [SerializeField]
	private float damage;

    void Start()
    {
        currentHealth = initHealth;
    }

    void Update()
    {
        if (!IsDestroyed())
        {
            Move(-5.74f , -1.08f);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Move(float HQX, float HQY)
    {
        
        Vector3 temp = new Vector3(HQX - transform.position.x, HQY - transform.position.y, 0);
        temp *= (speed / temp.magnitude);
        transform.position += temp;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    bool IsDestroyed()
    {
        if (currentHealth <= 0)
        {
            return true;
        }
        else return false;
    }

    public void ResetHealth()
    {
        currentHealth = initHealth;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "HQ")
        {
            other.gameObject.GetComponent<HQ>().takeDamage(damage);
            gameObject.SetActive(false);

        }
    }
}
