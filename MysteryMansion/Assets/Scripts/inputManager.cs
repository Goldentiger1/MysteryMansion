﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class inputManager : MonoBehaviour {

    public LayerMask ground;
    public LayerMask items;
    public LayerMask UI;

    public Canvas canv;

    public NavMeshAgent player;

    //clickableObject clickO;

    public GameObject Button;
    public GameObject Button1;
    public GameObject Button2;


    // Use this for initialization
    void Start() {
        player = GameObject.Find("Protoplayer").GetComponent<NavMeshAgent>();
        canv = GameObject.FindObjectOfType<Canvas>();
        canv.enabled = false;
        //clickO = GetComponent<clickableObject>();
        Button = GameObject.Find("UseButton");
        Button1 = GameObject.Find("LookButton");
        Button2 = GameObject.Find("TakeButton");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground)) {
                player.destination = hit.point;
            }
        }
        var roy = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hot;
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (Physics.Raycast(roy, out hot, Mathf.Infinity, items)) {
                var co = hot.transform.GetComponent<clickableObject>();
                print("Osui");
                if (co) {
                    OpenClickableCanvas(co);
                }

            } else if (canv.enabled) {
                canv.enabled = false;
            }
        }
    }

    void OpenClickableCanvas(clickableObject c) {
        canv.enabled = true;
        if (c.useActionAvailable == true) {
            Button.SetActive(true);
        } else {
            Button.SetActive(false);
        }
        if (c.lookActionAvailable == true) {
            Button1.SetActive(true);
        } else {
            Button1.SetActive(false);
        }
        if (c.takeActionAvailable == true) {
            Button2.SetActive(true);
        } else {
            Button2.SetActive(false);
        }

    }
}

