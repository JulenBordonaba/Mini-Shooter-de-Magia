using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBossStateMachine : MonoBehaviour
{
    public GolemBossState state;

    public void SetState(GolemBossState _state)
    {
        state = _state;
        StartCoroutine(state.Start());
    }

    
}
