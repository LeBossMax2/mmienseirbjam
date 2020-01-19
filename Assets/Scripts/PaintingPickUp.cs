using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPickUp : InteractionObject
{
    public int PaintingScore;
    public Sprite fakePaintingSprite;

    private SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    protected override void OnInteractionEnded()
    {
        Thief.paintingsCarriedScore += PaintingScore;
        Thief.paintingsCarriedCount++;
        renderer.sprite = fakePaintingSprite;
        this.enabled = false;
    }
}
