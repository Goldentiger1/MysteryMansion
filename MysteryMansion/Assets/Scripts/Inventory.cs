using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public int ListSize;
    public Text dbText; // DEBUG PURPOSE
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
                ItemsList[i] = item;
                dbText.text = "Item has been added to inventory!!!"; // DEBUG PURPOSE
                item = null;
                i++;
            }else if(i >= ListSize) {
                
            }
        }
    }

}

