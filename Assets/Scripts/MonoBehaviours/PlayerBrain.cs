﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

/// <summary>
/// The PlayerBrain is an implementation of IBrain that reads input for a player and generates Thoughts from them
/// </summary>
public class PlayerBrain : MonoBehaviour, IBrain
{
    public InputPackage workingInputs;
    public int playerId;

    private Player player;

    void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);

        player.AddInputEventDelegate(OnJumpPressed, UpdateLoopType.Update, InputActionEventType.ButtonJustPressed,"Jump");
        player.AddInputEventDelegate(OnJumpReleased, UpdateLoopType.Update, InputActionEventType.ButtonJustReleased, "Jump");

        player.AddInputEventDelegate(OnMoveHorizontal, UpdateLoopType.Update, InputActionEventType.AxisActiveOrJustInactive, "MovementHorizontal");
    }

    void OnJumpPressed(InputActionEventData data)
    {
        workingInputs.jumpPressed = true;
        workingInputs.jumpHeld = true;
    }

    void OnJumpReleased(InputActionEventData data)
    {
        workingInputs.jumpReleased = true;
        workingInputs.jumpHeld = false;
    }

    void OnMoveHorizontal(InputActionEventData data)
    {
        workingInputs.hAxis = data.GetAxis();
    }

    public void Think(out InputPackage inputs)
    {
        inputs = workingInputs;
        workingInputs.ResetPressReleased();
    }

    void OnDestroy()
    {
        player.RemoveInputEventDelegate(OnJumpPressed);
        player.RemoveInputEventDelegate(OnJumpReleased);
        player.RemoveInputEventDelegate(OnMoveHorizontal);
    }
}
