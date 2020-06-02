using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{

    public float damage = 10;

    public string targetTag = "Enemy";

    public List<Entity> hittedEntities = new List<Entity>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            if(other.GetComponentInParent<Entity>())
            {
                Entity e = other.GetComponentInParent<Entity>();
                if(!hittedEntities.Contains(e))
                {
                    hittedEntities.Add(e);
                    e.TakeDamage(damage);
                }
                
            }
        }
    }

}
