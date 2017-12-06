using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public void LoadSceneImmediately(string name) {
        SceneManager.LoadScene(name);
    }
}
