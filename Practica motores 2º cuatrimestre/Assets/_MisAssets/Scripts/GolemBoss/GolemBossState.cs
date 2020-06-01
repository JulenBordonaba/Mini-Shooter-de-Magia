using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBossState 
{

    protected GolemBossAI golemBossAI;

    protected bool hasBeenFreezed = false;

    public GolemBossState(GolemBossAI _golemBossAI) 
    {
        golemBossAI = _golemBossAI;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual void Update()
    {
        
    }


    public virtual IEnumerator Exit()
    {
        yield break;
    }
}
