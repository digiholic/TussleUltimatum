using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An object that has an Action state machine.
/// </summary>
public interface IActionedObject
{
    /// <summary>
    /// Gets the action this object is currently in
    /// </summary>
    /// <returns>The current action</returns>
    TAction GetCurrentAction();

    /// <summary>
    /// Changes to the new Action
    /// </summary>
    /// <param name="newAction">the new action to change to</param>
    void SetCurrentAction(TAction newAction);
}
