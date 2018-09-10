using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPuzzle : MonoBehaviour {
    public List<GameObject> itemsPaintings;
    public List<GameObject> paintingsTransforms;
    public List<string> paintingsNames;
    public int paintingNumber;
    public int paintingNumberNew;

    void Start() {
        //itemsPaintings.AddRange(GameObject.FindGameObjectsWithTag("Paintings"));
        paintingsTransforms.AddRange(GameObject.FindGameObjectsWithTag("PaintingsPosition"));
        foreach (GameObject g in paintingsTransforms) {
            if(paintingNumber > 0) {
                paintingsNames.Add("Painting #" + (paintingNumber));
                paintingNumber -= 1;
            } else {
                break;
            }
            
        }
    }

    void Update() {
        //if (paintingsTransforms) {
        for (int i = 5; i <= paintingsTransforms.Count; i--) {
            //print(paintingsTransforms[i] + " = " + itemsPaintings[i]); // Debug print voi kommentoida pois.
            Puzzle(paintingsTransforms[i], itemsPaintings[i]);
        }
    }
    //}

    public void Puzzle(GameObject t, GameObject i) {
        if (t.transform.position == i.transform.position) {
            print("KAIKKI HYVIN");
        } else {
            print("JOKIN NYT EI OLE OIKEASSA PAIKASSA");
        }
    }

    public void TransformEmpty(int number, int numberNew) {
        foreach(string name in paintingsNames) {
            if(GameObject.Find(paintingsNames[number]) && number < numberNew) {

            }
        }
    }
}
