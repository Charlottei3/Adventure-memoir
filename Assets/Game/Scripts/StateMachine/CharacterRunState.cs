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
        if (PlayerController.Instance.IsWalled)
        {
            state.ChangeState(state.EdgeIdelState);
            return;
        }

        if (Input.GetKey(KeyCode.S))
        {
            state.ChangeState(state.SlideState);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            state.ChangeState(state.JumpState);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            state.ChangeState(state.AttackState);
        }

        state.ChangeState(state.IdleState);
    }
}
