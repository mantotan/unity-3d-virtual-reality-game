using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour {

    Enemy parent;

	void Start () {
        parent = transform.parent.GetComponent<Enemy>();
	}
	
	void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            parent.player = other.gameObject;
            parent.inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            parent.inRange = false;
        }
    }
}
