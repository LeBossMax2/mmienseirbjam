using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPickUp : InteractionObject
{
    public int PaintingScore;
    public Sprite fakePaintingSprite;

    private SpriteRenderer spriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void OnInteractionEnded()
    {
        Thief.paintingsCarriedScore += PaintingScore;
        Thief.paintingsCarriedCount++;
        spriteRenderer.sprite = fakePaintingSprite;
        Destroy(this);
    }
}
