using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pianoFunction : MonoBehaviour {

    inputManager IM;

    public bool PianoReg = true;
    public bool PianoCard1 = false;
    public bool PianoCard2 = false;

    public void PianoRegi() {
        IM.HapAction();
        if (PianoReg) {
            IM.hapText.text = "The note doesn't sound right, somethings a little off.";
        } else if (PianoCard1) {
            IM.hapText.text = "The note  still doesn't sound quite right.";
        } else if (PianoCard2) {
            IM.hapText.text = "The note sounds in tune with the music box, and the fireplace has opened";
        }

    }

    public void MusicCard1() {
        PianoReg = false;
        PianoCard1 = true;
        PianoCard2 = false;
    }

	// Use this for initialization
	void Start () {
        IM = GameObject.FindObjectOfType<inputManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
