using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCristal : EnemyCrystal
{
    public GameObject fireEffect;
    public float delay = 1f;






    public override void Spell()
    {
        base.Spell();

        if (inCooldown) return;
        if (freezeEffect.freezed) return;
        if (playersInRange.Count <= 0) return;
        inCooldown = true;

        StartCoroutine(Cooldown());

        foreach (PlayerController pc in playersInRange)
        {

            StartCoroutine(SpawnEffect(pc.transform));
        }

        animator.SetTrigger("Cast");
    }
    

    IEnumerator SpawnEffect(Transform targetTransform)
    {
        yield return new WaitForSeconds(delay);

        GameObject effect = Instantiate(fireEffect, new Vector3(targetTransform.position.x, 0.01f, targetTransform.position.z), Quaternion.identity);

    }
}
