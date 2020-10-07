using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Battle Object is anything that exists in a battle and has any mechanical effect or any changes over time
/// </summary>
public interface IBattleObject
{
    /// <summary>
    /// Updates the object by one game tick (usually one frame, but can also be manually advanced in certain contexts
    /// </summary>
    void Tick();

    /// <summary>
    /// Gets the current BattleContext this object is contained in.
    /// </summary>
    /// <returns>This BattleObject's current Context</returns>
    IBattleContext GetCurrentContext();

    /// <summary>
    /// Sets the current BattleContext this object is contained in.
    /// </summary>
    /// <param name="context">The BattleContext to add this object to</param>
    void SetCurrentContext(IBattleContext context);
}
