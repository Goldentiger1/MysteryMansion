using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class roomSwap : MonoBehaviour {

    CursorMode cursorMode = CursorMode.ForceSoftware;

    public NavMeshAgent playerNav;

    public Transform destination;

    //public Camera mainCam;
    //public Camera bgCam;
    //public Camera nextMainCam;
    //public Camera nextBgCam;

    public LayerMask rooms;

    //public List<Texture2D> cursorWalk;
    public Texture2D cursorNormal;

    RoomData room;

    public Vector2 hotSpot;

    inputManager IM;

    //public List<Camera> cameras;


    public void Awake() {
        rooms = 1 << LayerMask.NameToLayer("Rooms");
        var r = Physics.OverlapSphere(transform.position, 1f, rooms);
        room = r[0].GetComponent<RoomData>();
        
    }

    // Use this for initialization
    void Start() {
        playerNav = GameObject.Find("Protoplayer").GetComponent<NavMeshAgent>();
        IM = GameObject.FindObjectOfType<inputManager>();
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnMouseOver() {
        IM.CursorWalk();
    }

    private void OnMouseExit() {
        Cursor.SetCursor(cursorNormal, hotSpot, cursorMode);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
                playerNav.Warp(destination.position);
            room.ExitRoom();
            var r = Physics.OverlapSphere(destination.position, 1f, rooms);
            r[0].GetComponent<RoomData>().EnterRoom();
            //mainCam.enabled = false;
            //bgCam.enabled = false;
            //nextMainCam.enabled = true;
            //nextBgCam.enabled = true;
            //var camOff = Scene.FindObjectOfType<Camera>().enabled = false;
            }
        }
    }


