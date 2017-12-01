using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    static Slider gravity;
	// Use this for initialization
	void Start () {
        gravity = FindObjectOfType<Slider>();
        gravity.onValueChanged.AddListener(delegate { GravityChange(); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void GravityChange(){
        var ball = GameObject.FindGameObjectsWithTag("Ball");
        Physics2D.gravity = new Vector2(0,-9.8F*gravity.value);
        Debug.Log(Physics2D.gravity);
        for (int i = 0; i < ball.Length; i++) {
             ball[i].GetComponent<Rigidbody2D>().Sleep();
            
        }
    }
}
