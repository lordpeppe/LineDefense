using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	protected string enemyTag;

	[SerializeField]
    protected float speed;
    [SerializeField]
	private float initHealth;
	[SerializeField]
	private float damage;

    private float currentHealth;
    

    void Start()
    {
        currentHealth = initHealth;
    }

    protected void Move(float HQX, float HQY)
    {
        Vector3 temp = new Vector3(HQX - transform.position.x, HQY - transform.position.y, 0);
        temp *= (speed / temp.magnitude) ;
        transform.position += temp * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    protected bool IsDestroyed()
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
            other.gameObject.GetComponent<HQ>().TakeDamage(damage);
            gameObject.SetActive(false);

        }
    }
}
