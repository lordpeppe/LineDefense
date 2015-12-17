using UnityEngine;
using System.Collections.Generic;
using System;

public class ShipInventory : MonoBehaviour {

    [SerializeField]
    GameObject ship;

    
    Dictionary<ItemSlot, Item> itemMap;

    public enum ItemSlot {
        PROJECTILE, GUN, SHIELD, NONE
    }

    struct Item
    {
        public Item(string name, GameObject itemPrefab, ItemSlot type) { this.name = name; this.itemPrefab = itemPrefab; this.type = type; }
        public readonly string name;
        public readonly GameObject itemPrefab;
        public readonly ItemSlot type;
    }


	// Use this for initialization
	void Start () {

        Item emptyItem = new Item("empty", new GameObject(), ItemSlot.NONE);

        itemMap = new Dictionary<ItemSlot, Item>();
	}
	
	// Update is called once per frame
	void Update () {

       
        
	}

    void SwitchItem(ItemSlot slot, Item newItem)
    {
        if(!newItem.type.Equals(slot) || !newItem.type.Equals(ItemSlot.NONE)) { return; }

        if(itemMap[slot].itemPrefab)
        {
            Destroy(itemMap[slot].itemPrefab);
        }

        itemMap[slot] = newItem;
        Instantiate(newItem.itemPrefab, ship.transform.position, Quaternion.identity);

    }


}
