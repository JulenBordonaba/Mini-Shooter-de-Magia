using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBossThrowIceRock : GolemBossState
{
    public float stopDistance = 5f;
    

    public GolemBossThrowIceRock(GolemBossAI golemBossAI) : base(golemBossAI)
    {

    }

    public override IEnumerator Start()
    {
        Debug.Log("Hielo");
        yield return null;
        golemBossAI.animator.SetTrigger("IceRock");
        //golemBossAI.golemBoss.ShotIce();
        yield return new WaitForSeconds(3f);
        golemBossAI.SetState(new GolemBossThrowFireRock(golemBossAI));
        yield break;
    }

    public override void Update()
    {
        base.Update();
        golemBossAI.agent.SetDestination(PlayerManager.instance.transform.position);

        //if (ObjectiveDistance < stopDistance + 2 && !golemBossAI.golemBoss.freezeEffect.freezed)
        //{
        //    if (golemBossAI.canShot)
        //    {
        //        golemBossAI.Shot();
        //    }
        //}
        if (golemBossAI.golemBoss.freezeEffect.freezed)
        {
            golemBossAI.agent.speed = 0f;
            hasBeenFreezed = true;
        }
        else
        {
            if (hasBeenFreezed)
            {
                golemBossAI.agent.speed = golemBossAI.agentVelocity;
                golemBossAI.golemBoss.chargeObject.SetActive(false);
                golemBossAI.SetRandomState();
            }
        }

        if (golemBossAI.golemBoss.freezeEffect.freezed)
        {
            golemBossAI.agent.speed = 0f;
        }
        else if (ObjectiveDistance < stopDistance)
        {
            golemBossAI.agent.speed = 0.7f;
        }
        else
        {
            golemBossAI.agent.speed = golemBossAI.agentVelocity;
        }

    }


    public float ObjectiveDistance
    {
        get { return Vector3.Distance(golemBossAI.transform.position, PlayerManager.instance.transform.position); }
    }
}
