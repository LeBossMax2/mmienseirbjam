using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = FindObjectsOfType<PaintingPickUp>().Select(p => p.PaintingScore).Sum();
    }

    public void SetThiefScore(int newScore)
    {
        slider.value = newScore;
    }
}
