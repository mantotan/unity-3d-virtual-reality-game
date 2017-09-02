using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float attackDelay = 2.3f;

    public bool inRange = false, isAttacking = false;
    private Vector3 initialPosition;
    public GameObject player;
    private Animator animator;
    private EnemyStatus status;
    private PlayerStatus playerStatus;
    public bool moveLeft = false;

	void Start () {
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        status = GetComponent<EnemyStatus>();
        playerStatus = FindObjectOfType<PlayerStatus>();

        StartCoroutine(attack());
	}
	
	void Update ()
    {
        if (inRange)
        {
            var lookPos = player.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3f);
        }
        if(!animator.GetBool("Attack") && !animator.GetBool("Death"))
        {
            if(!moveLeft)
                transform.Translate(Vector3.right * Time.deltaTime * 1f * 1f);
            else
                transform.Translate(Vector3.left * Time.deltaTime * 1f * 1f);

            float difference = transform.position.x - initialPosition.x;
            if (Mathf.Abs(difference) >= 0.5f) moveLeft = !moveLeft;
        }
    }

    IEnumerator attack()
    {
        while(status.health > 0)
        {
            if(inRange)
            {
                animator.SetBool("Attack", true);
                StartCoroutine(attacking());
                playerStatus.damagePlayer(status.attack);
            }
            else
            {
                animator.SetBool("Attack", false);
            }
            yield return new WaitForSeconds(attackDelay);
            animator.SetBool("Attack", false);
        }
        if (status.health <= 0)
        {
            animator.SetBool("Death", true);
            if (transform.name.Equals("Cobra"))
            {
                SceneManager.LoadScene("Level-21");
            }
        }
    }

    IEnumerator attacking()
    {
        //transform.Translate(Vector3.forward * 50 * Time.deltaTime);
        //yield return new WaitForSeconds(1.5f);
        //transform.Translate(Vector3.back * 50 * Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
        //transform.position = initialPosition;
    }

    public void hitTarget()
    {
        print("hit");
        if (inRange && playerStatus.ready)
        {
            print("damaged");
            playerStatus.beginAttack();
            status.damage(((playerStatus.attack - status.def) > 0) ? (playerStatus.attack - status.def) : 0);
        }
    }
}
