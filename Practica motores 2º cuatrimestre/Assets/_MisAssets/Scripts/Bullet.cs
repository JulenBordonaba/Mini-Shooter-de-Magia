using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float velocity = 10f;

    public ParticleSystem escenarioParticles;
    public ParticleSystem enemyParticles;

    public GameObject explosionPrefab;

    public bool boosted = false;
    public TriggerDamage triggerDamage;

    private Rigidbody rb;



    private void Start()
    {
        Destroy(gameObject, 3f);
        rb = GetComponent<Rigidbody>();
    }



    private void FixedUpdate()
    {
        Vector3 movement = transform.forward * velocity * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Escenario"))
        {
            if(escenarioParticles)
            {
                Instantiate(escenarioParticles, transform.position, transform.rotation);
            }
        }
        else if(other.CompareTag("Enemy"))
        {
            if(enemyParticles)
            {
                Instantiate(enemyParticles, transform.position, transform.rotation);
            }
        }
        if(boosted)
        {
            Destroy(Instantiate(explosionPrefab, transform.position, transform.rotation),1f);
        }
        Destroy(gameObject);
    }

}
