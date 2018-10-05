using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaintingPosition : MonoBehaviour {

    public int PaintPositionID;

    public PaintingPuzzle puzzle;

    clickableObject co;

    inputManager IM;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlacePainting(inventoryItem invItem) {
        puzzle.PaintingInsert(invItem, PaintPositionID);
    }

    //public void PaintingRemove (inventoryItem invItem) {
    //    puzzle.PaintingRemove(invItem, PaintPositionID);
    //}
}
