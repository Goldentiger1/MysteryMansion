using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : MonoBehaviour {

    public Sprite FinalOpen;

    public bool boardsDestroyed = false;
    public bool lockOpened = false;

    public GameObject FinalTeleport;

    public void Start() {
        FinalTeleport.SetActive(false);
    }

    public void Boards() {
        boardsDestroyed = true;
    }

    public void Lock() {
        lockOpened = true;
    }

    public void Update() {
        if (boardsDestroyed && lockOpened) {
            Destroy(GameObject.Find("DoorPuzzler"));
            FinalTeleport.SetActive(true);
            Fabric.EventManager.Instance.PostEvent("Pause");
            Fabric.EventManager.Instance.PostEvent("Whoosh");
            GameObject.FindGameObjectWithTag("LastDoor").gameObject.GetComponent<SpriteRenderer>().sprite = FinalOpen;

        }
    }
}
