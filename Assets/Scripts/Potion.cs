using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public bool IsHealthPotion;
    public GameObject OnDestroyParticles;

    GameManager m_Manager;

    // Start is called before the first frame update
    void Start()
    {
        m_Manager = FindObjectOfType<GameManager>();
        StartCoroutine(DestroyAfter());
    }

    private void OnMouseDown()
    {
        if (IsHealthPotion)
            m_Manager.AddToScore(transform.position);
        else
            m_Manager.TakeDamage();

        Instantiate(OnDestroyParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(2f);
        if(IsHealthPotion)
            FindObjectOfType<GameManager>().TakeDamage();
        Destroy(gameObject);
    }
}
