using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEManager : MonoBehaviour
{
    public static QTEManager Instance { get; private set; }

    public Action onSuccess;
    public QTETarget targetPrefab;
    
    private float qteDuration = 0;

    private float qteTimer;

    private List<QTETarget> targets = new List<QTETarget>();

    public bool IsInProgress => qteDuration > 0;

    private void Awake()
    {
        Instance = this;
    }

    public void startQTE(int targetCount, float qteDuration, Action onSuccess)
    {
        this.qteDuration = qteDuration;
        this.onSuccess = onSuccess;
        this.qteTimer = 0;
        ClearQTE();

        for (int i = 0; i < targetCount; i++)
        {
            QTETarget newTarget = Instantiate(targetPrefab, gameObject.transform);
            RectTransform rect = newTarget.GetComponent<RectTransform>();

            newTarget.manager = this;
            newTarget.transform.position = new Vector2(UnityEngine.Random.Range(0, Screen.width - rect.rect.width) + rect.rect.width / 2, UnityEngine.Random.Range(0, Screen.height - rect.rect.height) + rect.rect.height / 2);

            targets.Add(newTarget);
        }
    }

    private void FixedUpdate()
    {
        if (qteDuration > 0)
        {
            qteTimer += Time.fixedDeltaTime;
            if (qteTimer >= qteDuration)
            {
                ClearQTE();
                qteDuration = 0;
            }
        }
    }

    private void ClearQTE()
    {
        foreach (QTETarget target in targets)
        {
            Destroy(target.gameObject);
        }
        targets.Clear();
    }

    public void OnTargetHit(QTETarget target)
    {
        targets.Remove(target);
        if (targets.Count == 0 && qteDuration > 0)
        {
            onSuccess();
            qteDuration = 0;
        }
    }
}
