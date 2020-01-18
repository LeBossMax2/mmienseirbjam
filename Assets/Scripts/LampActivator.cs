using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampActivator : MonoBehaviour
{
    private lamp parent;

    private void Start()
    {
        parent = GetComponentInParent<lamp>();
    }

    void OnMouseDown()
    {
        parent.OnClicked();
    }
}
