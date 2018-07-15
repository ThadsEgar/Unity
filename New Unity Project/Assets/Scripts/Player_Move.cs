using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {
	//stats
	public int playerHealth;

	//movement
	public int playerSpeed = 5;
	public bool facingRight = true;
	public int playerJumpAmount = 500;
	public float moveX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMove();
	}

	void PlayerMove(){
		//Control
		moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown ("Jump"))
        {
            Jump();
        }
		//Animation

		//Direction
		if(moveX < 0.0f && facingRight == false)
		{
			FlipPlayer();
		}else if(moveX > 0.0f && facingRight == true){
			FlipPlayer();
		}

		//Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

	}

	void Jump(){
        //Jump
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpAmount);
	}

	void FlipPlayer(){
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
	}
}
