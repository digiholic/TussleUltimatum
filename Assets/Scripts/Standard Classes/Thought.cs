using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Thought is essentially an input that a fighter can do, but since they can come from sources other than buttons, so they're called thoughts here.
/// Note that some actions are combinations of thoughts, like directional attacks, spot dodges, smash stick, etc.
/// The Brain object will take care of turning those buttons into combinations of Thoughts
/// </summary>
public enum Thought
{
    LEFT_SLIGHT,
    LEFT_MID,
    LEFT_HARD,
    LEFT_SMASH,

    RIGHT_SLIGHT,
    RIGHT_MID,
    RIGHT_HARD,
    RIGHT_SMASH,

    UP_SLIGHT,
    UP_MID,
    UP_HARD,
    UP_SMASH,

    DOWN_SLIGHT,
    DOWN_MID,
    DOWN_HARD,
    DOWN_SMASH,

    ATTACK,
    SPECIAL,
    SHIELD,
    JUMP,
    GRAB,

    TAUNT
}
