using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> HealthPotions;
    public List<GameObject> Poisons;

    float m_TimeSinceLastSpawn = 0f;
    float m_TimeUntilNextSpawn = 0f;
    Bounds m_Bounds;

    private void Start()
    {
        m_Bounds = GetComponent<BoxCollider2D>().bounds;
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
                instance = Instantiate(Poisons[Random.Range(0, Poisons.Count)], randomPosition, randomRotation);
            else
                instance = Instantiate(HealthPotions[Random.Range(0, HealthPotions.Count)], randomPosition, randomRotation);

            //instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1), Random.Range(0f, 1f)) * Random.Range(1, 10), ForceMode2D.Impulse);
            m_TimeSinceLastSpawn = 0f;
            m_TimeUntilNextSpawn = Random.Range(0.2f, 0.7f);
        }
        else
            m_TimeSinceLastSpawn += Time.deltaTime;
    }
}
