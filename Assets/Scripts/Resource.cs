using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Resource { 
    List<Rigidbody2D> resourcePool;
    int resourceIndex;
    int amount;

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

   public Rigidbody2D getNext()
    {
        if (resourceIndex < amount - 1)
        {
            resourceIndex++;
        } else
        {
            resourceIndex = 0;
        }
        return resourcePool[resourceIndex];
    }


}
