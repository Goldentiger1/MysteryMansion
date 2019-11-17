using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

    public float timeWait;

    void Update() {
        if(timeWait <= 0) {
            //Fabric.EventManager.Instance.PostEvent("Stop");
            SceneManager.LoadScene("MainMenu");
        } else {
            timeWait -= Time.deltaTime;
        }
    }

}
