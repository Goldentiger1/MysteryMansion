using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeFunction : MonoBehaviour {

    public GameObject GlobeNote;

    inputManager IM;

	// Use this for initialization
	void Start () {
        IM = GameObject.FindObjectOfType<inputManager>();
        GlobeNote.SetActive(false);
	}
	
    public void GlobeClick() {
        GlobeNote.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
