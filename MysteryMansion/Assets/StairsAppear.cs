using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsAppear : MonoBehaviour {

    public LayerMask Player;

    inputManager IM;

    // Use this for initialization
    void Start() {
        IM = FindObjectOfType<inputManager>();
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Protoplayer") {
            print("osui triggeriin");
            IM.HapAction();
            IM.hapText.text = "Would you look at that, the slide has turned into a set of stairs!";
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Protoplayer") {
            print("poistui triggeristä");
            Destroy(gameObject);
        }
    }
}
