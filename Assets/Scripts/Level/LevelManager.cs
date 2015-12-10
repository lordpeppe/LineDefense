using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public static LevelManager levelManager;

	public GameObject canvas;
    public Objective CurObjective { get; set; }
	/* Playe data */
	public int GoldCoins { get; set; }
    public Map ActiveMap { get; set; }

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

    public void ReloadMap(string map)
    {
        Application.LoadLevel(map);
        foreach(Objective o in levelManager.ActiveMap.Objectives)
        {
            o.gameObject.SetActive(true);
        }
    }

    public void SetMap(Map map)
    {
        levelManager.ActiveMap = map;
    }

    public void SetLevelAndLoad(Objective obj)
    {
        Application.LoadLevel(obj.Destination);
        CurObjective = obj;
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("objective"))
        {
            go.SetActive(false);
        }
    }
}
