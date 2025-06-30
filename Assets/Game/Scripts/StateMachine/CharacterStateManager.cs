using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    CharacterBaseState CurrentState;
    public CharacterIdleState IdleState = new CharacterIdleState();
    public CharacterRunState RunState = new CharacterRunState();
    public CharacterJumpState JumpState = new CharacterJumpState();
    public CharacterAttackState AttackState = new CharacterAttackState();
    public CharacterSlideState SlideState = new CharacterSlideState();
    public CharacterDeathState DeathState = new CharacterDeathState();
    public CharacterStateEdgeGrab EdgeGrabState = new CharacterStateEdgeGrab();
    public CharacterStateEdgeIdle EdgeIdelState = new CharacterStateEdgeIdle();
    public CharacterStateHurt HurtState = new CharacterStateHurt();
    public CharacterStateFall FallState = new CharacterStateFall();
    public CharacterStateLadder LadderState = new CharacterStateLadder();

    public Animator anim;
    private void Start()
    {
        CurrentState = IdleState;

        CurrentState.EnterState(this);
    }

    private void Update()
    {
        CurrentState.UpdateState(this);

    }

    public void ChangeState(CharacterBaseState state)
    {
        CurrentState = state;
        state.EnterState(this);
    }

    public void ProcessInput()
    {
        PlayerController.Instance.ProcessInput();
        anim.SetBool("Run", PlayerController.Instance.IsRun);
    }

    public void Jump()
    {
        PlayerController.Instance.Jump();
    }

    public void Attack()
    {
        SetTrig("Attack");
    }

    public void Slide()
    {
        SetTrig("Slide");
    }

    public void Death()
    {

    }

    public void SetInt(string name, int value)
    {
        anim.SetInteger(name, value);
    }

    public void SetTrig(string name)
    {
        anim.SetTrigger(name);
    }
}
