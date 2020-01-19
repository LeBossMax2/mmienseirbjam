using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.SceneManagement;

public class Laser : SecurityLight {

    public GameObject laserBeam;

    protected override bool LightActive { set => laserBeam.SetActive(value); }
    
}