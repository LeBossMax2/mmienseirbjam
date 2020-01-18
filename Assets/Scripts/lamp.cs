using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Experimental.Rendering.LWRP;

public class lamp : MonoBehaviour {

    public int radius;
    private Light2D light;
    private CircleCollider2D collider;
    public int durability;
    public bool state;
    private void Start() {
        // Get component
        light = this.GetComponent<Light2D>();
        collider = this.GetComponent<CircleCollider2D>();

        // Init radius for each component and state
        collider.radius = radius;
        light.pointLightOuterRadius = radius;
        state = false;

    }

    private void Update() {
        if(!state){
            light.intensity = 0;
        }
    }

    void OnMouseDown() {
        //SwitchOnLight();
        state = true;
        StartCoroutine("blinkLight");
        
    }

    private void SwitchOnLight(){
        durability = 2;
        //IEnumerator blink = blinkLight();
        //StartCoroutine("blink");
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