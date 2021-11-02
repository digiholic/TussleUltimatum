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
    public override void OnStateEnter()
    {
        Debug.Log("Enterring Jump State");
        fighter.animator.Play("Jumpsquat");
    }

    public override void AfterCharacterUpdate(float deltaTime) { }
    public override void BeforeCharacterUpdate(float deltaTime) { }
    public override void OnStateUpdate() { }

    public override void OnStateExit() { }

    public override void OnLanded()
    {

    }
    public override void OnLeaveStableGround() { }

    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {

    }

    public override void ReceiveAnimatorMessage(string message)
    {
        switch (message)
        {
            case "JumpFrame":
                fighter.Motor.ForceUnground();
                fighter.velocity.y = fighter.inputs.jumpHeld ? fighter.jump : fighter.jump / 2;
                break;
            case "LandDone":
                fighter.ChangeState("Idle");
                break;
        }
    }
}
