using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private GameObject credit;

	void Start () {
        PlayerPrefs.SetInt("restarting", 0);
        PlayerPrefs.DeleteKey("PlayerAttack");
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.DeleteKey("PlayerMaxHealth");
        PlayerPrefs.DeleteKey("PlayerDefence");
        PlayerPrefs.DeleteKey("PlayerShield");

        credit = GameObject.Find("Credit");
        credit.SetActive(false);
    }
	
	void Update () {
		
	}

    public void play()
    {
        SceneManager.LoadSceneAsync("Level-1");
    }

    public void openCredit()
    {
        credit.SetActive(true);
    }

    public void closeCredit()
    {
        credit.SetActive(false);
    }

    public void exit()
    {
        Application.Quit();
    }
}
