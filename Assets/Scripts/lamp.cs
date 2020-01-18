using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Experimental.Rendering.LWRP;

public class lamp : MonoBehaviour {

    public float radius;
    private Light2D light;
    private CircleCollider2D collider;
    public int durability;
    public bool isOn;

    private bool hasElectricity = true;
    public bool HasElectricity
    {
        get => hasElectricity;
        set
        {
            hasElectricity = value;
            if (!value)
            {
                light.intensity = 0;
            }
        }
    }

    private void Start() {
        // Get component
        light = this.GetComponent<Light2D>();
        collider = this.GetComponent<CircleCollider2D>();

        // Init radius for each component and state
        collider.radius = radius;
        light.pointLightOuterRadius = radius;
        light.intensity = 0;
        isOn = false;

    }

    void OnMouseDown() {
        if(!TurnManager.Instance.IsThiefTurn && HasElectricity)
        {
            isOn = true;
            StartCoroutine(blinkLight());
        }
    }


    public IEnumerator blinkLight(){

        for(int i = 0; i < 3; i++){
            light.intensity = 1;
            yield return new WaitForSeconds(0.5f);

            light.intensity = 0;
            yield return new WaitForSeconds(0.5f);
        }

    }
    
}