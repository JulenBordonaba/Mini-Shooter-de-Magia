using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FreezeEffect))]
public class Entity : MonoBehaviour
{
    public float maxHealth = 300;


    public float currentHealth;

    public FreezeEffect freezeEffect;


    // Start is called before the first frame update
    public virtual void Start()
    {
        freezeEffect = GetComponent<FreezeEffect>();
        currentHealth = maxHealth;
    }
    


    public void TakeDamage(float damageAmmount)
    {
        currentHealth -= damageAmmount;
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public virtual void Kill()
    {

    }
}
