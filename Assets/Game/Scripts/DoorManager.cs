using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {

    private float smoothing = 1f;
    public int keyRequired;
    public GameObject dice;

    private GameManager gameManager;
    private UIManager uiManager;

    void Start () {
        gameManager = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();
	}
	
	void Update () {
		
	}

    public void clicked()
    {
        if (gameManager.key < keyRequired) uiManager.showErrorText("Require " + keyRequired + " key(s)");
        else
        {
            gameManager.key -= keyRequired;
            uiManager.updateKeyText("Key : " + gameManager.key);
            uiManager.showErrorText("Door opened");
            if (gameManager.key == 0) dice.SetActive(true);
            StartCoroutine(movingUp());
        }
    }

    IEnumerator movingUp()
    {
        Vector3 target = new Vector3(transform.position.x, transform.position.y + 7f, transform.position.z);
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);

            yield return null;
        }

        print("Reached the target.");

        yield return new WaitForSeconds(3f);

        print("MyCoroutine is now finished.");
    }
}
