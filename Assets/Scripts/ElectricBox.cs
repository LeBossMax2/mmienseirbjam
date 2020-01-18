using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBox : InteractionObject
{
    protected override void OnInteractionEnded()
    {
        gameObject.SetActive(false);
    }
}
