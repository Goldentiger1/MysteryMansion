using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour {

    public Camera[] cameras;


    public void Awake() {
        cameras = GetComponentsInChildren<Camera>();
        foreach (var cam in cameras) {
            cam.enabled = false;
        }
    }

    public void EnterRoom() {
        print("entered " + gameObject.name);
        foreach (var cam in cameras) {
            cam.enabled = true;
        }
    }

    public void ExitRoom() {
        foreach (var cam in cameras) {
            cam.enabled = false;
        }
    }
}
