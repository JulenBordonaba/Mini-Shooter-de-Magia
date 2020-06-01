using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Entity
{
    public static PlayerManager instance;

    public Rigidbody rb;
    

    public bool boosted = false;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Booster"))
        {
            boosted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Booster"))
        {
            boosted = false;
        }
    }

    public bool Freezed
    {
        get { return freezeEffect.freezed; }
    }
}
