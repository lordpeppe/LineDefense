﻿using UnityEngine;
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

	string resourcePath = "Assets/Resources/";

    int objectiveAmount;
    
	void Start()
    {
        objectives = new List<Objective>();
        if(!LoadMapFile("testmap.mp"))
        {
            Debug.Log("Text file could not be loaded");
        }

        if (!SaveMapFile(objectives, new Vector2(0, 0), "test.mp"))
        {
            Debug.Log("Text file could not be saved");
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
                    Application.LoadLevel(o.Destination);
                }
            }
        }
	}

	void OnGUI()
	{
		
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
