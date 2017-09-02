using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

    bool isRotating = true;

	void Start () {
        GetComponent<Rigidbody>().useGravity = false;
	}

    void Update()
    {
        if (isRotating) transform.Rotate(Vector3.down * 50 * Time.deltaTime, Space.World);
    }

    public void roll()
    {
        isRotating = false;
        GetComponent<Rigidbody>().useGravity = true;

        GetComponent<Rigidbody>().AddForce(new Vector3(randomForce(), 15f, -0.1f), ForceMode.Impulse);
        GetComponent<Rigidbody>().AddTorque(new Vector3(randomForce(), randomForce(), randomForce()), ForceMode.Impulse);

        Invoke("setKey", 2f);
    }

    float randomForce()
    {
        return Random.Range(-7.5f, 7.5f);
    }

    public void setKey()
    {
        print("set key");
        RaycastHit hit;
        Vector3[] directions = { Vector3.back, Vector3.up, Vector3.right, Vector3.left, Vector3.down, Vector3.forward };
        for (int i = 0; i < directions.Length; i++)
        {
            Vector3 dir = transform.TransformDirection(directions[i]);
            if (Physics.Raycast(transform.position, dir, out hit, 1.0f))
            {
                if (hit.transform.tag == "Floor")
                {
                    print(i + 1);
                    int newKey = i + 1;
                    FindObjectOfType<GameManager>().key += newKey;
                    FindObjectOfType<UIManager>().updateKeyText("Key : " + FindObjectOfType<GameManager>().key);
                }
            }
        }

        Destroy(gameObject);
    }
}
