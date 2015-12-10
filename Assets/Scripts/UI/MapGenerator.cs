using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class MapGenerator : MonoBehaviour {


    List<Objective> objectives;

    [SerializeField]
    Objective objPrefab;

    [SerializeField]
    GameObject curPosPrefab;

    [SerializeField]
    Material lineMat;

    Map activeMap;
    Vector2 curPos;



    int objectiveAmount;
    
	void Start()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
        objectives = new List<Objective>();
        
        if (LevelManager.levelManager.ActiveMap == null)
        {
            activeMap = GenerateMap();
            LevelManager.levelManager.SetMap(activeMap);
        }
        else
        {
            LoadMap(LevelManager.levelManager.ActiveMap);
        }

        
    }

    Map GenerateMap()
    {
        int counter = 0;
        bool first = true;
        List<Objective> objectiveList = new List<Objective>();
        for (int i = -7; i <= 7; i += 2)
            for (int j = -4; j <= 4; j += 2)
            {
                if (Random.Range(0, 10) > 7)
                {
                    objectiveList.Add(LoadObjective(new Vector2(1f * i, -1f * j), "scene1", first, null, "obj" + counter++));
                    first = false;
                }
            }

        for(int i = 0; i < objectiveList.Count - 1; i++)
        {
            objectiveList[i].Next = GameObject.Find(objectiveList[i + 1].name).GetComponent<Objective>(); 
        }

        return new Map(objectiveList, new Vector2(-2.0f, 0f));
    }
    

    void Update () 
	{
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach(Objective o in objectives)
            {
                if (o.GetComponent<SpriteRenderer>().bounds.Contains(mousePos) && o.Active)
                {
                    LevelManager.levelManager.SetLevelAndLoad(o);
                }
            }
        }
	}
    

    Objective LoadObjective(Vector2 pos, string destScene, bool active, Objective next, string name)
    {
        Objective clone;
        clone = Instantiate(objPrefab, pos, Quaternion.identity) as Objective;
        clone.Init(destScene, active, next, name);
        objectives.Add(clone);

        return clone;
    }

    Vector2 LoadCurPos(Vector2 pos)
    {
        GameObject clone = Instantiate(curPosPrefab, pos, Quaternion.identity) as GameObject;

        return pos;
    }

    void LoadMap(Map map)
    {
        foreach (Objective o in map.Objectives)
        {
            if(o.Active)
            {
                LoadObjective(o.transform.position, o.Destination, true, o.Next, o.name);
            } else
            {
                LoadObjective(o.transform.position, o.Destination, false, o.Next, o.name);
            }
        }

        LoadCurPos(map.CurPos);
    }
    
}
