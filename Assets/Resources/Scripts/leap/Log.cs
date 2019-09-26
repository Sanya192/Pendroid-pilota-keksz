using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Leap;
using LeapInternal;
using TMPro;

public class Log : MonoBehaviour {

    public static Controller controller;
    Vector3 first;
    TextMeshProUGUI[] firstha;
	// Use this for initialization
	void Start () {
        controller = new Controller(25);
        first = new Vector3();
        firstha = new TextMeshProUGUI[3];
        
        var temp = GameObject.FindGameObjectsWithTag("txt");
        for (int i = 0; i < 3; i++)
        {
            firstha[i] = temp[i].GetComponent<TextMeshProUGUI>();
        }
        
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //Debug.Log(controller.Frame(0).Hands.Count +" " +controller.Frame(0).Hands[0].Fingers.Count());

        if (controller.Frame(0).Hands.Count>0&& controller.Frame(0).Hands[0].Fingers.Count>0)
        {
            var temp = controller.Frame(0).Hands[0].Fingers[1].TipPosition;
            first = new Vector3(temp.x, temp.y, temp.z);
            firstha[0].text = temp.z.ToString();
            firstha[1].text = temp.y.ToString();
            firstha[2].text = temp.x.ToString();

            /*
            Debug.Log(controller.Frame(0).Hands[0].Fingers[0].TipPosition);
            Debug.Log(controller.Frame(0).Hands[0].Fingers[0].TipPosition.y);
            Debug.Log(controller.Frame(0).Hands[0].Fingers[0].TipPosition.z);
            */
        }
        else
        {
            firstha[0].text = "-1";
        }




    }
}
