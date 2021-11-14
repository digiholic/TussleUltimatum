using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Subactions;

[System.Serializable]
public class FighterState
{
    public string name;

    public int CurrentFrame { get; set; }

    [SerializeReference] public List<SubactionBase> OnStateEnterSubactions = new List<SubactionBase>();
    public List<SubactionBase> BeforeUpdateSubactions;
    public List<SubactionBase> OnStateUpdateSubactions;
    public List<SubactionBase> AfterCharacterUpdateSubactions;
    public List<SubactionBase> OnStateExitSubactions;
    public List<SubactionBase> OnLandedSubactions;
    public List<SubactionBase> OnLeaveStableGroundSubactions;
    
    public void OnStateEnter() { }
    public void BeforeCharacterUpdate(float deltaTime) { }
    public void OnStateUpdate() { }
    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime) { }
    public void AfterCharacterUpdate(float deltaTime) { }
    public void OnStateExit() { }
    public void OnLanded() { }
    public void OnLeaveStableGround() { }
    
    public void ReceiveAnimatorMessage(string message){ }
}