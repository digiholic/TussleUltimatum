using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Brain class is the method through which a fighter is controlled. All it does is "think" a set of commands every frame.
/// How it comes to those commands is entirely up to the specific implementation. This class is used by PlayerBrains to read input,
/// BotBrains to read game state and decide what to do, and NetworkBrains to get commands from the network connection
/// </summary>
public interface IBrain
{
    void Think(out InputPackage inputs);
}
