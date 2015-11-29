using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {
    
    private string destinationLevel;

    public string Destination
    {
        get { return destinationLevel; }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyDown("n"))
        {
            Application.LoadLevel(destinationLevel);
        }
        

	}

    public void Init(string dest)
    {
        destinationLevel = dest;
    }
    

}
