using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    private bool gazedAt = false;
    private Vector3 startingPosition;

    public Material inactiveMaterial;
    public Material gazedAtMaterial;

    void Start()
    {
        startingPosition = transform.localPosition;
        SetGazedAt(false);
    }
	
	void Update () {
        //if (gazedAt) GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        if (gazedAt) {
            Color temp = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = new Color(temp.r, temp.g, temp.b, Mathf.Lerp(0.5f, 1.0f, Mathf.PingPong(Time.time, 1)));
        }
    }

    public void SetGazedAt(bool gazedAt)
    {
        this.gazedAt = gazedAt;
        if(!gazedAt) GetComponent<Renderer>().material = inactiveMaterial;
        //if (inactiveMaterial != null && gazedAtMaterial != null)
        //{
        //    GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
        //    return;
        //}
        //GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
    }

    public void SetGazedAtChangeColor(bool gazedAt)
    {
        GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
    }
}
