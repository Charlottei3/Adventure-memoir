using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterJumpState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager state)
    {
        state.anim.SetBool("Jump", true);
        state.Jump();
    }

    public override void LeaveState(CharacterStateManager state)
    {

    }

    public override void UpdateState(CharacterStateManager state)
    {
        state.ChangeState(state.FallState);
    }
}
