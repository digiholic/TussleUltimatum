using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct InputPackage
{
    public float hAxis, vAxis;

    public bool jumpPressed;

    public bool jumpHeld;

    public bool jumpReleased;

    public void ResetPressReleased()
    {
        jumpPressed = false;
        jumpReleased = false;
    }
}
