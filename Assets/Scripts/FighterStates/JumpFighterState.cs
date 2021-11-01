using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFighterState : AbstractFighterState
{
    private FighterCharacterController fighter;

    public JumpFighterState(FighterCharacterController fighter)
    {
        this.fighter = fighter;
    }
    public override void OnStateEnter() {
        Debug.Log("Enterring Jump State");
        fighter.animator.Play("Jumpsquat");
        fighter.velocity.y = fighter.jump;
        fighter.Motor.ForceUnground();
    }
    
    public override void AfterCharacterUpdate(float deltaTime) { }
    public override void BeforeCharacterUpdate(float deltaTime) { }
    public override void OnStateUpdate() { }

    public override void OnStateExit() { }

    public override void OnLanded() {
        fighter.ChangeState("Idle");
    }
    public override void OnLeaveStableGround() { }
    
    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime) {

    }
}
