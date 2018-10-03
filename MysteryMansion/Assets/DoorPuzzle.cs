using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : MonoBehaviour {

    public bool boardsDestroyed = false;
    public bool lockOpened = false;

    public void Boards() {
        boardsDestroyed = true;
    }

    public void Lock() {
        lockOpened = true;
    }

    public void Update() {
        if (boardsDestroyed && lockOpened) {
            Destroy(GameObject.Find("DoorPuzzler"));
        }
    }
}
