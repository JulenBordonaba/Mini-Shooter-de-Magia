using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{

    public float damage = 10;

    public string targetTag = "Enemy";


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            other.GetComponentInParent<Entity>()?.TakeDamage(damage);
        }
    }

}
