using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFighterState : AbstractFighterState
{
    private FighterCharacterController fighter;

    public override int CurrentFrame { get; set; }
    public int jumpStartFrame = 0;

    public JumpFighterState(FighterCharacterController fighter)
    {
        this.fighter = fighter;
    }
    public override void OnStateEnter()
    {
        fighter.PlayAnimation(AnimationName.JUMPSQUAT);
        CurrentFrame = 0;
    }

    public override void AfterCharacterUpdate(float deltaTime) { }
    public override void BeforeCharacterUpdate(float deltaTime) { }
    public override void OnStateUpdate() {
        CurrentFrame++;
    }

    public override void OnStateExit() { }

    public override void OnLanded() { }
    public override void OnLeaveStableGround() { }

    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {

    }

    public override void ReceiveAnimatorMessage(string message)
    {
        switch (message)
        {
            case "JumpFrame":
                fighter.ForceUnground();
                fighter.velocity.y = fighter.inputs.jumpHeld ? fighter.jump : fighter.jump / 2;
                Debug.Log($"Jumping on {CurrentFrame}");
                break;
            case "LandDone":
                fighter.ChangeState("Idle");
                break;
        }
    }
}
