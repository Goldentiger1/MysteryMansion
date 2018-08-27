using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public int ListSize = 5;
    public Text dbText; // DEBUG PURPOSE
    public List<GameObject> ItemsList;
    public List<Button> InventoryList;

    public void Pickup(GameObject item) {
        for (int i = 0; i < ListSize; i++) {
            if (item == null) {
                ItemsList[i] = item;
                dbText.text = "Item has been added to inventory!!!"; // DEBUG PURPOSE
                InventoryList[i].enabled = true;
                return;
            }
        }
    }
}

