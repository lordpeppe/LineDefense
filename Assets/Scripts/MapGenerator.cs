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
    int objectiveAmount;

	// Use this for initialization
	void Start () {
        objectives = new List<Objective>();
        if(!LoadMapFile("Assets/Resources/testmap.mp"))
        {
            Debug.Log("Text file could not be loaded");
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach(Objective o in objectives)
            {
                if (o.GetComponent<SpriteRenderer>().bounds.Contains(mousePos))
                {
                    Application.LoadLevel(o.Destination);
                }
            }
            

        }

	}

    void LoadObjective(Vector2 pos, string destScene)
    {
        Objective clone;
        clone = Instantiate(objPrefab, pos, Quaternion.identity) as Objective;
        clone.Init(destScene);
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
                       
                        Debug.Log(line);
                        entries = line.Split(' ');
                        if (entries.Length > 0)
                        {
                            switch (entries[0]){
                                case "objective":
                                    LoadObjective(new Vector2(float.Parse(entries[1]), float.Parse(entries[2])), entries[3]);
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
