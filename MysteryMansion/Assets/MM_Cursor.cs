using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_Cursor : MonoBehaviour {

    CursorMode cursorMode = CursorMode.ForceSoftware;

    float frameT = 0;
    float frameTimer = 0.1f;
    int currentCursorFrame = 0;

    public Texture2D cursNormal;
    public List<Texture2D> cursUse;
    public List<Texture2D> cursWalk;

    public Vector2 hotSpot;


    public void CursorUse() {
        frameT = frameT + Time.deltaTime;
        if (frameT >= frameTimer) {
            currentCursorFrame++;
            currentCursorFrame %= cursUse.Count;
            Cursor.SetCursor(cursUse[currentCursorFrame], hotSpot, cursorMode);
            frameT = 0;
        }
    }

    public void CursorWalk() {
        frameT = frameT + Time.deltaTime;
        if (frameT >= frameTimer) {
            currentCursorFrame++;
            currentCursorFrame %= cursWalk.Count;
            Cursor.SetCursor(cursWalk[currentCursorFrame], hotSpot, cursorMode);
            frameT = 0;
        }
    }

    private void Start() {
        Cursor.SetCursor(cursNormal, hotSpot, cursorMode);
    }
}
