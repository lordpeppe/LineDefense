using UnityEngine;
using System.Collections;

[AddComponentMenu("Level/Flying Level Status")]
public class FlyingLevelStatus : MonoBehaviour {
	
	private float distance;

	[SerializeField]
	private float totalDistance;

	public float PercentOfDistance { get { return distance / totalDistance; } }

	void Start () 
	{
		StartCoroutine (Count ());
	}
	
	void Update () 
	{
		if (distance >= totalDistance) 
		{
			/* Level ended or boss reached? */
			Debug.Log ("Level ended");
		}
	}

	IEnumerator Count()
	{
		yield return new WaitForSeconds (0.5f);

		if (distance < totalDistance) 
		{
			distance += 1;
			StartCoroutine (Count ());
		}
	}
}
