using UnityEngine;
using System.Collections.Generic;

public class ShipInventory : MonoBehaviour {

    struct Item
    {
        public Item(string name, GameObject itemPrefab) { this.name = name; this.itemPrefab = itemPrefab; }
        readonly string name;
        readonly GameObject itemPrefab;
    }

    Dictionary<string, Item> itemMap;

	// Use this for initialization
	void Start () {

        Item emptyItem = new Item("empty", new GameObject());
        

        itemMap = new Dictionary<string, Item>();
        itemMap.Add("weaponAmp1", emptyItem);
        itemMap.Add("weaponAmp2", emptyItem);
        itemMap.Add("weaponAmp3", emptyItem);
        itemMap.Add("shipAmp1", emptyItem);
        itemMap.Add("shipAmp2", emptyItem);
        itemMap.Add("shipAmp3", emptyItem);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
