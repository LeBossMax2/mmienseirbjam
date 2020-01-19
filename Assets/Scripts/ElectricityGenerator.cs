using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityGenerator : InteractionObject
{
    protected override float InteractionTime => hasElectricity ? base.InteractionTime : 0;

    public GameObject lampParent;
    public QTEManager qte;
    private ElectricBox box;

    private bool hasElectricity = true;

    private void Start()
    {
        box = GetComponentInChildren<ElectricBox>();
    }

    protected override void OnInteractionEnded()
    {
        foreach (SecurityLight l in lampParent.GetComponentsInChildren<SecurityLight>())
        {
            l.HasElectricity = false;
        }
        hasElectricity = false;
    }

    private void OnMouseDown()
    {
        if (!qte.IsInProgress && !TurnManager.Instance.IsThiefTurn && (!hasElectricity || !box.gameObject.activeSelf))
            qte.startQTE(hasElectricity ? 3 : 4, 2.5f, onQTESuccess);
    }

    private void onQTESuccess()
    {
        if (hasElectricity)
        {
            box.gameObject.SetActive(true);
        }
        else
        {
            hasElectricity = true;
            foreach (SecurityLight l in lampParent.GetComponentsInChildren<SecurityLight>())
            {
                l.HasElectricity = false;
            }
        }
    }
}
