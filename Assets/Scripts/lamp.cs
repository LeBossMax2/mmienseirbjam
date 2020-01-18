using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class lamp : MonoBehaviour {

    public int radius;
    private Light2D light;
    private CircleCollider2D collider;
    public int durability;
    public bool state; // 0 = OFF - 1 = ON
    private void Start() {
        // Get component
        light = this.GetComponent<Light2D>();
        collider = this.GetComponent<CircleCollider2D>();

        // Init radius for each component and state
        collider.radius = radius;
        light.pointLightOuterRadius = radius;
        state = 0;

    }

    private void Update() {
        if(state == 0){
            light.intensity = 0;
        }
    }

    private void turnLight(){
        
    }
    
}