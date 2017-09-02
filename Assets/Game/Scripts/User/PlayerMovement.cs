using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private bool isGameOver = false;
    private Vector3 moveDirection = Vector3.zero;
    private SFX sfx;   


    void Start () {
        sfx = FindObjectOfType<SFX>();
	}

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (!isGameOver)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (moveDirection != Vector3.zero) sfx.startWalking();
            else sfx.stopWalking();
            moveDirection = GameObject.Find("Main Camera").transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                moveDirection.y = jumpSpeed;
                sfx.playJump();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                //FindObjectOfType<Sword>().attack();
                sfx.playAttack();
            }

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 2.5f);
    }

    public void gameOver()
    {
        isGameOver = true;
    }
}
