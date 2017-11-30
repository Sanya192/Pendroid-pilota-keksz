using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(BoxCollider2D))]
public class Target : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name.IndexOf("Ball")>=0)
            Destroy(gameObject);

    }
}
