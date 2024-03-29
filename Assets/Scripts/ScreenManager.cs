using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public TextMeshProUGUI Potions;
    public TextMeshProUGUI Highscore;
    public TextMeshProUGUI Lifetime;

    // Start is called before the first frame update
    void Start()
    {
        PersistentData data = FindObjectOfType<DataSaver>().GetData();
        Potions.text = $"Last Run: {data.LastRun}";
        Highscore.text = $"Best Run: {data.Highscore}";
        Lifetime.text = $"Total Hoard: {data.LifetimePotions}";
    }

    public void LoadMainScreen()
    {
        SceneManager.LoadScene("Scene");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadLeaderboards()
    {
        SceneManager.LoadScene("Leaderboards");
    }
}
