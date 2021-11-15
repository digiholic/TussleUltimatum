using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Subactions;

[CreateAssetMenu(fileName ="Subaction",menuName ="Tussle/Subactions/Subaction Definition Card")]
public class SubactionDefinitionCard : ScriptableObject {
    public string SubactionName;
}
[System.Serializable]
public class ChangeXSpeed : SubactionBase
{
    public float newXValue;
    public bool relative;

    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        if (relative) fighter.velocity.x += newXValue;
        else fighter.velocity.x = newXValue;
    }
}
[System.Serializable]
public class ChangeXTargetSpeed : SubactionBase
{
    public float newXValue;
    public bool relative;

    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        if (relative) fighter.targetVelocity.x += newXValue;
        else fighter.targetVelocity.x = newXValue;
    }
}
[System.Serializable]
public class ChangeYSpeed : SubactionBase
{
    public float newYValue;
    public bool relative;

    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        if (relative) fighter.velocity.y += newYValue;
        else fighter.velocity.y = newYValue;
    }
}
[System.Serializable]
public class ChangeYTargetSpeed : SubactionBase
{
    public float newYValue;
    public bool relative;

    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        if (relative) fighter.targetVelocity.y += newYValue;
        else fighter.targetVelocity.y = newYValue;
    }
}
[System.Serializable]
public class Accelerate : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class ShiftXPosition : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class ShiftYPosition : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class CreateHitbox : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class ActivateHitbox : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class DeactivateHitbox : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class ModifyHitbox : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class ChargeHitbox : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class ChangeState : SubactionBase
{
    public string StateName;

    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        fighter.ChangeState(StateName);
    }
}
[System.Serializable]
public class DoTransition : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class IfButtonBuffered : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class IfButtonHeld : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class IfVar : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class Else : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class EndIf : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class InitVar : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class SetVar : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class PassVar : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class PlaySound : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class PrintDebug : SubactionBase
{
    public string message;
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        Debug.Log(message);
    }
}
[System.Serializable]
public class Rotate : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class Unrotate : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class SetAnchor : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class ChangeFrame : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class ChangeAnimation : SubactionBase
{
    public string animationName;

    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        fighter.PlayAnimation(animationName);
    }
}
[System.Serializable]
public class ChangeAnimationTime : SubactionBase
{
    public override void Execute(FighterCharacterController fighter, FighterState state)
    {
        throw new System.NotImplementedException();
    }
}