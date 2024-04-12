using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager state)
    {
        state.Attack();
        Debug.Log("attack-ing enter");
    }

    public override void LeaveState(CharacterStateManager state)
    {
        Debug.Log("attack-ing leave");
    }

    public override void UpdateState(CharacterStateManager state)
    {
        state.ChangeState(state.IdleState);
        Debug.Log("attack-ing update");
    }
}
