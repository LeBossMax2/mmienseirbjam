using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public TurnManager turnManager;
    public int score = 0;
    public float speed;
    private Rigidbody2D myRigidBody;

    private Vector2 movementVector;

    public int paintingsCarriedScore { get; set; } = 0;
    public int paintingsCarriedCount { get; set; } = 0;
    public bool IsInteracting { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (movementVector.sqrMagnitude >= 1)
            movementVector.Normalize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigidBody.velocity = turnManager.IsThiefTurn && !IsInteracting ? movementVector * speed : Vector2.zero;

    }
}
