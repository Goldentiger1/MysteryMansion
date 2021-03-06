﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pianoFunction : MonoBehaviour {

    inputManager IM;

    public bool PianoReg = true;
    public bool PianoCard1 = false;
    public bool PianoCard2 = false;

    public GameObject Pianokey;
    public BoxCollider FireplaceCollider;
    public Sprite FireClose;
    public Sprite FireOpen;

    public void PianoRegi() {
        IM.HapAction();
        if (PianoReg) {
            //Fabric.EventManager.Instance.PostEvent("Piano1");
            //Fabric.EventManager.Instance.PostEvent("Pause");
            IM.hapText.text = "The music doesn't sound right, it's missing something.";
        } else if (PianoCard1) {
            //Fabric.EventManager.Instance.PostEvent("Pause");
            //Fabric.EventManager.Instance.PostEvent("Piano2");
            IM.hapText.text = "The music still doesn't sound quite right, the note's a little off.";
        } else if (PianoCard2) {
            //Fabric.EventManager.Instance.PostEvent("Pause");
            //Fabric.EventManager.Instance.PostEvent("Piano3");
            IM.hapText.text = "The piano sounds in tune with the music box, and the fireplace has opened";
            FireplaceCollider.enabled = false;
            Pianokey.SetActive(true);
            GameObject.FindGameObjectWithTag("OseSpecial").gameObject.GetComponent<SpriteRenderer>().sprite = FireOpen;
            //FireClose = FireOpen;
        }

    }

    public void MusicBox1() {
        //Fabric.EventManager.Instance.PostEvent("Pause");
        //Fabric.EventManager.Instance.PostEvent("Musicbox");
    }

    public void MusicCard1() {
        PianoReg = false;
        PianoCard1 = true;
        PianoCard2 = false;
    }

    public void MusicCard2() {
        PianoReg = false;
        PianoCard1 = false;
        PianoCard2 = true;
    }

	// Use this for initialization
	void Start () {
        FireClose = GameObject.FindGameObjectWithTag("OseSpecial").gameObject.GetComponent<SpriteRenderer>().sprite;
        //FireOpen = transform.FindDeepChild("Takka").gameObject.GetComponent<SpriteRenderer>().sprite;

        Pianokey.SetActive(false);
        IM = GameObject.FindObjectOfType<inputManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
