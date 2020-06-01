using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemBossAI : GolemBossStateMachine
{
    public GolemBoss golemBoss;
    public Animator animator;
    public NavMeshAgent agent;
    public float agentVelocity;
    public Rigidbody rb;



    

    // Start is called before the first frame update
    void Start()
    {
        golemBoss = GetComponent<GolemBoss>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agentVelocity = agent.speed;
        rb = GetComponent<Rigidbody>();

        SetState(new GolemBossBegin(this));
        StartCoroutine(SetPosition());
    }



    IEnumerator SetPosition()
    {
        yield return new WaitForSeconds(2f);
        agent.Warp(transform.position);
    }


    public void PlayerArrived()
    {
        agent.Warp(transform.position);
        SetState(new GolemBossCharge(this));
    }

    // Update is called once per frame
    void Update()
    {
        if(state!=null)
        {
            state.Update();
        }
    }



    public void SetRandomState()
    {
        int rand = Random.Range(0, 4);

        
        switch(rand)
        {
            case 0:
                SetState( new GolemBossThrowFireRock(this));
                break;
            case 1:
                SetState(new GolemBossThrowIceRock(this));
                break;
            case 2:
                SetState(new GolemBossCharge(this));
                break;
            case 3:
                SetState(new GolemBossSpinAttack(this));
                break;
            case 4:
                break;
            default:
                SetState(new GolemBossCharge(this));
                break;
        }

        
    }

}
