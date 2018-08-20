﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class roomSwap : MonoBehaviour {

    public NavMeshAgent playerNav;

    public Transform destination;

    public Camera mainCam;
    public Camera bgCam;
    public Camera nextMainCam;
    public Camera nextBgCam;

    //public List<Camera> cameras;


    // Use this for initialization
    void Start () {
        playerNav = GameObject.Find("Protoplayer").GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
                playerNav.Warp(destination.position);
            mainCam.enabled = false;
            bgCam.enabled = false;
            nextMainCam.enabled = true;
            nextBgCam.enabled = true;
            //var camOff = Scene.FindObjectOfType<Camera>().enabled = false;
            }
        }
    }


