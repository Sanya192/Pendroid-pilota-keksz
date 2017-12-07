using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    public float startSpeed = 0.2f;
    void Start() {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * startSpeed;
    }

    /// <summary>
    /// OnBecameInvisible is called when the renderer is no longer visible by any camera.
    /// </summary>
    void OnBecameInvisible() {
        Destroy(gameObject);
    }

}
