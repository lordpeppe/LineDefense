using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float despawnTime;

    [SerializeField]
    private bool despawnOnHit;


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            if(despawnOnHit)
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