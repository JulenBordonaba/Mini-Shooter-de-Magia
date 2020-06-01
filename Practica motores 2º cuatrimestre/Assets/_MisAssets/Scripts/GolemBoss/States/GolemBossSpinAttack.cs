using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBossSpinAttack : GolemBossState
{
    public GolemBossSpinAttack(GolemBossAI golemBossAI) : base(golemBossAI)
    {

    }

    public override IEnumerator Start()
    {
        yield return null;

        golemBossAI.animator.SetTrigger("Spin");
        
        golemBossAI.agent.SetDestination(PlayerManager.instance.transform.position);


        golemBossAI.agent.speed = golemBossAI.golemBoss.spintSpeed;
        golemBossAI.golemBoss.spinObject.SetActive(true);


        yield return new WaitForSeconds(2f);
        
        golemBossAI.agent.speed = golemBossAI.agentVelocity;
        golemBossAI.golemBoss.spinObject.SetActive(false);


        yield return new WaitForSeconds(0.5f);

        golemBossAI.SetRandomState();


    }

    public override void Update()
    {
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

        golemBossAI.agent.SetDestination(PlayerManager.instance.transform.position);
    }
}
