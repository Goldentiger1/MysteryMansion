using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Start() {
        //Fabric.EventManager.Instance.PostEvent("MainMenu");
    }

    void Update() {

    }

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Fabric.EventManager.Instance.PostEvent("Stop");
    }

    public void QuitGame() {
        print("QuitGame!");
        Application.Quit();
    }
}
