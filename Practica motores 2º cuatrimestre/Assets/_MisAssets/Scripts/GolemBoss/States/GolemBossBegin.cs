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
        yield return null;
        //golemBossAI.SetState()
    }

    public override void Update()
    {
        base.Update();
        golemBossAI.rb.angularVelocity = Vector3.zero;
    }
}
