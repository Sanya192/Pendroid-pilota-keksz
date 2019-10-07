using UnityEngine;
using UnityEngine.SceneManagement;

public class Ground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D coll){
       if( coll.gameObject.GetComponent<Ball>().last&&!UI.victory) {

            UI.Triggergameover();
            //SceneManager.LoadScene("game_over");
            //UI.Reset();

        }
    }
}
