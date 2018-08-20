using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour {
    public LayerMask itemLM;
    public Text dbText; // Debug purpose
    Inventory item;

    void Update() {
        /*
        if (Input.touchCount > 0) {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            // Osuiko raycast johonkin?
            dbText.text = "asdlf";
            Debug.DrawRay(ray.origin, Vector3.forward * 100, Color.red);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                hit.collider.gameObject.SetActive(false);
            }
        }
        */


            // Onko näytöllä sormia?
            if (Input.touchCount > 0) {
            foreach (Touch finger in Input.touches) {
                // Kun sormi on näytöllä
                if (Input.GetTouch(finger.fingerId).phase == TouchPhase.Began) {                    
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(finger.fingerId).position);
                    RaycastHit hit;
                    // Osuiko raycast johonkin?
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, itemLM)) {
                        //hit.collider.gameObject.SetActive(false);
                        Pickup(item.pickupItem, hit);
                        if (item.pickupItem == null) {
                            dbText.text = 0.ToString();//debug purpose
                        } else {
                            dbText.text = 1.ToString();
                        }
                        
                    }
                }
            }
        }
    }


    public void Pickup(GameObject item, RaycastHit hit) {
        item = hit.transform.gameObject;
    }
}
