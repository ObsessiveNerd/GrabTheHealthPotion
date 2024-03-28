using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "GTHP/Blurb", fileName = "Blurb.asset")]
public class Blurbs : ScriptableObject
{
    public List<string> BlurbList;

    public string GetBlurb()
    {
        return BlurbList[Random.Range(0, BlurbList.Count)];
    }
}
