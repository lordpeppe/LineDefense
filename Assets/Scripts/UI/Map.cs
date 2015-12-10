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

    public void ActivateObjective(Objective obj)
    {   
        foreach (Objective o in objectives)
        {
            if (o.Equals(obj))
            {
                o.Active = true;
                break;
            }
        }
    }
    


}
