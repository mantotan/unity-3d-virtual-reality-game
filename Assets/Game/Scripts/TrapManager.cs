using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapManager : MonoBehaviour {
    
    public int dropToLevel = 1;
    private bool dropSnake = false;

	void Start () {
		
	}
	
	void Update () {
        if (dropSnake)
        {
            transform.GetChild(0).transform.position = Vector3.MoveTowards(transform.GetChild(0).transform.position, transform.position, 5f * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            //other.GetComponent<PlayerMovement>().gravity = 1000;
            //GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");
            //for (int i = 0; i < floors.Length; i++) floors[i].GetComponent<MeshCollider>().enabled = false;
            dropSnake = true;
            FindObjectOfType<PlayerStatus>().saveStatus();
            PlayerPrefs.SetInt("restarting", 1);
            Invoke("DropLevel", 2.0f);
        }
    }

    public void DropLevel()
    {
        SceneManager.LoadSceneAsync("Level-" + dropToLevel, LoadSceneMode.Single);
    }
}
