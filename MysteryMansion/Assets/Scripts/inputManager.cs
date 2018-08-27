using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class inputManager : MonoBehaviour {

    public LayerMask ground;
    public LayerMask items;
    public LayerMask UI;

    public Canvas canv;

    public NavMeshAgent player;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Protoplayer").GetComponent<NavMeshAgent>();
        canv = GameObject.FindObjectOfType<Canvas>();
        canv.enabled = false;
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(roy, out hot, Mathf.Infinity, items)) {
            print("Osui");
            canv.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(roy, out hot, Mathf.Infinity, UI)) {

        }
    }
}
