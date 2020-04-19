using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

    public float speed;
    public GameObject hitPrefab;
    public float tiempoActivo;
    private float tiempo = 0;

    private void Update()
    {
        
        Vector3 movimiento = new Vector3(0, 0, 0);
        movimiento += transform.forward;
        movimiento = movimiento.normalized;
        movimiento = movimiento * speed * GetComponent<Rigidbody>().mass;
        gameObject.GetComponent<Rigidbody>().velocity = movimiento;
        tiempo += Time.deltaTime;
        if(tiempo>tiempoActivo)
        {
            SpawnHitPrefab();
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            speed = 0;

            if (hitPrefab)
            {
                SpawnHitPrefab();
            }
            Destroy(gameObject);
        }
    }

    private void SpawnHitPrefab()
    {
        GameObject hitVFX = Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
        ParticleSystem psHitVFX = hitVFX.GetComponent<ParticleSystem>();
        if (psHitVFX)
        {
            Destroy(hitVFX, psHitVFX.main.duration);
        }
        else
        {
            psHitVFX = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
            if (psHitVFX)
            {
                Destroy(hitVFX, psHitVFX.main.duration);
            }
        }
    }
    
}
