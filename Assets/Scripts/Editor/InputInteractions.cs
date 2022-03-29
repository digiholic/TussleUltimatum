using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;

[InitializeOnLoad]
public class InputInteractions : Editor
{
    static InputInteractions()
    {
        InputSystem.RegisterInteraction<SmashInteraction>();
    }
}
