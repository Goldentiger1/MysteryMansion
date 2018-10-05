using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemButton : MonoBehaviour, IDragHandler {
    [HideInInspector] public inventoryItem item;    

    inputManager IM;

    public void OnDrag(PointerEventData eventData) {
        print("Dragaa");
        IM.InventoryItemDrag(item);
    }

    // Use this for initialization
    void Start () {
        IM = GameObject.FindObjectOfType<inputManager>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ButtonClicked() {
        IM.InventoryItemSelected(item);

    }


}
