using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    //public Text dbText; // DEBUG PURPOSE
    public List<GameObject> ItemsList;
    public List<GameObject> InventoryList;

    public GameObject itemsContainer;

    public GameObject buttonPrefab;

    void Start() {
        itemsContainer = GameObject.Find("ItemsContainer");
    }

    void Update() {
    
    }

    void InventoryRefresh() {
        // tyhjennä InventoryUI
        //ItemsList.

        // käy itemit ItemsLististä läpi
        foreach (var item in ItemsList) {
            var invItem = item.GetComponent<inventoryItem>();
           var button = Instantiate(buttonPrefab, itemsContainer.transform);
            button.GetComponent<Image>().sprite = invItem.itemSprite;
        }
        // luo nappi jokaiselle itemille ItemsListissä

        // aseta oikea sprite oikealle napille mitä luodaan
        // aseta oikealle napille oikeat toiminnot
    }

    public void Pickup(GameObject item) {
        ItemsList.Add(item);
        InventoryRefresh();
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

