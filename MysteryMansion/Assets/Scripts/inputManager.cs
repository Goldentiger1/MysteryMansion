using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inputManager : MonoBehaviour {
    
    public LayerMask ground;
    public LayerMask intObjects;
    public LayerMask UI;

    public Canvas canv;

    public NavMeshAgent player;

    clickableObject selected;

    public GameObject Button;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject InventoryButton;
    public GameObject descBG;
    public GameObject LookImage;
    public GameObject Inventory;
    public GameObject UIelements;
    public GameObject InventoryElements;

    public Inventory pItems;

    public Text description;

    public bool isMoving;
    public bool isMovingToObject;


    // Use this for initialization
    void Start() {
        InventoryButton = transform.FindDeepChild("InventoryButton").gameObject;
        player = GameObject.Find("Protoplayer").GetComponent<NavMeshAgent>();
        canv = GameObject.FindObjectOfType<Canvas>();
        pItems = GameObject.FindObjectOfType<Inventory>();
        UIelements = transform.FindDeepChild("UIelements").gameObject;
        UIelements.SetActive(false);
        InventoryElements = transform.FindDeepChild("InventoryElements").gameObject;
        InventoryElements.SetActive(false);
        //clickO = GetComponent<clickableObject>();
        Button = transform.FindDeepChild("UseButton").gameObject;
        Button1 = transform.FindDeepChild("LookButton").gameObject;
        Button2 = transform.FindDeepChild("TakeButton").gameObject;
        Button3 = transform.FindDeepChild("CloseButton").gameObject;
        descBG = transform.FindDeepChild("DescImage").gameObject;
        LookImage = transform.FindDeepChild("LookImage").gameObject;
        description = transform.FindDeepChild("Description").GetComponent<Text>();
        Inventory = transform.FindDeepChild("Inventory").gameObject;
    }

    // Update is called once per frame
    void Update() {
        bool poke = false;
        Ray ray = new Ray();
        if (Input.GetKeyDown(KeyCode.Mouse0) && !IsPointerOverUIObject(Input.mousePosition)) {
            poke = true;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // poke = true?
            // ray = ...
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !IsPointerOverUIObject(Input.GetTouch(0).position)) {
            poke = true;
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            // sama touchille
        }
        if (!poke) {
            return;
        }
        // reagoidaan pokeen


        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, intObjects)) {
            var co = hit.transform.GetComponent<clickableObject>();
            //print("Osui");
            if (co) {
                OpenClickableCanvas(co);
            }
        } else if (canv.enabled || InventoryElements == true) {
            UIelements.SetActive(false);
            InventoryElements.SetActive(false);
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground)) {
            player.destination = hit.point;
            isMoving = true;
        }

        
}

private bool IsPointerOverUIObject(Vector2 position) {
    PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = position;
    List<RaycastResult> results = new List<RaycastResult>();
    EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
    return results.Count > 0;
}

//public void ObjectDescription () {
//    description.text = selected.objDescription;
//}

void OpenClickableCanvas(clickableObject c) {
        selected = c;
        description.text = c.objDescription;
        UIelements.SetActive(true);
        canv.enabled = true;
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

    public void InventoryAction() {
        InventoryElements.SetActive(true);
    }

    public void UseAction() {
        print("Used " + selected.gameObject.name);
        selected.useAction.Invoke();
        UIelements.SetActive(false);

    }

    public void TakeAction() {
        print("Took " + selected.gameObject.name);
        selected.takeAction.Invoke();
        UIelements.SetActive(false);
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
        UIelements.SetActive(false);
        Button3.SetActive(false);
    }
}

