using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Entity
{
    

    public override void Kill()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
