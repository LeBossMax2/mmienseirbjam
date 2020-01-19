using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPickUp : InteractionObject
{
    public int PaintingScore;

    protected override void OnInteractionEnded()
    {
        Thief.paintingsCarriedScore += PaintingScore;
        Thief.paintingsCarriedCount++;
        Destroy(gameObject);
    }
}
