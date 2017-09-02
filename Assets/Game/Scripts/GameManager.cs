using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int key = 0;

	void Start () {
        
	}
	
	void Update () {
        detectPressedKeyOrButton();
    }

    public void detectPressedKeyOrButton()
    {
        //if(Input.GetKeyDown(KeyCode.X)) GameObject.Find("Dice").GetComponent<DiceManager>().roll();
        //foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        //{
        //    if (Input.GetKeyDown(kcode))
        //        GameObject.Find("InfoText").GetComponent<Text>().text = kcode + "";
        //}
    }
}
