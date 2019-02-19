using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {

    // Use this for initialization
    void Start() {
        if (SceneManager.GetActiveScene().name=="game_over") {
           // UI.Reset();
        }
        // GameObject.FindObjectOfType<UI>().Reset();
        Invoke("LoadMenuScene", 2f);
    }

    void LoadMenuScene() {
        SceneManager.LoadScene("menu");
    }
}