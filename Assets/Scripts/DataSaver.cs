using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public struct PersistentData
{
    public int LastRun;
    public int LifetimePotions;
    public int Highscore;
}

public class DataSaver : MonoBehaviour
{
    string m_PersistentDataPath;
    PersistentData m_Data;
    bool m_Initialized = false;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public PersistentData GetData()
    {
        if(!m_Initialized)
        {
            LoadData();
            m_Initialized = true;
        }

        return m_Data;
    }

    void LoadData()
    {
        m_PersistentDataPath = Application.persistentDataPath + "/potions.data";
        if (File.Exists(m_PersistentDataPath))
        {
            string data = File.ReadAllText(m_PersistentDataPath);
            m_Data = JsonUtility.FromJson<PersistentData>(data);
        }
        else
            m_Data = new PersistentData()
            {
                LifetimePotions = 0,
                Highscore = 0,
                LastRun = 0
            };
    }

    public void EndGame(int finalScore)
    {
        if(finalScore > m_Data.Highscore)
            m_Data.Highscore = finalScore;
        m_Data.LifetimePotions += finalScore;
        m_Data.LastRun = finalScore;

        File.WriteAllText(m_PersistentDataPath, JsonUtility.ToJson(m_Data));
    }
}
