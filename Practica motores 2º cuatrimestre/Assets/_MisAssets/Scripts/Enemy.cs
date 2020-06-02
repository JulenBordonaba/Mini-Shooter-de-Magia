using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Entity
{

    public GameObject drop;


    public override void Kill()
    {
        if (drop)
        {
            Instantiate(drop, transform.position, transform.rotation);
        }
        gameObject.SetActive(false);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
