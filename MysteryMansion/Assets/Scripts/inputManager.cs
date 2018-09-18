using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inputManager : MonoBehaviour {


    public Canvas canv;

    public enum UIstate { Normal, InventoryUsing, InventoryDragging }

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
    public GameObject dragIcon;

    public Inventory pItems;

    public LayerMask ground;
    public LayerMask intObjects;
    public LayerMask UI;

    public NavMeshAgent player;

    public Text description;
    public Text UseText;

    public UIstate currentstate;

    clickableObject selected;
    public inventoryItem inventorySelected;

    public void StartDrag() {
        //var DISprite = transform.FindDeepChild("InvItemImage").GetComponent<Image>().sprite;
        currentstate = UIstate.InventoryDragging;
        dragIcon.GetComponent<Image>().sprite = inventorySelected.itemSprite; //DISprite;
        dragIcon.SetActive(true);
    }

    public void InventoryItemDrag(inventoryItem dragItem) {
        if (currentstate != UIstate.InventoryDragging) {
            inventorySelected = dragItem;

            StartDrag();
        }
        //dragIcon = dragItem.gameObject;

        //dragIcon = transform.FindDeepChild("InvItemImage").gameObject;
        //var DISprite = transform.FindDeepChild("InvItemImage").GetComponent<Image>().sprite;
        //DISprite = dragItem.GetComponent<Image>().sprite;
        //dragIcon.GetComponent<Image>().sprite = dragItem.GetComponent<Image>().sprite;
        dragIcon.transform.position = Input.touchCount > 0 ?
                                            (Vector3)Input.GetTouch(0).position :
                                            Input.mousePosition;
    }

    public void InventoryItemSelected(inventoryItem item) {
        currentstate = UIstate.InventoryUsing;
        inventorySelected = item;
        print(item.gameObject.name);
        UseText.text = ("Use " + item.gameObject.name + " on what?");
    }

    void TryUseItem(inventoryItem item, clickableObject co) {

        foreach (var useEvent in item.useEvents) {
            //print(useEvent.target.gameObject.name);
            if (useEvent.target == co) {
                print("Used " + item.gameObject.name + " on " + co.gameObject.name);
                useEvent.reaction.Invoke();
                pItems.Remove(selected.gameObject);
                UseText.text = "";
                dragIcon.SetActive(false);
                return;
            }
        }
        dragIcon.SetActive(false);
        UseText.text = "Nothing happens.";
        print("Nothing happens.");
    }

    // Use this for initialization
    void Start() {
        dragIcon = transform.FindDeepChild("InvItemImage").gameObject;
        InventoryButton = transform.FindDeepChild("InventoryButton").gameObject;
        player = GameObject.Find("Protoplayer").GetComponent<NavMeshAgent>();
        canv = GameObject.FindObjectOfType<Canvas>();
        pItems = GameObject.FindObjectOfType<Inventory>();
        UIelements = transform.FindDeepChild("UIelements").gameObject;
        UIelements.SetActive(false);
        InventoryElements = transform.FindDeepChild("InventoryElements").gameObject;
        InventoryElements.SetActive(false);
        Button = transform.FindDeepChild("UseButton").gameObject;
        Button1 = transform.FindDeepChild("LookButton").gameObject;
        Button2 = transform.FindDeepChild("TakeButton").gameObject;
        Button3 = transform.FindDeepChild("CloseButton").gameObject;
        descBG = transform.FindDeepChild("DescImage").gameObject;
        LookImage = transform.FindDeepChild("LookImage").gameObject;
        description = transform.FindDeepChild("Description").GetComponent<Text>();
        UseText = transform.FindDeepChild("UText").GetComponent<Text>();
        Inventory = transform.FindDeepChild("Inventory").gameObject;
    }
    void CheckDragEnd() {
        bool endDragInput = false;
        Ray ray = new Ray();
        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            endDragInput = true;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            endDragInput = true;
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        }
        if (!endDragInput)
            return;
        if (endDragInput) {
            if (currentstate == UIstate.InventoryDragging) {
                RaycastHit hot;
                if (Physics.Raycast(ray, out hot, Mathf.Infinity, intObjects)) {
                    var co = hot.transform.GetComponent<clickableObject>();
                    TryUseItem(inventorySelected, co);
                }
                currentstate = UIstate.Normal;
                dragIcon.SetActive(false);
            }
        }

    }
    // Update is called once per frame
    void Update() {
        if (currentstate == UIstate.InventoryDragging) {
            if (Input.touchCount > 0) {
                dragIcon.transform.position = Input.GetTouch(0).position;
            } else {
                dragIcon.transform.position = Input.mousePosition;
            }
        }
        CheckDragEnd();
        Ray ray = new Ray();

        bool poke = false;
        if (Input.GetKeyDown(KeyCode.Mouse0) && !IsPointerOverUIObject(Input.mousePosition)) {
            poke = true;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !IsPointerOverUIObject(Input.GetTouch(0).position)) {
            poke = true;
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

        }
        if (!poke) {
            return;
        }



        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, intObjects)) {
            var co = hit.transform.GetComponent<clickableObject>();
            //print("Osui");
            if (co) {
                if (currentstate == UIstate.InventoryUsing) {
                    TryUseItem(inventorySelected, co);
                    currentstate = UIstate.Normal;
                } else {
                    OpenClickableCanvas(co);
                }
            }
        } else if (canv.enabled || InventoryElements) {
            currentstate = UIstate.Normal;

            UIelements.SetActive(false);
            InventoryElements.SetActive(false);
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground)) {
            player.destination = hit.point;
        }
    }

    private bool IsPointerOverUIObject(Vector2 position) {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = position;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    void OpenClickableCanvas(clickableObject c) {
        selected = c;
        description.text = c.objDescription;
        UIelements.SetActive(true);
        InventoryElements.SetActive(false);
        canv.enabled = true;
        if (c.useActionAvailable) {
            Button.SetActive(true);
        } else {
            Button.SetActive(false);
        }
        if (c.lookActionAvailable) {
            Button1.SetActive(true);

        } else {
            Button1.SetActive(false);
        }
        if (c.takeActionAvailable) {
            Button2.SetActive(true);
        } else {
            Button2.SetActive(false);
        }
        descBG.SetActive(true);
        Button3.SetActive(false);
        LookImage.SetActive(false);

    }

    public void InventoryAction() {
        InventoryElements.SetActive(!InventoryElements.activeSelf);
        UIelements.SetActive(false);
        UseText.text = "";
        if (!InventoryElements.activeSelf) {
            currentstate = UIstate.Normal;
        }
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

