using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private TextMesh levelText;

	void Start () {
        levelText = GameObject.Find("LevelText").GetComponent<TextMesh>();
        if(PlayerPrefs.GetInt("restarting", 0) == 1)
        {
            GameObject[] powerUps = GameObject.FindGameObjectsWithTag("PowerUp");
            for(int i=0; i<powerUps.Length; i++)
            {
                powerUps[i].SetActive(false);
            }
        }
        levelText.text = SceneManager.GetActiveScene().name.Replace('-', ' ');
    }
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.GetComponent<PlayerStatus>().saveStatus();
            int currentString = int.Parse(SceneManager.GetActiveScene().name.Split('-')[1]);
            SceneManager.LoadSceneAsync("Level-"+(currentString+1), LoadSceneMode.Single);
        }
    }
}
