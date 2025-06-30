using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateEdgeGrab : CharacterBaseState
{
    public override void EnterState(CharacterStateManager state)
    {
        state.anim.SetBool("Wall", false);
        state.SetTrig("EdgeGrab");
    }

    public override void LeaveState(CharacterStateManager state)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(CharacterStateManager state)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            state.ChangeState(state.JumpState);
        }
        //state.ProcessInput();

        if (PlayerController.Instance.IsGrounded)
        {
            state.ChangeState(state.IdleState);
        }
    }
}
