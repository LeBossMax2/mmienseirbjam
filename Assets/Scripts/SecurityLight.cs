using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.SceneManagement;

public abstract class SecurityLight : MonoBehaviour {
    
    public float totalDuration;
    public float blinkDuration;
    public Collider2D killZone { get; private set; }

    private bool isOn = false;
    private float activeTimer;

    private bool hasElectricity = true;

    private bool isBlinking = false;

    public bool HasElectricity
    {
        get => hasElectricity;
        set
        {
            hasElectricity = value;
            LightActive = value && isOn;
        }
    }

    protected abstract bool LightActive { set; }

    protected virtual void Start()
    {
        // Get component
        killZone = this.GetComponent<Collider2D>();

        // Init radius for each component and state
        LightActive = false;

    }

    private void Update()
    {
        if (isOn && hasElectricity)
        {
            activeTimer += Time.deltaTime;
            if (activeTimer >= totalDuration)
            {
                LightActive = false;
                isBlinking = false;
                isOn = false;
            }
            else if (activeTimer >= totalDuration - blinkDuration)
            {
                isBlinking = true;
            }
            else if (isBlinking && activeTimer >= blinkDuration)
            {
                LightActive = true;
                isBlinking = false;
            }

            if (isBlinking)
            {
                float blinkValue = (activeTimer % 1);
                if (blinkValue < 0) blinkValue += 1;
                LightActive = blinkValue >= 0.25f && blinkValue <= 0.75f;
            }
        }
    }

    public void OnClicked()
    {
        if (!TurnManager.Instance.IsThiefTurn && !isOn && HasElectricity && !TurnManager.Instance.ActivatedLamp && !QTEManager.Instance.IsInProgress)
        {
            TurnManager.Instance.ActivatedLamp = true;
            isOn = true;
            activeTimer = Time.time - TurnManager.Instance.turnStartTime - TurnManager.Instance.securityTurnTime;
            isBlinking = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOn && hasElectricity && !isBlinking && collision.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync("EndScreen");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isOn && hasElectricity && !isBlinking && collision.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync("EndScreen");
        }
    }
}