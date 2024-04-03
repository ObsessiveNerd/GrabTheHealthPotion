using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteController : MonoBehaviour
{
    public GameObject Muted;

    bool m_isMuted = false;
    DataSaver m_DataSaver;

    private void Start()
    {
        m_DataSaver = FindObjectOfType<DataSaver>();

        if (m_DataSaver == null)
            return;

        m_isMuted = m_DataSaver.GetData().Muted;
        SetupVolume();
    }

    public void MuteButtonHit()
    {
        m_isMuted = !m_isMuted;
        SetupVolume();
    }

    void SetupVolume()
    {
        if (m_isMuted)
        {
            AudioListener.volume = 0f;
            Muted.SetActive(true);
        }
        else
        {
            AudioListener.volume = 0.5f;
            Muted.SetActive(false);
        }
        m_DataSaver.SetMuted(m_isMuted);
    }
}
