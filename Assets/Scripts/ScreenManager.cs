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
        Potions.text = $"Potions: {data.LastRun}";
        Highscore.text = $"Best Run: {data.Highscore}";
        Lifetime.text = $"Lifetime: {data.LifetimePotions}";
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
