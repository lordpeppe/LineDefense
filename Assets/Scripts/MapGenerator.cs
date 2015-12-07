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

	string resourcePath = "Assets/Resources/";

    int objectiveAmount;
    
	void Start()
    {
        
        objectives = new List<Objective>();
        
        if (LevelManager.levelManager.ActiveMap == null)
        {
            activeMap = LoadMapFile("testmap.mp");
            LevelManager.levelManager.SetMap(activeMap);
        }
        else
        {
            LoadMap(LevelManager.levelManager.ActiveMap);
        }

        
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
    

    Objective LoadObjective(Vector2 pos, string destScene, string active, string next, string name)
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
                LoadObjective(o.transform.position, o.Destination, "act", o.Next, o.name);
            } else
            {
                LoadObjective(o.transform.position, o.Destination, "inact", o.Next, o.name);
            }
        }

        LoadCurPos(map.CurPos);
    }

    Map LoadMapFile(string fileName)
    {
        string[] entries;
        try {
            string line;
            StreamReader reader = new StreamReader(resourcePath + fileName, Encoding.Default);
            
            using (reader)
            {
                do
                {
                    line = reader.ReadLine();

                    if(line != null)
                    {
                        entries = line.Split(' ');
                        if (entries.Length > 0)
                        {
                            switch (entries[0]){
                                case "objective":
                                    objectives.Add(LoadObjective(new Vector2(float.Parse(entries[1]), float.Parse(entries[2])), entries[3], entries[4], entries[5], entries[6]));
                                    break;
                                case "curpos":
                                    curPos = LoadCurPos(new Vector2(float.Parse(entries[1]), float.Parse(entries[2])));
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                } while (line != null);
                reader.Close();

                Map activeMap = new Map(objectives, curPos);

                return activeMap;
            }
        } catch (IOException e)
        {
            Debug.Log(e.Message);
            return null;
        }
    }

    bool SaveMapFile(List<Objective> objectiveList, Vector2 curPos, string fileName)
    {

        try
        {

            StreamWriter writer = new StreamWriter(resourcePath + fileName);

            foreach(Objective o in objectiveList)
            {
                writer.WriteLine(stringFromObjective(o.transform.position,o.Active,o.Next,o.name));
            }

            writer.WriteLine("curPos " + curPos.x + " " + curPos.y);

            writer.Close();
            return true;

        } catch (IOException e)
        {
            Debug.Log(e.Message);
            return false;
        }
    }
    
    private string stringFromObjective(Vector2 pos, bool active, string next, string name)
    {
        string act = active ? "act" : "inact";
        string res = "objective " + pos.x + " " + pos.y + " " + act + " " + next + " " + name;
        return res;
    }

}
