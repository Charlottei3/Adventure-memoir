using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager state)
    {
        state.SetInt("Def", 0);
        Debug.Log("idle-ing enter");
    }

    public override void LeaveState(CharacterStateManager state)
    {
        Debug.Log("idle-ing leave");
    }

    public override void UpdateState(CharacterStateManager state)
    {
        state.ChangeState(state.RunState);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            state.ChangeState(state.JumpState);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            state.ChangeState(state.AttackState);
        }

        Debug.Log("idle-ing update");

    }
}
