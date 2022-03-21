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
        Debug.Log("Registering custom inputs");
        InputSystem.RegisterInteraction<SmashInteraction>();
    }
}
