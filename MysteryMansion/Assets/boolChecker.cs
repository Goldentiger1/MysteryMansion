using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boolChecker : MonoBehaviour {

    public clickableObject clickO;

    Canvas canv;

    public GameObject Button;
    public GameObject Button1;
    public GameObject Button2;

    // Use this for initialization
    void Start() {
        clickO = FindObjectOfType<clickableObject>();
        canv = GameObject.FindObjectOfType<Canvas>();
        Button = GameObject.Find("UseButton");
        Button1 = GameObject.Find("LookButton");
        Button2 = GameObject.Find("TakeButton");
        if (clickO.useActionAvailable == true) {
            Button.SetActive(true);
        } else {
            Button.SetActive(false);
        }
        if (clickO.lookActionAvailable == true) {
            Button1.SetActive(true);
        } else {
            Button1.SetActive(false);
        }
        if (clickO.takeActionAvailable == true) {
            Button2.SetActive(true);
        } else {
            Button2.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
        
    }
}
