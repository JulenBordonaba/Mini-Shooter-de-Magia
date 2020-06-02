using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBossThrowFireRock : GolemBossState
{
    public float stopDistance = 8f;
    

    public GolemBossThrowFireRock(GolemBossAI golemBossAI) : base(golemBossAI)
    {

    }

    public override IEnumerator Start()
    {
        Debug.Log("Fuego");
        yield return null;
        golemBossAI.animator.SetTrigger("FireRock");
        //golemBossAI.golemBoss.ShotFire();
        yield return new WaitForSeconds(3f);
        golemBossAI.SetRandomState();
        yield break;
    }

    public override void Update()
    {
        base.Update();
        golemBossAI.agent.SetDestination(PlayerManager.instance.transform.position);
        

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
