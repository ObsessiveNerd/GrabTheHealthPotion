using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> HealthPotions;
    public List<GameObject> Poisons;
    public bool FallUp = false;

    private float m_MinTimeUntilNextSpawn = 0.3f;
    private float m_MaxTimeUntilNextSpawn = 0.8f;
    float m_TimeSinceLastSpawn = 0f;
    float m_TimeUntilNextSpawn = 0f;
    Bounds m_Bounds;

    private void Start()
    {
        m_Bounds = GetComponent<BoxCollider2D>().bounds;
    }

    public void IncreaseSpawnTime(float time)
    {
        m_MinTimeUntilNextSpawn += time;
        m_MaxTimeUntilNextSpawn += time;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TimeSinceLastSpawn >= m_TimeUntilNextSpawn)
        {
            float randomValue = Random.Range(0, 100);
            Vector2 randomPosition = new Vector2(
                Random.Range(m_Bounds.min.x, m_Bounds.max.x),
                Random.Range(m_Bounds.min.y, m_Bounds.max.y));
            Quaternion randomRotation = Random.rotation;
            randomRotation.x = 0f;
            randomRotation.y = 0f;

            GameObject instance = null;

            if (randomValue < 10)
                instance = Instantiate(Poisons[Random.Range(0, Poisons.Count)], randomPosition, Quaternion.identity);
            else
                instance = Instantiate(HealthPotions[Random.Range(0, HealthPotions.Count)], randomPosition, Quaternion.identity);

            if (FallUp)
            { 
                instance.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f));
                instance.GetComponent<Rigidbody2D>().gravityScale = -1f;
            }
            
                    instance.GetComponentInChildren<SpriteRenderer>().transform.rotation = randomRotation;
                //.Find("Image").rotation = randomRotation;

            //instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1), Random.Range(0f, 1f)) * Random.Range(1, 10), ForceMode2D.Impulse);
            m_TimeSinceLastSpawn = 0f;
            m_TimeUntilNextSpawn = Random.Range(m_MinTimeUntilNextSpawn, m_MaxTimeUntilNextSpawn);
        }
        else
            m_TimeSinceLastSpawn += Time.deltaTime;
    }
}
