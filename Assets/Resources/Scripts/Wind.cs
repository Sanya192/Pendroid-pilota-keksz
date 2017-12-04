using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Wind : MonoBehaviour {

    public float WindSpeed = 50f;

    void OnTriggerStay2D(Collider2D other) {
        other.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * WindSpeed * Time.deltaTime);
    }
}
