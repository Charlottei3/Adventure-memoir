using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDeathState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager state)
    {
        Debug.Log("death-ing enter");
    }

    public override void LeaveState(CharacterStateManager state)
    {
        Debug.Log("death-ing leave");
    }

    public override void UpdateState(CharacterStateManager state)
    {
        Debug.Log("death-ing update");
    }
}
