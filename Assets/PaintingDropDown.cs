using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingDropDown : InteractionObject
{
    protected override float InteractionTime => base.InteractionTime * Thief.paintingsCarriedCount;

    protected override void OnInteractionEnded()
    {
        Thief.score += Thief.paintingsCarriedScore;
        Thief.paintingsCarriedScore = 0;
        Thief.paintingsCarriedCount = 0;
    }
}
