using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCristal : EnemyCrystal
{
    public GameObject poisonEffect;
    public float delay = 1f;

    public float posionDuration = 10f;





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

    IEnumerator DespawnEffect(GameObject effect)
    {
        yield return new WaitForSeconds(posionDuration);
        effect.GetComponent<Animator>().SetTrigger("Disappear");
    }

    IEnumerator SpawnEffect(Transform targetTransform)
    {
        yield return new WaitForSeconds(delay);

        GameObject effect = Instantiate(poisonEffect, new Vector3(targetTransform.position.x, 0.01f, targetTransform.position.z), Quaternion.identity);
        StartCoroutine(DespawnEffect(effect));

    }
}
