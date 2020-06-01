using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpell : Spell
{

    public GameObject boostEffectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Cast()
    {
        base.Cast();
        if (inCooldown) return;
        StartCoroutine(Cooldown());

        Instantiate(boostEffectPrefab, PlayerManager.instance.transform.position, Quaternion.identity);
    }

}
