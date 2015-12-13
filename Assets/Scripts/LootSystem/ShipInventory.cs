using UnityEngine;
using System.Collections.Generic;

public class ShipInventory : MonoBehaviour {


    enum ItemSlot {
        PROJECTILE, GUN, SHIELD, NONE
    }

    struct Item
    {
        public Item(string name, GameObject itemPrefab, ItemSlot type) { this.name = name; this.itemPrefab = itemPrefab; this.type = type; }
        readonly string name;
        public readonly GameObject itemPrefab;
        public readonly ItemSlot type;
    }

    Dictionary<ItemSlot, Item> itemMap;

	// Use this for initialization
	void Start () {

        Item emptyItem = new Item("empty", new GameObject(), ItemSlot.NONE);

        itemMap = new Dictionary<ItemSlot, Item>();
        itemMap.Add(ItemSlot.PROJECTILE, emptyItem);
        itemMap.Add(ItemSlot.GUN, emptyItem);
        itemMap.Add(ItemSlot.SHIELD, emptyItem);
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
    }


}
