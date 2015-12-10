using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour {

	[SerializeField]
	private string pathName;

	void Start () 
	{
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "time", 10, "easetype", iTween.EaseType.linear));
	}

	void Update () 
	{
	
	}
}
