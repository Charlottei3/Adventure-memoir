using UnityEngine;

public abstract class BaseStateMachine
{
    public abstract void EnterState(CharacterStateManager state);

    public abstract void UpdateState(CharacterStateManager state);

    public abstract void LeaveState(CharacterStateManager state);
}
