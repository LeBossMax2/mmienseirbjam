using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionObject : MonoBehaviour
{
    public float BaseInteractionTime;

    protected Thief Thief { get; private set; }
    protected float TimeSpent { get; private set; } = 0;
    protected bool IsThiefColliding { get; private set; } = false;

    private ActionProgress progressBar;

    protected virtual float InteractionTime => BaseInteractionTime;
    protected bool IsInInteraction => IsThiefColliding && TimeSpent < InteractionTime;

    private void Awake()
    {
        progressBar = FindObjectOfType<ActionProgress>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsInInteraction)
        {
            TimeSpent += Time.deltaTime;
            if (TimeSpent >= InteractionTime)
            {
                OnInteractionEnded();
                if (Thief != null)
                    Thief.IsInteracting = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Thief == null && collision.GetComponent<Thief>() != null)
        {
            Thief = collision.GetComponent<Thief>();
            IsThiefColliding = true;
            if (InteractionTime > 0)
            {
                Thief.IsInteracting = true;
                progressBar.SetTimer(InteractionTime, transform.position);
                OnInteractionStarted();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);

        if (IsThiefColliding && Thief != null && collision.gameObject == Thief.gameObject && InteractionTime > 0 && !Thief.IsInteracting)
        {
            Thief.IsInteracting = true;
            progressBar.SetTimer(InteractionTime, transform.position);
            OnInteractionStarted();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsThiefColliding && Thief != null && collision.gameObject == Thief.gameObject)
        {
            Thief.IsInteracting = false;
            IsThiefColliding = false;
            TimeSpent = 0;
            Thief = null;
        }
    }

    protected virtual void OnInteractionStarted()
    { }

    protected abstract void OnInteractionEnded();
}
