using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmashInteraction : IInputInteraction
{
    public float duration = 0.05f;
    public float deadZone = 0.1f;
    public float smashZone = 0.95f;

    private double timeStartedMoving = 0f;
    private bool hasStarted = false;
    public void Process(ref InputInteractionContext context)
    {
        Vector2 stickPos = context.ReadValue<Vector2>();

        if (context.timerHasExpired)
            context.Canceled();
        
        if (stickPos.magnitude < deadZone)
        {
            hasStarted = false;
            context.Canceled();
        }
        switch (context.phase)
        {
            case InputActionPhase.Waiting:
                if (stickPos.magnitude > deadZone && !hasStarted)
                {
                    context.Started();
                    timeStartedMoving = context.time;
                    hasStarted = true;
                }
                break;
            case InputActionPhase.Started:
                if ((context.time - timeStartedMoving) > duration || stickPos.magnitude <= deadZone)
                {
                    context.Canceled();
                }
                if (stickPos.magnitude >= smashZone)
                {
                    context.Performed();
                    context.SetTimeout(0.1f);
                }
                break;
        }
    }

    public void Reset() { }
}