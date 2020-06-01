using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBossBegin : GolemBossState
{
    public GolemBossBegin(GolemBossAI golemBossAI) : base(golemBossAI)
    {

    }

    public override IEnumerator Start()
    {
        golemBossAI.animator.SetTrigger("Begin");
        yield return new WaitForSeconds(1.5f);
        //golemBossAI.SetState()
    }
}
