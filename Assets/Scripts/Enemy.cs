using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float initHealth;
    private float currentHealth;
    public float damage;


    // Use this for initialization
    void Start()
    {
        currentHealth = initHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed())
        {
            move(-5.74f , -1.08f);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }

    void move(float HQX, float HQY)
    {
        
        Vector3 temp = new Vector3(HQX - transform.position.x, HQY - transform.position.y, 0);
        temp *= (speed / temp.magnitude) ;
        transform.position += temp;
    }

    public void takeDamage(float damage)
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

    public void resetHealth()
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
