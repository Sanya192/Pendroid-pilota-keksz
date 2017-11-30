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
        Physics.gravity = new Vector3(0,-9.8F*gravity.value,0);
        Debug.Log(Physics.gravity);
    }
}
