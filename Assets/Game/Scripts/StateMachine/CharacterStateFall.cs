using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterStateFall : CharacterBaseState
{
    public override void EnterState(CharacterStateManager state)
    {
        state.anim.SetBool("Fall", true);
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

        state.ProcessInput();

        if (Input.GetKeyDown(KeyCode.W))
        {
            state.ChangeState(state.JumpState);
        }

        if (PlayerController.Instance.IsGrounded)
        {
            state.ChangeState(state.IdleState);
            state.anim.SetBool("Fall", false);
        }

        Debug.Log("fall");

    }
}
