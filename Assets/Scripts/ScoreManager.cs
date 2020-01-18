using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //private Slider slider;
    private Image slider;
    void Start()
    {
        //slider = GetComponent<Slider>();
        //slider.maxValue = FindObjectsOfType<PaintingPickUp>().Select(p => p.PaintingScore).Sum();

        //slider = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    public void SetThiefScore(int newScore)
    {
        slider.fillAmount = newScore ;
    }
}
