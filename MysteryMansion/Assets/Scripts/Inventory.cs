using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public int ListSize;
    public List<GameObject> ItemsList = new List<GameObject>();
    public List<Button> InventoryList = new List<Button>();

    void Start() {
        ItemsList.Capacity = ListSize;
        InventoryList.Capacity = ListSize;
    }

    void Update() {
    }



    public void Pickup(GameObject pickupItem) {
        if(pickupItem != null) {
            ItemsList.Add(pickupItem);
        }
    }

}

