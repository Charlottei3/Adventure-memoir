using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRunState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager state)
    {
        state.ProcessInput();

    }

    public override void LeaveState(CharacterStateManager state)
    {

    }

    public override void UpdateState(CharacterStateManager state)
    {
        state.ChangeState(state.IdleState);
        if (Input.GetKey(KeyCode.S))
        {
            state.ChangeState(state.SlideState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            state.ChangeState(state.JumpState);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            state.ChangeState(state.AttackState);
        }

    }
}
