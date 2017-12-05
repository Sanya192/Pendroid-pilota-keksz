using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    private bool hasUsedParachute = false;

    static Slider gravitySlider;
    static Slider windSlider;

    static Button parachuteBtn;
    // Use this for initialization
    void Start() {
        var sliders = FindObjectsOfType<Slider>();
        gravitySlider = sliders.First(P => P.name == "GravitySlider");
        windSlider = sliders.First(P => P.name == "WindSlider");

        gravitySlider.onValueChanged.AddListener(delegate { GravityChange(); });
        windSlider.onValueChanged.AddListener(delegate { WindChange(); });

        var btns = FindObjectsOfType<Button>();
        parachuteBtn = btns.First(p => p.name == "ParachuteButton");

        parachuteBtn.onClick.AddListener(delegate { UseParachute(); });
    }

    void GravityChange() {
        var ball = GameObject.FindGameObjectsWithTag("Ball");
        Physics2D.gravity = new Vector2(0, -9.8F * gravitySlider.value);
        Debug.Log(Physics2D.gravity);
        for (int i = 0; i < ball.Length; i++) {
            ball[i].GetComponent<Rigidbody2D>().Sleep();
        }
    }

    void WindChange() {
        var windObject = GameObject.Find("WindSimulator").GetComponent<Wind>();
        windObject.WindSpeed = windSlider.value;
    }

    void UseParachute() {
        var launcher = GameObject.Find("Launcher").GetComponent<Launcher>();
        if (launcher.FlyingBall != null && !hasUsedParachute) {
            launcher.FlyingBall.UseParachute();
            hasUsedParachute = true;
        }

    }
}
