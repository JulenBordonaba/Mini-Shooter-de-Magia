using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FreezeEffect))]
public class Enemy : MonoBehaviour
{
    public float maxhealth = 300;


    protected float currentHealth;

    public FreezeEffect freezeEffect;


    // Start is called before the first frame update
    public virtual void Start()
    {
        freezeEffect = GetComponent<FreezeEffect>();
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
