using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour {


    void Update() {
        if(Input.touchCount > 0) {
            foreach(Touch finger in Input.touches) {
                if(Input.GetTouch(finger.fingerId).phase == TouchPhase.Began) {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(finger.fingerId).position);
                }
            }
        }
    }


    public void Pickup() {

    }
}
