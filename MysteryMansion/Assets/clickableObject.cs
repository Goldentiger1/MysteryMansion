﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickableObject : MonoBehaviour {

    public Canvas canv;

    public LayerMask items;

	// Use this for initialization
	void Start () {
        canv = GameObject.FindObjectOfType<Canvas>();
        canv.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(ray, out hit, Mathf.Infinity, items)) {
            print("Osui");
            canv.enabled = true;
        }
	}

    //void OnMouseDown() {
    //        print("hei, toimii");
    //        canv.enabled = true;
    //}
}
