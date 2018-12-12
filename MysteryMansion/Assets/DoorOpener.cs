using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

    public LayerMask Player;

    inputManager IM;

	// Use this for initialization
	void Start () {
        IM = FindObjectOfType<inputManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Protoplayer") {
            print("osui triggeriin");
            IM.HapAction();
            IM.hapText.text = "Wait a minute.. That door on the right, wasn't it closed earlier?";
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Protoplayer") {
            print("poistui triggeristä");
            Destroy(gameObject);
        }
    }
}
