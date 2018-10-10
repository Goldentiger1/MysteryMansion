﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEnable : MonoBehaviour {

    public FinalRoom FR;
    public BackToMenu BM;

    public LayerMask player;

    public void OnTriggerEnter(Collider other) {
        FR.enabled = true;
        BM.enabled = true;
        }
    }
