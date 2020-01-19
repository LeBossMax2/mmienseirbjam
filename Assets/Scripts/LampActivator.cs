using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampActivator : MonoBehaviour
{
    private SecurityLight parent;

    private void Start()
    {
        parent = GetComponentInParent<SecurityLight>();
    }

    void OnMouseDown()
    {
        parent.OnClicked();
    }
}
