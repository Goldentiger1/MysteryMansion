using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class roomSwap : MonoBehaviour {

    public NavMeshAgent playerNav;

    public Vector3 destination;


	// Use this for initialization
	void Start () {
        playerNav = GameObject.Find("Player").GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            playerNav.nextPosition = destination;
        }
    }

}
