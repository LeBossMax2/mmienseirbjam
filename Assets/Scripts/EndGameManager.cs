using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EndGameManager
{
    public static string Winner => PlayerPrefs.GetString("winner");

    public static void EndGame(bool thiefWon)
    {
        PlayerPrefs.SetString("winner", thiefWon ? "thief" : "security");
        SceneManager.LoadSceneAsync("EndScreen");
    }
}