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

    CursorMode cursormode = CursorMode.ForceSoftware;

    public string objDescription;

    public float frameTimer = 0.5f;
    public float frameT = 0f;

    public GameObject pickupPrefab;

    public Sprite lookImage;

    public List <Texture2D> cursorUse;
    public Texture2D cursorNormal;

    public UnityEvent useAction;
    public UnityEvent takeAction;
    public UnityEvent lookAction;

    public Vector2 hotSpot;

    inputManager IM;

    public void DisableUseAction() {
        useActionAvailable = false;
    }
    // Use this for initialization

    private void OnMouseEnter() {
        frameT = frameT + Time.deltaTime;
        for (int i = 0; i < cursorUse.Count; i++) {
            if (frameT >= frameTimer) {
                Cursor.SetCursor(cursorUse[i], hotSpot, cursormode);
                frameT = 0;
            }
        }
    }

    private void OnMouseExit() {
        Cursor.SetCursor(cursorNormal, hotSpot, cursormode);
    }

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