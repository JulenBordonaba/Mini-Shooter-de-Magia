using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FreezeEffect))]
public class Entity : MonoBehaviour
{
    public float maxHealth = 300;


    public float currentHealth;

    public FreezeEffect freezeEffect;

    protected bool canTakeDamage = true;


    // Start is called before the first frame update
    public virtual void Start()
    {
        freezeEffect = GetComponent<FreezeEffect>();
        currentHealth = maxHealth;
    }
    


    public void TakeDamage(float damageAmmount)
    {
        if (!canTakeDamage) return;
        canTakeDamage = false;
        StartCoroutine(DamageInmunityDuration());

        currentHealth -= damageAmmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    protected IEnumerator DamageInmunityDuration()
    {
        yield return new WaitForEndOfFrame();
        canTakeDamage = true;
    }

    public virtual void Kill()
    {

    }
}
