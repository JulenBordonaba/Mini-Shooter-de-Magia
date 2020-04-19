using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxhealth = 300;


    private float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
    }


    public void TakeDamage(float damageAmmount)
    {
        currentHealth -= damageAmmount;
        if(currentHealth<=0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
