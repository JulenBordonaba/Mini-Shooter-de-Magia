using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public KeyCode useKey = KeyCode.None;
    public float cooldown = 0f;

    protected bool inCooldown = false;


    public Animator animator;

    public virtual void Cast()
    {
        if (inCooldown) return;
    }

    protected virtual void Use()
    {

    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        inCooldown = false;
    }


}
