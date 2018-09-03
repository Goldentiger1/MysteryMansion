using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class clickableObject : MonoBehaviour {

    //public Canvas canv;

    //public LayerMask items;

    public bool useActionAvailable;
    public bool takeActionAvailable;
    public bool lookActionAvailable;

    public string objDescription;

    public GameObject pickupPrefab;

    public Sprite lookImage;

    public UnityEvent useAction;
    public UnityEvent takeAction;
    public UnityEvent lookAction;

    

    // Use this for initialization
    void Start() { 
    }
    //canv = GameObject.FindObjectOfType<Canvas>();
    //canv.enabled = false;

    // Update is called once per frame
    void Update() {
        //RaycastHit hit;
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(ray, out hit, Mathf.Infinity, items)) {
        //    print("Osui");
        //    canv.enabled = true;
        //}
    }
}