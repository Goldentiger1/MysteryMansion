using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UseEvent {
    public clickableObject target;
    public UnityEngine.Events.UnityEvent reaction;
}


public class inventoryItem : MonoBehaviour {

    public Sprite itemSprite;

    public List<UseEvent> useEvents;

	// Use this for initialization
	void Start () {
		
	}
	
    public void LibDoor() {
    //Fabric.EventManager.Instance.PostEvent("Door");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
