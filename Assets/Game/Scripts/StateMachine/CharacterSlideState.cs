using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSlideState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager state)
    {
        state.Slide();

    }

    public override void LeaveState(CharacterStateManager state)
    {

    }

    public override void UpdateState(CharacterStateManager state)
    {
        state.ChangeState(state.IdleState);

    }
}
