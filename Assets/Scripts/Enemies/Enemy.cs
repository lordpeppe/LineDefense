﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour
{
	protected string enemyTag;

	[SerializeField]
    protected float speed;
    [SerializeField]
	protected float initHealth;
	[SerializeField]
	protected float damage;

	[SerializeField]
	protected GameObject xpText;

    protected float currentHealth;
    
	protected int xp;

    void Start()
    {
        currentHealth = initHealth;
    }

    protected void Move(float x, float y)
    {
        Vector3 temp = new Vector3(x - transform.position.x, y - transform.position.y, 0);
        temp *= (speed / temp.magnitude) ;
        transform.position += temp * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
    }

    protected bool IsDestroyed()
    {
		return currentHealth <= 0;
    }

    public void ResetHealth()
    {
        currentHealth = initHealth;
    }
}
