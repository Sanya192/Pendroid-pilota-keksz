using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {

    // Use this for initialization
    void Awake() {
        //if (SceneManager.GetActiveScene().name=="game_over") {
        Invoke("Load", 2f);
        
           // UI.Reset();
        //}
        // GameObject.FindObjectOfType<UI>().Reset();
        //Invoke("LoadMenuScene", 2f);
    }

    void LoadMenuScene() {
        new WaitForSeconds(3);

       // SceneManager.LoadScene("menu");
    }
    void Load()
    {
        Debug.Log(UI.deathPos);
        SceneManager.LoadScene(UI.deathPos);
    }
}