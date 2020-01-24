using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ActionProgress : MonoBehaviour
{
    public Image slider;
    private Canvas canvas;
    private float maxTimer;
    private float timer;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (maxTimer > 0)
        {
            timer += Time.deltaTime;
            slider.fillAmount = timer / maxTimer;
            if (timer >= maxTimer)
            {
                maxTimer = 0;

                gameObject.SetActive(false);
            }
        }
    }

    public void SetTimer(float timer, Vector3 postion)
    {
        slider.fillAmount = 0;
        this.maxTimer = timer;
        this.timer = 0;
        this.transform.position = Camera.main.WorldToScreenPoint(postion);
        gameObject.SetActive(true);
    }
}
