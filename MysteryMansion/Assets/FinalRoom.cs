using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoom : MonoBehaviour {

    inputManager IM;

    public GameObject EndAnim;

	// Use this for initialization
	void Start () {
        IM = GameObject.FindObjectOfType<inputManager>();
        IM.UIelements.SetActive(false);
        IM.InventoryElements.SetActive(false);
        IM.InventoryButton.SetActive(false);
        EndAnim.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
