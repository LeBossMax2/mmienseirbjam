using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QTETarget : MonoBehaviour, IPointerDownHandler
{
    public QTEManager manager { get; set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        manager.OnTargetHit(this);
        eventData.Use();
        Destroy(gameObject);
    }
}
