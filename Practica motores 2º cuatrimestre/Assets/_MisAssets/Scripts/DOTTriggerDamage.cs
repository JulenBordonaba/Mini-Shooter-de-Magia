using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTTriggerDamage : MonoBehaviour
{
    public float damagePerSecond = 10;

    public string targetTag = "Enemy";

    public List<Entity> targets = new List<Entity>();
    

    private void Update()
    {
        foreach(Entity e in targets)
        {
            e.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            if(other.GetComponentInParent<Entity>())
            {
                Entity e = other.GetComponentInParent<Entity>();
                if (!targets.Contains(e))
                {
                    targets.Add(e);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Entity>())
        {
            Entity e = other.GetComponentInParent<Entity>();
            if (targets.Contains(e))
            {
                targets.Remove(e);
            }
        }
    }

}
