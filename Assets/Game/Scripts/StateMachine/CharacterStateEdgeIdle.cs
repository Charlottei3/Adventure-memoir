using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateEdgeIdle : CharacterBaseState
{
    public override void EnterState(CharacterStateManager state)
    {
        state.anim.SetBool("Wall", true);
    }

    public override void LeaveState(CharacterStateManager state)
    {
        state.anim.SetBool("Wall", false);
    }

    public override void UpdateState(CharacterStateManager state)
    {
        state.anim.SetBool("Wall", true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerController.Instance.WallJump();
            state.ChangeState(state.EdgeGrabState);
            return;
        }

        if (!PlayerController.Instance.IsWalled)
        {
            state.SetTrig("EdgeGrab");
            state.ChangeState(state.IdleState);
        }
        Debug.Log("wall");
    }
}
