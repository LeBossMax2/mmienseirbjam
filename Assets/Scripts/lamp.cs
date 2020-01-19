using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.SceneManagement;

public class Lamp : SecurityLight {

    public float radius;
    private new Light2D light;

    protected override bool LightActive { set => light.intensity = value ? 1 : 0; }
    
    protected override void Start()
    {
        light = this.GetComponent<Light2D>();
        light.pointLightOuterRadius = radius;
        base.Start();
        ((CircleCollider2D)killZone).radius = radius;
    }
}