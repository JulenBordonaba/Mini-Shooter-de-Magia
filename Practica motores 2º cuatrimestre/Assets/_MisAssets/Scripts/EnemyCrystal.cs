using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrystal : Enemy
{
    public float cooldown = 3f;
    public Animator animator;

    protected bool inCooldown = false;

    public List<PlayerController> playersInRange = new List<PlayerController>();
    

    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        Spell();
    }

    public virtual void Spell()
    {
        
    }
    
    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        inCooldown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<PlayerController>())
        {
            playersInRange.Add( other.GetComponentInParent<PlayerController>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>())
        {
            PlayerController pc = other.GetComponentInParent<PlayerController>();
            if(playersInRange.Contains(pc))
            {
                playersInRange.Remove(pc);
            }
        }
    }


}
