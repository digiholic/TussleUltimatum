using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugIdleState : FighterState
{
    public DebugIdleState()
    {
        name = "Idle";
    }

    public override void OnStateEnter(FighterCharacterController fighter)
    {
        this.fighter = fighter;
        Debug.Log("Loaded debug Idle State");
    }
    public override void BeforeCharacterUpdate(float deltaTime)
    {
        
    }
    public override void OnStateUpdate()
    {
        
    }
    public override void AfterCharacterUpdate(float deltaTime)
    {
        
    }
    public override void OnStateExit()
    {
        
    }
    public override void OnLanded()
    {
        
    }
    public override void OnLeaveStableGround()
    {
        
    }

    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime) { }
    public override void ReceiveAnimatorMessage(string message) { }
}
