using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour {
    [HideInInspector] public inventoryItem item;

    inputManager IM;

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
