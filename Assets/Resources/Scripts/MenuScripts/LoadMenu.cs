using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Invoke("LoadMenuScene", 1f);
    }

    void LoadMenuScene() {
        SceneManager.LoadScene("Game");
    }
}