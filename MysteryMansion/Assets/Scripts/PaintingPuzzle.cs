using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPuzzle : MonoBehaviour {
    //public List<GameObject> itemsPaintings;
    public List<Transform> paintingsTransforms;

    public List<PaintingObject> paintingVisuals;

    public List<inventoryItem> placedPaintings;

    //public List<string> paintingsNames;
    //public int paintingNumber;
    //public int paintingNumberNew;

    void Start() {
        //itemsPaintings.AddRange(GameObject.FindGameObjectsWithTag("Paintings"));
        //paintingsTransforms.AddRange(GameObject.FindGameObjectsWithTag("PaintingsPosition"));
        //foreach (GameObject g in paintingsTransforms) {
        //    if(paintingNumber > 0) {
        //        paintingsNames.Add("Painting #" + (paintingNumber));
        //        paintingNumber -= 1;
        //    } else {
        //        break;
        //    }
        //}
    }

    void Update() {
        //foreach(string name in paintingsNames) {
           // if(GameObject.Find(paintingsNames[paintingNumber])) {
                //itemsPaintings.Add(GameObject.Find(paintingsNames[paintingNumber]));
                //paintingNumberNew = itemsPaintings.Count;
            }//else if()
        

        /*
                for (int i = 5; i <= paintingsTransforms.Count; i--) {
                    //print(paintingsTransforms[i] + " = " + itemsPaintings[i]); // Debug print voi kommentoida pois.
                    Puzzle(paintingsTransforms[i], itemsPaintings[i]);
                }
            }
        }
    }
    */
    

    public void PaintingInsert(inventoryItem item, int PosID) {
        print("Placing " + item.gameObject.name + " into position " + PosID);
        // merkkaa muistiin sijoitettu objekti oikealle paikalle
        placedPaintings[PosID] = item;
        // käännä itemiä vastaava quad päälle
        // siirrä quad oikean paikan transformin paikalle
        foreach (var po in paintingVisuals) {
            if (po.item == item) {
                po.gameObject.SetActive(true);
                po.transform.position = paintingsTransforms[PosID].position;
                po.transform.rotation = paintingsTransforms[PosID].rotation;
                //var poPic = item.GetComponent<Sprite>();
                //poPic = item.GetComponentInChildren<Sprite>();
                po.transform.FindDeepChild("New Sprite").GetComponent<SpriteRenderer>().sprite = item.itemSprite;
            }
        }

        // tarkista onko puzzlen ratkaisu oikein
    }

    public void Puzzle(GameObject t, GameObject i) {
        if (t.transform.position == i.transform.position) {
            print("KAIKKI HYVIN");
        } else {
            print("JOKIN NYT EI OLE OIKEASSA PAIKASSA");
        }
    }
}
