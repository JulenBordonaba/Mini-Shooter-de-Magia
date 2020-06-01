using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBossCharge : GolemBossState
{
    public float stopDistance = 5f;

    private Vector3 goal;

    bool chargeStart = false;
    public GolemBossCharge(GolemBossAI golemBossAI) : base(golemBossAI)
    {

    }

    public override IEnumerator Start()
    {
        Debug.Log("Sprint");
        yield return null;
        golemBossAI.agent.speed = 0;

        yield return new WaitForSeconds(0.5f);
        chargeStart = true;
        golemBossAI.animator.SetBool("Charge",true);
        goal = PlayerManager.instance.transform.position;
        golemBossAI.agent.SetDestination(goal);
        golemBossAI.agent.speed = golemBossAI.golemBoss.sprintSpeed;
        golemBossAI.golemBoss.chargeObject.SetActive(true);
        yield break;
    }

    public override void Update()
    {
        if (!chargeStart)
        {
            Vector3 goalDirection = goal - golemBossAI.transform.position;
            golemBossAI.rb.MoveRotation(Quaternion.Euler(0, goalDirection.x,0));
            return;
        }
        if (golemBossAI.golemBoss.freezeEffect.freezed)
        {
            golemBossAI.agent.speed = 0f;
            hasBeenFreezed = true;
        }
        else
        {
            if(hasBeenFreezed)
            {
                golemBossAI.agent.speed = golemBossAI.agentVelocity;
                golemBossAI.golemBoss.chargeObject.SetActive(false);
                golemBossAI.animator.SetBool("Charge", false);
                golemBossAI.SetRandomState();
            }
        }

        if (GoalDistance < stopDistance || ObjectiveDistance < stopDistance)
        {
            golemBossAI.agent.speed = golemBossAI.agentVelocity;
            golemBossAI.golemBoss.chargeObject.SetActive(false);
            golemBossAI.animator.SetBool("Charge", false);
            golemBossAI.SetRandomState();
        }
    }

    public float ObjectiveDistance
    {
        get { return Vector3.Distance(golemBossAI.transform.position, PlayerManager.instance.transform.position); }
    }

    public float GoalDistance
    {
        get { return Vector3.Distance(golemBossAI.transform.position,goal); }
    }
}
