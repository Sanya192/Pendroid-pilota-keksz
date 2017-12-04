using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    //static Slider gravity;

    public Slider gravity;
    public Slider wind;
	// Use this for initialization
	void Start () {
        //gravity = FindObjectOfType<Slider>();

        gravity.onValueChanged.AddListener(delegate { GravityChange(); });
        wind.onValueChanged.AddListener(delegate { WindChange(); });
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

    void WindChange() {
        var windObject = GameObject.Find("WindSimulator").GetComponent<Wind>();
        windObject.WindSpeed = wind.value;
    }
}
