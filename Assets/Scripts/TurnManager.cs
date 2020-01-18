using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int turnCount;
    public float thiefTurnTime;
    public float securityTurnTime;
    public Thief thief;
    public GameObject security;

    private int turnIndex;
    private float turnStartTime;

    public bool IsThiefTurn => turnIndex % 2 == 0;

    public float CurrentTirnTime => IsThiefTurn ? thiefTurnTime : securityTurnTime;

    private void Start()
    {
        initTurn();
    }

    private void FixedUpdate()
    {
        if (Time.time - turnStartTime >= CurrentTirnTime)
        {
            nextTurn();
        }
    }

    private void nextTurn()
    {
        turnIndex++;
        if (turnIndex >= turnCount)
        {
            //the end
        }
        else
        {
            //TODO tick lights

            initTurn();
        }
    }

    private void initTurn()
    {
        thief.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (IsThiefTurn)
        {
            thief.enabled = true;
            security.SetActive(false);
        }
        else
        {
            thief.enabled = false;
            security.SetActive(true);
        }
        turnStartTime = Time.time;
    }
}
