using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inputManager : MonoBehaviour {
    
    public LayerMask ground;
    public LayerMask items;
    public LayerMask UI;

    public Canvas canv;

    public NavMeshAgent player;

    clickableObject selected;

    public GameObject Button;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject descBG;
    public GameObject LookImage;

    public Inventory pItems;

    public Text description;

    public bool isMoving;
    public bool isMovingToObject;


    // Use this for initialization
    void Start() {
        player = GameObject.Find("Protoplayer").GetComponent<NavMeshAgent>();
        canv = GameObject.FindObjectOfType<Canvas>();
        canv.enabled = false;
        //clickO = GetComponent<clickableObject>();
        Button = transform.FindDeepChild("UseButton").gameObject;
        Button1 = transform.FindDeepChild("LookButton").gameObject;
        Button2 = transform.FindDeepChild("TakeButton").gameObject;
        Button3 = transform.FindDeepChild("CloseButton").gameObject;
        descBG = transform.FindDeepChild("DescImage").gameObject;
        LookImage = transform.FindDeepChild("LookImage").gameObject;
        description = transform.FindDeepChild("Description").GetComponent<Text>();
        pItems = GameObject.FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update() {
        bool poke = false;
        Ray ray = new Ray();
        if (Input.GetKeyDown(KeyCode.Mouse0) && !IsPointerOverUIObject()) {
            poke = true;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // poke = true?
            // ray = ...
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            poke = true;
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            // sama touchille
        }
        if (!poke) {
            return;
        }
        // reagoidaan pokeen


        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, items)) {
            var co = hit.transform.GetComponent<clickableObject>();
            //print("Osui");
            if (co) {
                OpenClickableCanvas(co);
            }

        } else if (canv.enabled) {
            canv.enabled = false;
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground)) {
            player.destination = hit.point;
            isMoving = true;
        }

        
}

private bool IsPointerOverUIObject() {
    PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
    eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    List<RaycastResult> results = new List<RaycastResult>();
    EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
    return results.Count > 0;
}

//public void ObjectDescription () {
//    description.text = selected.objDescription;
//}

void OpenClickableCanvas(clickableObject c) {
        selected = c;
        canv.enabled = true;
        description.text = c.objDescription;
        if (c.useActionAvailable == true) {
            Button.SetActive(true);
        } else {
            Button.SetActive(false);
        }
        if (c.lookActionAvailable == true) {
            Button1.SetActive(true);
            
        } else {
            Button1.SetActive(false);
        }
        if (c.takeActionAvailable == true) {
            Button2.SetActive(true);
        } else {
            Button2.SetActive(false);
            //if (c.pickupPrefab) {
            //    Button2.SetActive(true);
            //} else {
            //    Button2.SetActive(false);
        }
        descBG.SetActive(true);
        Button3.SetActive(false);
        LookImage.SetActive(false);

    }

    public void UseAction() {
        print("Used " + selected.gameObject.name);
        selected.useAction.Invoke();
        canv.enabled = false;
    }

    public void TakeAction() {
        print("Took " + selected.gameObject.name);
        selected.takeAction.Invoke();
        canv.enabled = false;
        pItems.Pickup(selected.pickupPrefab);
        selected.gameObject.SetActive(false);
    }

    public void LookAction() {
        print("Looked at " + selected.gameObject.name);
        selected.lookAction.Invoke();
        LookImage.SetActive(true);
        var img = LookImage.GetComponentInChildren<Image>();
        img.sprite = selected.lookImage;
        Button.SetActive(false);
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(true);
        descBG.SetActive(false);
        
    }
    public void CloseAction() {
        canv.enabled = false;
        Button3.SetActive(false);
    }
}

