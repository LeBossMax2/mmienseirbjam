using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public ScoreManager scoreManager;
    private int direction; // 0 = DOWN / 1 = UP / 2 = LEFT / 3 = RIGHT
    public Animator animator;
    private int score = 0;
    public float speed;
    private Rigidbody2D myRigidBody;

    private Vector2 movementVector;

    public int paintingsCarriedScore { get; set; } = 0;

    public int paintingsCarriedCount { get; set; } = 0;
    public bool IsInteracting { get; set; }

    void Start()
    {
        direction = 0; // Init with down position
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        // Get current direction
        if(Input.GetAxis("Vertical") < 0){
            direction = 0; // DOWN
        }
        if(Input.GetAxis("Vertical") > 0){
            direction = 1; // UP
        }
        if(Input.GetAxis("Horizontal") < 0){
            direction = 2; // LEFT
        }
        if(Input.GetAxis("Horizontal") > 0){
            direction = 3; // RIGHT
        }

        animator.SetInteger("Direction", direction);
        float isMoving = Mathf.Abs(Input.GetAxis("Horizontal") + Input.GetAxis("Vertical"));
        animator.SetFloat("Speed", isMoving);
        Debug.Log(isMoving);
        Debug.Log(direction);

        movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (movementVector.sqrMagnitude >= 1)
            movementVector.Normalize();


    }

    void FixedUpdate()
    {
        myRigidBody.velocity = TurnManager.Instance.IsThiefTurn && !IsInteracting ? movementVector * speed : Vector2.zero;

    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreManager.SetThiefScore(this.score);
    }
}
