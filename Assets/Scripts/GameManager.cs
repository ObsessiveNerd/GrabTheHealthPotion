using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int Score;
    int Health;

    public GameObject HeartContainer;
    public TextMeshProUGUI ScoreUI;
    public Blurbs BlurbObject;
    public GameObject Text;
    public Transform Canvas;
    public GameObject BottomSpawner;

    public AudioSource GlassBreak;
    public AudioSource DrinkPotion;

    public bool GodMode = false;

    List<GameObject> m_Hearts = new List<GameObject>();

    private void Start()
    {
        foreach (var heart in HeartContainer.transform.GetComponentsInChildren<Transform>())
            m_Hearts.Add(heart.gameObject);

        Health = m_Hearts.Count - 1;
        StartCoroutine(TurnOnBottomSpawner());
    }

    public void AddToScore(Vector2 position)
    {
        Score++;
        ScoreUI.text = $"Potions: {Score}";

        int randomValue = Random.Range(0, 100);
        if(randomValue < 50)
        {
            var instance = Instantiate(Text, Canvas);
            instance.transform.position = Camera.main.WorldToScreenPoint(position);
            instance.GetComponent<TextMeshProUGUI>().text = BlurbObject.GetBlurb();
            DrinkPotion.Play();
        }
        Debug.Log($"Score: {Score}");
    }

    public void TakeDamage()
    {
        //shake
        var renderer = m_Hearts[Health].GetComponent<Image>();
        m_Hearts[Health].GetComponent<ObjectShaker>().Shake();
        renderer.color = Color.grey;

        if(!GodMode)
            Health--;
        
        GlassBreak.Play();

        if(Health <= 0)
        {
            FindObjectOfType<DataSaver>()?.EndGame(Score);
            SceneManager.LoadScene("Screen");
        }
    }

    IEnumerator TurnOnBottomSpawner()
    {
        yield return new WaitForSeconds(15f);
        BottomSpawner.SetActive(true);

        foreach (var spawner in FindObjectsOfType<Spawner>())
            spawner.IncreaseSpawnTime(0.2f);

        //hard mode
        yield return new WaitForSeconds(30f);
        foreach (var spawner in FindObjectsOfType<Spawner>())
            spawner.IncreaseSpawnTime(-0.1f);

    }
}
