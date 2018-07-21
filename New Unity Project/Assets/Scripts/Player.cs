using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour {
    //initial speed
    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 28f;
    //moniotirng state of player's ridigbody
    Rigidbody2D state;
    //get animator component to track what animation to do
    Animator myAnimator;
    //get collider to make person jump once
    Collider2D myCollider;
    float scaleX;
    // Use this for initialization
    void Start()
    {
        state = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        flipSprite();
        Jump();
    }
    private void Run()
    {
        //moniotr horizontal velocity by modifying the 
        // axis
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
        Vector2 playerVelocity = new Vector2(controlThrow, state.velocity.y);
        state.velocity = playerVelocity;
        bool isRunning = Mathf.Abs(state.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", isRunning);   
    }
    private void flipSprite(){
        //check if player has any speed
        bool horizonalSpeed = Mathf.Abs(state.velocity.x) > Mathf.Epsilon;
        if (horizonalSpeed)
        {
            scaleX = Mathf.Sign(state.velocity.x);
            transform.localScale = new Vector2(scaleX, 1f);

        }
    }
    private void Jump(){

        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if(CrossPlatformInputManager.GetButtonDown("Jump")){
            Vector2 velocity = new Vector2(0, jump);
            state.velocity += velocity;
        }
    }
}
