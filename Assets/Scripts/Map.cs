using UnityEngine;
using System.Collections.Generic;

public class Map  {

    List<Objective> objectives;
    public List<Objective> Objectives { get { return objectives; } }

    Vector2 curPos;
    public Vector2 CurPos { get { return curPos; } }


    public Map(List<Objective> objectiveList, Vector2 initPos)
    {
        objectives = objectiveList;
        curPos = initPos;
    }

    public void ActivateObjective(string name)
    {
        List<Objective> temp = new List<Objective>();
        
        foreach (Objective o in objectives)
        {

            if (o.name.Equals(name))
            {
                o.Active = true;
                break;
            }
        }
    }
    


}
