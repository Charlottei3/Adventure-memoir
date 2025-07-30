using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager state)
    {
        state.anim.SetBool("Jump", false);
        state.SetInt("Def", 0);
    }

    public override void LeaveState(CharacterStateManager state)
    {

    }

    public override void UpdateState(CharacterStateManager state)
    {
        state.ChangeState(state.RunState);

        if (Input.GetKeyDown(KeyCode.W))
        {
            state.ChangeState(state.JumpState);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            state.ChangeState(state.AttackState);
        }
        state.anim.SetBool("Wall", false);
    }
}
