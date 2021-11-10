using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Subaction;

public class FighterState : AbstractFighterState
{
    public string name;

    public override int CurrentFrame { get; set; }

    public List<SubactionBase> OnStateEnterSubactions;
    public List<SubactionBase> BeforeUpdateSubactions;
    public List<SubactionBase> OnStateUpdateSubactions;
    public List<SubactionBase> AfterCharacterUpdateSubactions;
    public List<SubactionBase> OnStateExitSubactions;
    public List<SubactionBase> OnLandedSubactions;
    public List<SubactionBase> OnLeaveStableGroundSubactions;
    
    public override void OnStateEnter() { }
    public override void BeforeCharacterUpdate(float deltaTime) { }
    public override void OnStateUpdate() { }
    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime) { }
    public override void AfterCharacterUpdate(float deltaTime) { }
    public override void OnStateExit() { }
    public override void OnLanded() { }
    public override void OnLeaveStableGround() { }
    
    public override void ReceiveAnimatorMessage(string message){ }
}