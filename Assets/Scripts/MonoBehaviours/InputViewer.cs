using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputViewer : MonoBehaviour
{
    [Header("Jopysticks")]
    public RectTransform joystick_knob;
    public TrailRenderer joystick_trail;

    [Header("Buttons")]
    public Image attackButton;
    public Image specialButton;
    public Image jumpButton;
    public Image shieldButton;
    public Image grabButton;


    private TussleInput inputs;
    // Start is called before the first frame update
    void Awake()
    {
        inputs = new TussleInput();
        inputs.Fighter.Move.performed += JoystickMoved;
        inputs.Fighter.Move.canceled  += JoystickMoved;

        inputs.Fighter.Smash.performed += StickSmash;
        inputs.Fighter.Smash.canceled  += StickSmash;

        inputs.Fighter.Attack.started   += (context) => ButtonPressed(attackButton, context);
        inputs.Fighter.Attack.performed += (context) => ButtonPressed(attackButton, context);
        inputs.Fighter.Attack.canceled  += (context) => ButtonPressed(attackButton, context);

        inputs.Fighter.Special.started   += (context) => ButtonPressed(specialButton, context);
        inputs.Fighter.Special.performed += (context) => ButtonPressed(specialButton, context);
        inputs.Fighter.Special.canceled  += (context) => ButtonPressed(specialButton, context);

        inputs.Fighter.Jump.started   += (context) => ButtonPressed(jumpButton, context);
        inputs.Fighter.Jump.performed += (context) => ButtonPressed(jumpButton, context);
        inputs.Fighter.Jump.canceled  += (context) => ButtonPressed(jumpButton, context);

        inputs.Fighter.Shield.started   += (context) => ButtonPressed(shieldButton, context);
        inputs.Fighter.Shield.performed += (context) => ButtonPressed(shieldButton, context);
        inputs.Fighter.Shield.canceled  += (context) => ButtonPressed(shieldButton, context);

        inputs.Fighter.Grab.started   += (context) => ButtonPressed(grabButton, context);
        inputs.Fighter.Grab.performed += (context) => ButtonPressed(grabButton, context);
        inputs.Fighter.Grab.canceled  += (context) => ButtonPressed(grabButton, context);
        inputs.Enable();
    }

    private void JoystickMoved(InputAction.CallbackContext context)
    {
        Vector2 stickPos = context.ReadValue<Vector2>();
        float anchorX = Mathf.InverseLerp(-1f, 1f, stickPos.x);
        float anchorY = Mathf.InverseLerp(-1f, 1f, stickPos.y);
        joystick_knob.anchorMin = new Vector2(anchorX, anchorY);
        joystick_knob.anchorMax = new Vector2(anchorX, anchorY);
        joystick_knob.anchoredPosition = Vector2.zero;
    }

    private void StickSmash(InputAction.CallbackContext context)
    {
        if (context.performed)
            joystick_trail.material.color = Color.green;
        if (context.canceled)
            joystick_trail.material.color = Color.white;
    }

    private void ButtonPressed(Image buttonImage, InputAction.CallbackContext context)
    {
        if (context.started)
            buttonImage.color = Color.yellow;
        if (context.performed)
            buttonImage.color = Color.green;
        if (context.canceled)
            buttonImage.color = Color.red;
    }

    public void RemapButton()
    {
        inputs.Disable();
        inputs.Fighter.Attack.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .Start()
            .OnComplete(_=> inputs.Enable());
    }
}
