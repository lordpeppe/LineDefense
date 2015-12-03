using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {
    
    private string destinationLevel;
    private bool active;
    private string next;
    private string objName;

    public string Name
    {
        get { return objName; }
    }

    public string Next
    {
        get { return next; }
    }

    public string Destination
    {
        get { return destinationLevel; }
    }

    public bool Active
    {
        get { return active; }
    }
    
	void Start () {
	
	}
	
	void Update () {
	
        if(Input.GetKeyDown("n"))
        {
            Application.LoadLevel(destinationLevel);
        }
	}

    public void Init(string dest, string act, string next, string name)
    {
        destinationLevel = dest;

        if (act.Equals("act")) active = true;
        else active = false;
        this.next = next;
        gameObject.name = name;
    }
    
    

}
