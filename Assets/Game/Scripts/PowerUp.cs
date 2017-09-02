using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public enum PowerUpType { Attack, Health, Defence, Heal, Shield, Sword };
    
    public PowerUpType powerUpType;
    public int amount;

    private PlayerStatus playerStatus;
    private UIManager uiManager;

    void Start () {
        playerStatus = FindObjectOfType<PlayerStatus>();
        uiManager = FindObjectOfType<UIManager>();
	}
	
	void Update () {

    }

    void activatePowerUp()
    {
        FindObjectOfType<SFX>().playItemTaken();
        if (powerUpType == PowerUpType.Attack)
        {
            playerStatus.setStatus((playerStatus.attack + amount), playerStatus.def);
            uiManager.showErrorText("Power Up Attack Diambil");
        }
        else if (powerUpType == PowerUpType.Health)
        {
            playerStatus.maxHealth += amount;
            playerStatus.healPlayer(amount);
            uiManager.showErrorText("Power Up Health Diambil");
        }
        else if (powerUpType == PowerUpType.Defence)
        {
            playerStatus.setStatus(playerStatus.attack, (playerStatus.def + amount));
            uiManager.showErrorText("Power Up Defence Diambil");
        }
        else if (powerUpType == PowerUpType.Heal)
        {
            playerStatus.healPlayer(amount);
            uiManager.showErrorText("Power Up Heal Diambil");
        }
        else if (powerUpType == PowerUpType.Shield)
        {
            playerStatus.setStatus(playerStatus.attack, (playerStatus.def + amount));
            playerStatus.gotShield();
            uiManager.showErrorText("Power Up Shield Diambil");
        }
        else if (powerUpType == PowerUpType.Sword)
        {
            playerStatus.setStatus((playerStatus.attack + amount), playerStatus.def);
            uiManager.showErrorText("Power Up Sword Diambil");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            activatePowerUp();
            Destroy(transform.parent.gameObject);
        }
    }
}
