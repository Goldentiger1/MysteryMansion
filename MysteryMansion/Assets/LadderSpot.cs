using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderSpot : MonoBehaviour {

    public List<LadderObject> LadderVisual;

    public List<Transform> LadderPosit;

    public List<inventoryItem> placedLadder;

    inputManager IM;
    Inventory pItems;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LadderSetup(inventoryItem item, int ladPos) {
        placedLadder[ladPos] = item;
        foreach (var ladder in LadderVisual) {
            if (ladder.ladder == item) {
                ladder.gameObject.SetActive(true);
                //ladder.transform.position = LadderPosit[ladPos].position;
               // ladder.transform.rotation = LadderPosit[ladPos].rotation;
            }
            //ladder.
            //item.gameObject.SetActive(true);
            //item.transform.position = .transform.position;
            //item.transform.rotation = gameObject.transform.rotation;
        }
    }

}
