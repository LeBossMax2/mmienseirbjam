using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerPortrait : MonoBehaviour
{
    public GameObject thiefImage;
    public GameObject securityImage;

    private void Start()
    {
        switch (EndGameManager.Winner)
        {
            case "thief":
                thiefImage.SetActive(true);
                securityImage.SetActive(false);
                break;
            case "security":
                thiefImage.SetActive(false);
                securityImage.SetActive(true);
                break;
        }
    }
}
