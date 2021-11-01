using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorFighterState : AbstractFighterState
{
    private FighterCharacterController fighter;

    public ErrorFighterState(FighterCharacterController fighter)
    {
        this.fighter = fighter;
    }

    public override void AfterCharacterUpdate(float deltaTime) { }
    public override void BeforeCharacterUpdate(float deltaTime) { }
    public override void OnStateUpdate() { }

    public override void OnLanded() { }
    public override void OnLeaveStableGround() { }
    public override void OnStateEnter() {
        Debug.Log($"{fighter.gameObject.name} has enterred a state that does not exist");
        fighter.ChangeState("Idle");
    }

    public override void OnStateExit() { }
    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime) {

    }
}
