using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody player;

   

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown)

	}
}
