using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BGM : MonoBehaviour {

    public AudioClip winning;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (SceneManager.GetActiveScene().name.Equals("Level-21"))
        {
            GetComponent<AudioSource>().clip = winning;
            GetComponent<AudioSource>().Play();
        }
    }

    void Start () {
		
	}
	

	void Update () {
		
	}
}
