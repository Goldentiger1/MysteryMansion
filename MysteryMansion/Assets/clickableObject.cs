using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickableObject : MonoBehaviour {

    public Canvas canv;

	// Use this for initialization
	void Start () {
        canv = GameObject.FindObjectOfType<Canvas>();
        canv.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            print("hei, toimii");
            canv.enabled = true;
        }
    }
}
