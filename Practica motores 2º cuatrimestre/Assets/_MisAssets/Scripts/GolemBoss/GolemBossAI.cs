using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBossAI : GolemBossStateMachine
{
    public GolemBoss golemBoss;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        SetState(new GolemBossBegin(this));
    }

    // Update is called once per frame
    void Update()
    {
        if(state!=null)
        {
            state.Update();
        }
    }
}
