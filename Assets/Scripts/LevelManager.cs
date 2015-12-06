using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public static LevelManager levelManager;

	/* Playe data */
	public int GoldCoins { get; set; }

	void Awake ()
	{
		if (levelManager == null) 
		{
			GoldCoins = 100;
			DontDestroyOnLoad (gameObject);
			levelManager = this;
		} 
		else if(levelManager != this)
		{
			Destroy (gameObject);
		}
	}
	
	void Update () 
	{
	
	}
}
