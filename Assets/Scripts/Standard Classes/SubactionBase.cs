using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Subactions
{
    [System.Serializable]
    public abstract class SubactionBase
    {
        public abstract void Execute(FighterCharacterController fighter, AbstractFighterState state);
    }
}
