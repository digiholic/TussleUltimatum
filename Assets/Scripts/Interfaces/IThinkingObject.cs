using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An Interface for any object capable of generating Thoughts
/// </summary>
public interface IThinkingObject
{
    /// <summary>
    /// Gets the current Brain of the object
    /// </summary>
    /// <returns>This object's Brain</returns>
    IBrain GetBrain();

    /// <summary>
    /// Gets all of the thoughts that were generated since the last tick
    /// </summary>
    /// <returns>A Set of all Thoughts this Tick</returns>
    HashSet<Thought> GetThoughts();
}
