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
    

    int objectiveAmount;
    void Start()
    {
        objectives = new List<Objective>();
        if(!LoadMapFile("Assets/Resources/testmap.mp"))
        {
            Debug.Log("Text file could not be loaded");
        }
        
	}
    

    void Update () {
	    
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach(Objective o in objectives)
            {
                if (o.GetComponent<SpriteRenderer>().bounds.Contains(mousePos) && o.Active)
                {
                    Application.LoadLevel(o.Destination);
                }
            }
        }
	}

    void LoadObjective(Vector2 pos, string destScene, string active, string next, string name)
    {
        Objective clone;
        clone = Instantiate(objPrefab, pos, Quaternion.identity) as Objective;
        clone.Init(destScene, active, next, name);
        objectives.Add(clone);
    }

    void LoadCurPos(Vector2 pos)
    {
        GameObject clone = Instantiate(curPosPrefab, pos, Quaternion.identity) as GameObject;
    }

    bool LoadMapFile(string fileName)
    {
        string[] entries;
        try {
            string line;
            StreamReader reader = new StreamReader(fileName, Encoding.Default);
            
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
                                    LoadObjective(new Vector2(float.Parse(entries[1]), float.Parse(entries[2])), entries[3], entries[4], entries[5], entries[6]);
                                    break;
                                case "curpos":
                                    LoadCurPos(new Vector2(float.Parse(entries[1]), float.Parse(entries[2])));
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                } while (line != null);
                reader.Close();
                return true;
            }
        } catch (IOException e)
        {
            Debug.Log(e.Message);
            return false;
        }
    }
    

}
