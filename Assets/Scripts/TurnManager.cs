using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }
    public int turnCount;
    public float thiefTurnTime;
    public float securityTurnTime;
    public GameObject security;

    private int turnIndex;
    private float turnStartTime;

    public bool IsThiefTurn => turnIndex % 2 == 0;

    public float CurrentTirnTime => IsThiefTurn ? thiefTurnTime : securityTurnTime;

    private void Start()
    {
        Instance = this;
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
        if (IsThiefTurn)
        {
            security.SetActive(false);
        }
        else
        {
            security.SetActive(true);
        }
        turnStartTime = Time.time;
    }
}
