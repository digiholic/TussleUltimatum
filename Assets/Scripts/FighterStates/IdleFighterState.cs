using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleFighterState : AbstractFighterState
{
    private FighterCharacterController fighter;

    public override int CurrentFrame { get; set; }

    public IdleFighterState(FighterCharacterController fighter)
    {
        this.fighter = fighter;
    }

    public override void OnStateEnter() {
        fighter.PlayAnimation(AnimationName.IDLE);
        CurrentFrame = 0;
    }

    public override void OnStateExit() { }

    public override void AfterCharacterUpdate(float deltaTime) { }
    public override void BeforeCharacterUpdate(float deltaTime) { }
    public override void OnStateUpdate() {
        if (fighter.inputs.jumpPressed)
        {
            fighter.ChangeState("Jump");
        }

        CurrentFrame++;
    }

    public override void OnLanded() { }
    public override void OnLeaveStableGround() { }

    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime) { }

    public override void ReceiveAnimatorMessage(string message) { }
}
