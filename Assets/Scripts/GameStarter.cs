using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour 
{
	
	void Start () 
	{
		StartCoroutine (RestartLevel ());
	}
	
	void Update () 
	{
	
	}

	IEnumerator RestartLevel()
	{
		yield return new WaitForSeconds (2f);
		Application.LoadLevel ("Scroller");
	}
}
