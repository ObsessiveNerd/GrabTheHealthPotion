using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderText : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Score;

    public void SetData(string name, double score)
    {
        Name.text = name;
        Score.text = score.ToString();
    }
}
