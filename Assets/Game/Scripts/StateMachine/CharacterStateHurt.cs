using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateHurt : CharacterBaseState
{
    public override void EnterState(CharacterStateManager state)
    {
        state.SetTrig("Hurt");
    }

    public override void LeaveState(CharacterStateManager state)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(CharacterStateManager state)
    {
        state.ChangeState(state.IdleState);
    }
}
