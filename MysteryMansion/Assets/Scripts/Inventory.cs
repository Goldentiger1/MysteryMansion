﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    //public Text dbText; // DEBUG PURPOSE
    public List<GameObject> ItemsList;
    public List<Button> InventoryList;

    public void Pickup(GameObject item) {
        ItemsList.Add(item);
        //dbText.text = "BOOP!"; // DEBUG PURPOSE



        //item.GetComponent<ItemScript /*Lisää tähän kerättävän gameobjektin Skripti*/>();


        /*
        itemImages[i].sprite = itemToAdd.sprite;
        itemImages[i].enabled = true;
        */

        return;
    }
}

