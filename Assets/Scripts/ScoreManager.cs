using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Image slider;
    private int maxScore;

    private void Awake()
    {
        slider = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        maxScore = FindObjectsOfType<PaintingPickUp>().Select(p => p.PaintingScore).Sum();
        SetThiefScore(0);
    }

    public void SetThiefScore(int newScore)
    {
        slider.fillAmount = (float)newScore / maxScore;
    }
}
