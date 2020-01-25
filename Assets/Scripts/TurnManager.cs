using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }

    public int turnCount;
    public float thiefTurnTime;
    public float securityTurnTime;
    public PostProcessVolume postProcess;
    public PostProcessProfile thiefProfile;
    public PostProcessProfile securityProfile;
    public Thief thief;
    public GameObject lampParent;
    public Animator timer;
    public Animator partrait;
    public AudioSource music;

    public bool ActivatedLamp { get; set; } = false;

    private int turnIndex;
    public float turnStartTime { get; private set; }

    public bool IsThiefTurn => turnIndex % 2 == 0;

    public float CurrentTurnTime => IsThiefTurn ? thiefTurnTime : securityTurnTime;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        initTurn();
    }

    private void FixedUpdate()
    {
        if (Time.time - turnStartTime >= CurrentTurnTime)
        {
            nextTurn();
        }
    }

    private void nextTurn()
    {
        turnIndex++;
        if (turnIndex >= turnCount)
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            EndGameManager.EndGame(scoreManager.Score > scoreManager.MaxScore / 2);
        }
        else
        {
            initTurn();
        }
    }

    private void initTurn()
    {
        if (IsThiefTurn)
        {
            thief.OnStartTurn();
            postProcess.profile = thiefProfile;
            partrait.SetTrigger("Thief");
            partrait.ResetTrigger("Security");
            foreach (SecurityLight l in lampParent.GetComponentsInChildren<SecurityLight>())
            {
                l.killZone.enabled = true;
            }
        }
        else
        {
            thief.OnEndTurn();
            postProcess.profile = securityProfile;
            ActivatedLamp = false;
            partrait.SetTrigger("Security");
            partrait.ResetTrigger("Thief");
            foreach (SecurityLight l in lampParent.GetComponentsInChildren<SecurityLight>())
            {
                l.killZone.enabled = false;
            }
        }

        if (turnIndex == turnCount - 2)
        {
            music.pitch /= 2;
        }

        timer.Play("TimerAnimation", 0, 1 - CurrentTurnTime / 10);
        turnStartTime = Time.time;
    }
}
