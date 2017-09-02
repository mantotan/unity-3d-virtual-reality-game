using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
    
	void Start () {

	}
	
	void Update () {
		
	}

    public void attack()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        Invoke("finishedAttack", 1f);
    }

    public void finishedAttack()
    {
        GetComponent<Animator>().SetBool("Attack", false);
    }
}
