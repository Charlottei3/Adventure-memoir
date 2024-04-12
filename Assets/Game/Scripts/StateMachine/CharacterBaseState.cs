using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseState
{
    public abstract void EnterState(CharacterStateManager state);

    public abstract void UpdateState(CharacterStateManager state);

    public abstract void LeaveState(CharacterStateManager state);
}
