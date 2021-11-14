
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AbstractFighterState
{
    public abstract int CurrentFrame { get; set; }

    public abstract void OnStateEnter();
    public abstract void OnStateExit();
    public abstract void OnStateUpdate();

    public abstract void BeforeCharacterUpdate(float deltaTime);
    public abstract void AfterCharacterUpdate(float deltaTime);

    public abstract void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime);

    public abstract void OnLanded();
    public abstract void OnLeaveStableGround();

    public abstract void ReceiveAnimatorMessage(string message);
}