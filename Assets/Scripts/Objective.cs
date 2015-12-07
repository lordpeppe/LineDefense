using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Objective : MonoBehaviour {
    
    private string destinationLevel;
    private bool active;
    private string next;
    private string objName;

    [SerializeField]
    List<Sprite> sprites;

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
        set { active = value; }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    

    public void Init(string dest, string act, string next, string name)
    {
        destinationLevel = dest;

        if (act.Equals("act")) active = true;
        else active = false;
        if (active)
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        else
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        this.next = next;
        gameObject.name = name;
    }
    
    
    

}
