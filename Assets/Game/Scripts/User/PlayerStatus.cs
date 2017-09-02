using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public int attack = 2;
    public int health = 10;
    public int maxHealth = 10;
    public int def = 1;
    public int gottenShield = 0;
    public float attackDelay = 1.5f;
    public bool ready = true;
    public GameObject gameOverCanvas;

    private GameObject shield;

    private void Awake()
    {
        attack = PlayerPrefs.GetInt("PlayerAttack", 2);
        health = PlayerPrefs.GetInt("PlayerHealth", 10);
        maxHealth = PlayerPrefs.GetInt("PlayerMaxHealth", 10);
        def = PlayerPrefs.GetInt("PlayerDefence", 1);

        TextMesh healthText = GameObject.Find("HealthText").GetComponent<TextMesh>();
        healthText.text = "Health : " + health + '/' + maxHealth;
        TextMesh statusText = GameObject.Find("StatusText").GetComponent<TextMesh>();
        statusText.text = "Atk/Def : " + attack + '/' + def;

        shield = GameObject.Find("Shield");
        gottenShield = PlayerPrefs.GetInt("PlayerShield", 0);
        if (gottenShield == 0) shield.SetActive(false);
    }

    void Start ()
    {
        gameOverCanvas.SetActive(false);
    }
	
	void Update () {
		
	}

    public void gotShield()
    {
        gottenShield = 1;
        PlayerPrefs.SetInt("PlayerShield", 1);
        shield.SetActive(true);
    }

    public void saveStatus()
    {
        PlayerPrefs.SetInt("PlayerAttack", attack);
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.SetInt("PlayerMaxHealth", maxHealth);
        PlayerPrefs.SetInt("PlayerDefence", def);
        PlayerPrefs.SetInt("PlayerShield", gottenShield);
    }

    public void damagePlayer(int damage)
    {
        health -= ((damage - def) > 0) ? (damage - def) : 0;
        if(health >= 0)
        {
            TextMesh healthText = GameObject.Find("HealthText").GetComponent<TextMesh>();
            healthText.text = "Health : " + health + '/' + maxHealth;
        }
        else
        {
            GetComponent<PlayerMovement>().gameOver();
            gameOverCanvas.SetActive(true);
        }
    }
    public void healPlayer(int heal)
    {
        health = ((heal + health) <= maxHealth) ? (heal + health) : maxHealth;
        TextMesh healthText = GameObject.Find("HealthText").GetComponent<TextMesh>();
        healthText.text = "Health : " + health + '/' + maxHealth;
    }
    public void setMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        TextMesh healthText = GameObject.Find("HealthText").GetComponent<TextMesh>();
        healthText.text = "Health : " + health + '/' + maxHealth;
    }
    public void setStatus(int newAttack, int newDef)
    {
        attack = newAttack;
        def = newDef;
        TextMesh statusText = GameObject.Find("StatusText").GetComponent<TextMesh>();
        statusText.text = "Atk/Def : " + attack + '/' + def;
    }

    public void beginAttack()
    {
        ready = false;
        FindObjectOfType<Sword>().attack();
        Invoke("DelayAttack", attackDelay);
    }

    void DelayAttack()
    {
        ready = true;
        FindObjectOfType<Sword>().finishedAttack();
    }
}
