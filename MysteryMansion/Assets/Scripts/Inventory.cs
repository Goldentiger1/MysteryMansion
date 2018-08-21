using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public GameObject pickupItem;
    public int ListSize;
    public List<GameObject> ItemsList = new List<GameObject>();
    public List<Button> InventoryList = new List<Button>();

    void Start() {
        ItemsList.Capacity = ListSize;
        InventoryList.Capacity = ListSize;
    }

    void Update() {
        ItemsList.Add(pickupItem);
        pickupItem = null;
        //foreach(GameObject item in ItemsList) {

        //}
    }
}

