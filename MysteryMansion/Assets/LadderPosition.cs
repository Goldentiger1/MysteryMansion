using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderPosition : MonoBehaviour {

    public int LadderPosID;

    public LadderSpot spot;

    clickableObject co;

    inputManager IM;

    public void PlaceLadder (inventoryItem item) {
        spot.LadderSetup(item, LadderPosID);
    }
}
