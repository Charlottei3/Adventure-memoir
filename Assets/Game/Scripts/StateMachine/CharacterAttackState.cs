using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CharacterAttackState : CharacterBaseState
{

    public override void EnterState(CharacterStateManager state)
    {
        state.Attack();
        PlayerController.Instance.DamageEnemy();
    }

    public override void LeaveState(CharacterStateManager state)
    {

    }

    public override void UpdateState(CharacterStateManager state)
    {
        state.ChangeState(state.IdleState);

    }


}
