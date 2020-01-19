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
        movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Get current direction
        if (movementVector.y < -0.01)
        {
            direction = 0; // DOWN
        }
        if(movementVector.y > 0.01)
        {
            direction = 1; // UP
        }
        if(movementVector.x < -0.01)
        {
            direction = 2; // LEFT
            this.transform.localScale = new Vector3(-1.5f, 1.5f, 1f);
        }
        if(movementVector.x > 0.01)
        {
            direction = 3; // RIGHT
            this.transform.localScale = new Vector3(1.5f, 1.5f, 1f);

        }

        float isMoving = Mathf.Abs(movementVector.x) + Mathf.Abs(movementVector.y);

        if (TurnManager.Instance.IsThiefTurn && !IsInteracting)
        {
            animator.SetInteger("Direction", direction);
            animator.SetFloat("Speed", isMoving);
        }

        if (movementVector.sqrMagnitude >= 1)
            movementVector.Normalize();


    }

    void FixedUpdate()
    {
        myRigidBody.velocity = TurnManager.Instance.IsThiefTurn && !IsInteracting ? movementVector * speed : Vector2.zero;

    }

    public void OnStartTurn()
    {
        animator.speed = 1;
    }

    public void OnEndTurn()
    {
        animator.speed = 0;
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreManager.SetThiefScore(this.score);
    }
}
