using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager state)
    {
        state.Jump();

    }

    public override void LeaveState(CharacterStateManager state)
    {

    }

    public override void UpdateState(CharacterStateManager state)
    {
        state.ChangeState(state.IdleState);

    }
}
