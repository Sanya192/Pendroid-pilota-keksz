using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    static Slider gravitySlider;
    static Slider windSlider;
    static Button parachuteBtn;
    static GameObject Pause;
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
        Pause = GameObject.Find("Pause");
        Pause.SetActive(false);
        //  Invoke("InvertAllMaterialColors", 0.01f);
    }
    void Update(){
        if (Input.GetButtonDown("Pause")){
            TriggerPause();
        }
    }
    void GravityChange() {
        var ball = GameObject.FindGameObjectsWithTag("Ball");
        Physics2D.gravity = new Vector2(0, -9.8F * gravitySlider.value);
        Debug.Log(Physics2D.gravity);
        for (int i = 0; i < ball.Length; i++) {
            if(!ball[i].GetComponent<Ball>().physicsEnabled)
            ball[i].GetComponent<Rigidbody2D>().Sleep();
        }
    }
    void WindChange() {
        var windObject = GameObject.Find("WindSimulator").GetComponent<Wind>();
        windObject.WindSpeed = windSlider.value;
    }
    void UseParachute() {
        var launcher = GameObject.Find("Launcher").GetComponent<Launcher>();
        if (launcher.FlyingBall != null) {
            launcher.FlyingBall.UseParachute();
            parachuteBtn.enabled = false;
            SoundManager.Instance
                .PlayOneShot(SoundManager.Instance.OpenParachute);
            Destroy(parachuteBtn.gameObject);
        }
    }
    Color InvertColor(Color color){
    return new Color(1.0f-color.r, 1.0f-color.g, 1.0f-color.b);
    }
    void InvertAllMaterialColors(){
        var renderers = FindObjectsOfType<Renderer>();
        foreach (var render in renderers) {
            Debug.Log(render);
            if (render.material.HasProperty("_Color")) {
                render.material.color = InvertColor(render.material.color);
            }
        }
    }
    public  void TriggerGameOver(){
        SceneManager.LoadScene("game_over");
    }
    public  void ToMainMenu(){
        SceneManager.LoadScene("menu");
    }
   public  void ToEndGame(){
        Application.Quit();
    }
    public void TriggerPause(){

        if (Time.timeScale == 1) {
            Pause.SetActive(true);
            Time.timeScale = 0;
        }
        else {
            Pause.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
