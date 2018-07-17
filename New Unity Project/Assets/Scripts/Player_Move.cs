using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour {
    //img-----------------------------------
    public Image HealthBar;
	//stats---------------------------------
        //initial (used for calculation)
	public float startPlayerHealth = 100;
    public float startPlayerSpeed = 5;
        //current
    public float playerHealth;
    public float playerSpeed;
    
    
    //movement------------------------------
    public bool facingRight = true;
	public float playerJumpAmount = 500;
	public float moveX;


	// Use this for initialization
	void Start () {
        playerHealth = startPlayerHealth;
        playerSpeed = startPlayerSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMove();
        //temp check health works
        minusHealth(1f);
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

    //--------------------HEALTH MOD/CALCULATION--------------------------
    void minusHealth(float amount)
    {
        playerHealth -= amount;
        HealthBar.fillAmount = playerHealth / startPlayerHealth;

    }

    void addHealth(float amount)
    {
        playerHealth += amount;
    }

    void killPlayer()
    {
        //TODO
    }
}
