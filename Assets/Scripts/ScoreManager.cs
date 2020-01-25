using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Image slider;
    public int MaxScore { get; private set; }
    private int score = 0;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            slider.fillAmount = (float)value / MaxScore;
        }
    }

    private void Awake()
    {
        slider = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        MaxScore = FindObjectsOfType<PaintingPickUp>().Select(p => p.PaintingScore).Sum();
        Score = 0;
    }
}
