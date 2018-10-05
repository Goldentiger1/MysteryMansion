using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapInterface : MonoBehaviour {
    public GameObject map;
    public List<GameObject> roomsImages = new List<GameObject>();

    void Start() {
        map = GameObject.Find("Map");
    }

    public void RoomChange(Image room) {

    }
}
