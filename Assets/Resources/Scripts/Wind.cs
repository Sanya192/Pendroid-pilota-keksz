using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Wind : MonoBehaviour {

    [Tooltip("WindSpeed between 0 and 250 (0 means no wind)")]
    [Range(0f,250f)]
    public float WindSpeed = 0f;

    void OnTriggerStay2D(Collider2D other) {
        other.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * WindSpeed * Time.deltaTime);
    }
}
