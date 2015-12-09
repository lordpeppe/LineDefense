using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Objective : MonoBehaviour {
    
    private string destinationLevel;
    private bool active;
    private string objName;

    [SerializeField]
    List<Sprite> sprites;

    public string Name
    {
        get { return objName; }
    }

    public Objective Next
    {
        get; set;
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
    

    public void Init(string dest, bool act, Objective next, string name)
    {
        destinationLevel = dest;

        active = act;
        if (active)
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        else
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        this.Next = next;
        gameObject.name = name;
    }
    
    
    

}
