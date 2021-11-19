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
    [SerializeReference] public List<SubactionBase> BeforeUpdateSubactions;
    [SerializeReference] public List<SubactionBase> OnStateUpdateSubactions;
    [SerializeReference] public List<SubactionBase> AfterCharacterUpdateSubactions;
    [SerializeReference] public List<SubactionBase> OnStateExitSubactions;
    [SerializeReference] public List<SubactionBase> OnLandedSubactions;
    [SerializeReference] public List<SubactionBase> OnLeaveStableGroundSubactions;
    
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