using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFighterState : AbstractFighterState
{
    private FighterCharacterController fighter;

    public override int CurrentFrame { get; set; }

    public MoveFighterState(FighterCharacterController fighter)
    {
        this.fighter = fighter;
    }

    public override void AfterCharacterUpdate(float deltaTime) { }
    public override void BeforeCharacterUpdate(float deltaTime) { }
    public override void OnStateUpdate() { }

    public override void OnLanded() { }
    public override void OnLeaveStableGround() { }
    public override void OnStateEnter() { }

    public override void OnStateExit() { }
    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime) {
        fighter.velocity.x = fighter.inputs.hAxis * fighter.speed;
    }

    public override void ReceiveAnimatorMessage(string message) { }
}
