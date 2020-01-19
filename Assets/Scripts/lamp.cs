using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.SceneManagement;

public class Lamp : SecurityLight {

    public float radius;
    private new Light2D light;
    private SpriteRenderer spRenderer;
    public Sprite offSprite;
    public Sprite onSprite;

    protected override bool isOn
    {
        get => base.isOn;

        set
        {
            base.isOn = value;
            spRenderer.sprite = value ? onSprite : offSprite;
        }
    }

    protected override bool LightActive { set => light.intensity = value ? 1 : 0; }
    
    protected override void Awake()
    {
        spRenderer = GetComponentInChildren<SpriteRenderer>();
        light = this.GetComponent<Light2D>();
        light.pointLightOuterRadius = radius;
        base.Awake();
        ((CircleCollider2D)killZone).radius = radius;
    }
}