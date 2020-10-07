using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A BattleContext is an object that contains many different BattleObjects. It's job is to let them know when a game tick occurs
/// and what objects are in it.
/// </summary>
public interface IBattleContext
{
    /// <summary>
    /// Adds a BattleObject to this Context
    /// </summary>
    /// <param name="bObj">The BattleObject to add</param>
    void RegisterBattleObject(IBattleObject bObj);

    /// <summary>
    /// Removes a BattleObject from this Context if it exists. If it is not in this Context, it will be ignored
    /// </summary>
    /// <param name="bObj">The BattleObject to remove</param>
    void UnregisterBattleObject(IBattleObject bObj);
}
