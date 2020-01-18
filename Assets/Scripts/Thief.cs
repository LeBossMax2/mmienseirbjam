using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public int score;
    public float speed;
    public Rigidbody2D myRigidBody;

    private Vector2 movementVector;

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
        myRigidBody.velocity = movementVector * speed;

    }
}
