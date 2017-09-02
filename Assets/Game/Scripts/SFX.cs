using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour {

    public AudioClip itemTaken;
    public AudioClip walking;
    public AudioClip jump;
    public AudioClip attack;

    public void playItemTaken()
    {
        GetComponent<AudioSource>().PlayOneShot(itemTaken);
    }

    public void startWalking()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = walking;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        }
    }

    public void stopWalking()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void playJump()
    {
        GetComponent<AudioSource>().PlayOneShot(jump);
    }

    public void playAttack()
    {
        GetComponent<AudioSource>().PlayOneShot(attack);
    }

	void Start () {
		
	}
	
	void Update () {
		
	}
}
