using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {

    public int attack;
    public int def;
    public int health;

    private TextMesh monsterHP;

	void Start () {
        monsterHP = gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        if(monsterHP !=null) monsterHP.text = health + "";
	}
	
	void Update () {
		
	}

    public void damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            monsterHP.text = "0";
            GetComponent<Animator>().SetBool("Death", true);
            Destroy(gameObject, 3f);
        }
        else
        {
            monsterHP.text = health + "";
        }
    }
}
