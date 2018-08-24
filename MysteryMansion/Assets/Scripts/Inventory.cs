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

    public void Pickup(GameObject item) {
        for (int i = 0; i < ListSize;) {
            if(item != null) {
                ItemsList[i].
            }
        }
    }

}

