using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private TextMesh keyText, errorText;

	void Start () {
        keyText = GameObject.Find("KeyText").GetComponent<TextMesh>();
        errorText = GameObject.Find("ErrorText").GetComponent<TextMesh>();
        errorText.text = "";
	}
	
	void Update () {
		
	}

    public void updateKeyText(string str)
    {
        keyText.text = str;
    }

    public void showErrorText(string error)
    {
        errorText.text = error;
        Invoke("HideErrorText", 2f);
    }

    public void HideErrorText()
    {
        errorText.text = "";
    }
}
