using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleFighterState : AbstractFighterState
{
    private FighterCharacterController fighter;

    public IdleFighterState(FighterCharacterController fighter)
    {
        this.fighter = fighter;
    }

    public override void OnStateEnter() {
        Debug.Log("Idle StateEnterred");
        fighter.animator.Play("Idle");
    }

    public override void OnStateExit() { }

    public override void AfterCharacterUpdate(float deltaTime) { }
    public override void BeforeCharacterUpdate(float deltaTime) { }
    public override void OnStateUpdate() {
        if (fighter.inputs.jumpPressed)
        {
            fighter.ChangeState("Jump");
        }
    }

    public override void OnLanded() { }
    public override void OnLeaveStableGround() { }

    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime) { }
}
