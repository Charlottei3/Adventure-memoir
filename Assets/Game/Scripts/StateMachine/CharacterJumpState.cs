using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager state)
    {
        state.Jump();
        Debug.Log("jump-ing enter");
    }

    public override void LeaveState(CharacterStateManager state)
    {
        Debug.Log("jump-ing leave");
    }

    public override void UpdateState(CharacterStateManager state)
    {
        state.ChangeState(state.IdleState);
        Debug.Log("jump-ing update");
    }
}
