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

    protected virtual bool isOn { get; set; } = false;
    private float activeTimer;
    private AudioSource alarm;

    private bool hasElectricity = true;

    private bool isBlinking = false;

    public virtual bool HasElectricity
    {
        get => hasElectricity;
        set
        {
            hasElectricity = value;
            if (!value)
            {
                isOn = false;
                LightActive = false;
            }
        }
    }

    protected abstract bool LightActive { set; }
    
    protected virtual void Awake()
    {
        // Get component
        killZone = GetComponent<Collider2D>();
        alarm = FindObjectOfType<AudioListener>().transform.Find("AlarmAudio").GetComponent<AudioSource>();

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
            StartCoroutine(loseGame(collision.GetComponent<Thief>()));
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isOn && hasElectricity && !isBlinking && collision.CompareTag("Player"))
        {
            StartCoroutine(loseGame(collision.GetComponent<Thief>()));
        }
    }

    private IEnumerator loseGame(Thief player)
    {
        player.OnEndTurn();
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        TurnManager.Instance.enabled = false;

        float time = alarm.clip.length * 0.7f;
        alarm.time = time;
        alarm.Play();

        yield return new WaitForSeconds(alarm.clip.length - time);

        SceneManager.LoadSceneAsync("EndScreen");
    }
}