using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityGenerator : InteractionObject
{
    protected override float InteractionTime => hasElectricity ? base.InteractionTime : 0;

    public TurnManager turnManager;
    public QTEManager qte;
    private ElectricBox box;

    private bool hasElectricity = true;

    private void Start()
    {
        box = GetComponentInChildren<ElectricBox>();
    }

    protected override void OnInteractionEnded()
    {
        // Disable all lights
        hasElectricity = false;
    }

    private void OnMouseDown()
    {
        if (!qte.IsInProgress && !turnManager.IsThiefTurn)
            qte.startQTE(hasElectricity ? 3 : 4, 2, onQTESuccess);
    }

    private void onQTESuccess()
    {
        if (hasElectricity)
        {
            box.gameObject.SetActive(true);
        }
        else
        {
            // Enable all lights
            hasElectricity = true;
        }
    }
}
