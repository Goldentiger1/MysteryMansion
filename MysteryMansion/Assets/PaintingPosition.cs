using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPosition : MonoBehaviour {

    public int PaintPositionID;

    public PaintingPuzzle puzzle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlacePainting(inventoryItem invItem) {
        puzzle.PaintingInsert(invItem, PaintPositionID);
    }
}
