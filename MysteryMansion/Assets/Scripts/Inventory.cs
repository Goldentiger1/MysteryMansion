using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    //public Text dbText; // DEBUG PURPOSE
    public List<GameObject> ItemsList;
    public List<GameObject> InventoryList;

    public GameObject itemsContainer;

    public Sprite item1;

    void Start() {
        itemsContainer = GameObject.Find("ItemsContainer");
        item1 = GameObject.Find("Item 1").GetComponent<Image>().sprite;
    }

    void Update() {
    
    }

    public void Pickup(GameObject item) {
        ItemsList.Add(item);
        //foreach (var items in ItemsList) {
        //    InventoryList.Add(items);
        //}
        //print ("BOOP!"); // DEBUG PURPOSE

                //return;
    }

    public void Remove(GameObject item) {
        ItemsList.Remove(item);
        //item.SetActive(false);
    }

}

