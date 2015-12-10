using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Resource
{

    private List<Rigidbody2D> resourcePool;
    private int resourceIndex = 0;
    private int amount;

    public Resource(Rigidbody2D prefab, int amount, Vector3 position)
    {
        this.amount = amount;

        resourcePool = new List<Rigidbody2D>();

        for (int i = 0; i <= amount; i++)
        {
            Rigidbody2D resource;
            resource = GameObject.Instantiate(prefab, position, Quaternion.identity) as Rigidbody2D;
            resourcePool.Add(resource);
            resource.gameObject.SetActive(false);
        }
    }

<<<<<<< HEAD:Assets/Scripts/Util/Resource.cs
    public Rigidbody2D GetNext()
=======
   public Rigidbody2D GetNext()
>>>>>>> 97570b7decc2625570b25b67193885b4515292be:Assets/Scripts/Resource.cs
    {
        if (resourceIndex < amount - 1)
        {
            resourceIndex++;
        }
        else
        {
            resourceIndex = 0;
        }
        return resourcePool[resourceIndex];
    }


}
