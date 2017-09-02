using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    
	void Start ()
    {
        PlayerPrefs.SetInt("restarting", 0);
        PlayerPrefs.DeleteKey("PlayerAttack");
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.DeleteKey("PlayerMaxHealth");
        PlayerPrefs.DeleteKey("PlayerDefence");
        PlayerPrefs.DeleteKey("PlayerShield");
    }
	void Update () {
		
	}

    public void restartGame()
    {
        SceneManager.LoadSceneAsync("Level-1", LoadSceneMode.Single);
    }

    public void mainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }

    public void playAgain()
    {
        SceneManager.LoadSceneAsync("Level-1", LoadSceneMode.Single);
    }

    public void exit()
    {
        Application.Quit();
    }
}
