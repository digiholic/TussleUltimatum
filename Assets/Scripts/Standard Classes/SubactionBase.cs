using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Subaction
{
    public abstract class SubactionBase : ScriptableObject
    {
        public abstract void Execute(FighterCharacterController fighter, AbstractFighterState state);
    }
}
