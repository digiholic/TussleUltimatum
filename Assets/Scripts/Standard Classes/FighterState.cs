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

    protected FighterCharacterController fighter;

    public virtual void OnStateEnter(FighterCharacterController fighter) {
        this.fighter = fighter;
        OnStateEnterSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }
    public virtual void BeforeCharacterUpdate(float deltaTime) {
        BeforeUpdateSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }
    public virtual void OnStateUpdate() {
        OnStateUpdateSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }
    public virtual void AfterCharacterUpdate(float deltaTime) {
        AfterCharacterUpdateSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }
    public virtual void OnStateExit() {
        OnStateExitSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }
    public virtual void OnLanded() {
        OnLandedSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }
    public virtual void OnLeaveStableGround() {
        OnLeaveStableGroundSubactions.ForEach(subaction => subaction.Execute(fighter, this));
    }

    public virtual void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime) { }
    public virtual void ReceiveAnimatorMessage(string message){ }
}