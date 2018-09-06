using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    //public Text dbText; // DEBUG PURPOSE
    public List<GameObject> ItemsList;
    //public List<GameObject> InventoryList;

    public Transform itemsContainer;

    public GameObject buttonPrefab;

    void Start() {
        itemsContainer = GameObject.Find("ItemsContainer").transform;
    }

    void Update() {
    
    }

    void InventoryRefresh() {
        var n = itemsContainer.childCount;
        for (int i = 0; i < n; i++) {
            Destroy(itemsContainer.GetChild(i).gameObject);
        }
        foreach (var item in ItemsList) {
            var invItem = item.GetComponent<inventoryItem>();
           var button = Instantiate(buttonPrefab, itemsContainer.transform);
            button.GetComponent<Image>().sprite = invItem.itemSprite;
            button.GetComponent<ItemButton>().item = invItem;
        }

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

