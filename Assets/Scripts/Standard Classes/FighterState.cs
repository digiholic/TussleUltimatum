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
    [SerializeReference] public List<SubactionBase> BeforeUpdateSubactions = new List<SubactionBase>();
    [SerializeReference] public List<SubactionBase> OnStateUpdateSubactions = new List<SubactionBase>();
    [SerializeReference] public List<SubactionBase> AfterCharacterUpdateSubactions = new List<SubactionBase>();
    [SerializeReference] public List<SubactionBase> OnStateExitSubactions = new List<SubactionBase>();
    [SerializeReference] public List<SubactionBase> OnLandedSubactions = new List<SubactionBase>();
    [SerializeReference] public List<SubactionBase> OnLeaveStableGroundSubactions = new List<SubactionBase>();

    private FighterCharacterController fighter;

    public void OnStateEnter(FighterCharacterController fighter) {
        this.fighter = fighter;
        OnStateEnterSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }
    public void BeforeCharacterUpdate(float deltaTime) {
        BeforeUpdateSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }
    public void OnStateUpdate() {
        OnStateUpdateSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }
    public void AfterCharacterUpdate(float deltaTime) {
        AfterCharacterUpdateSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }
    public void OnStateExit() {
        OnStateExitSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }
    public void OnLanded() {
        OnLandedSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }
    public void OnLeaveStableGround() {
        OnLeaveStableGroundSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime) { }
    public void ReceiveAnimatorMessage(string message){ }
}