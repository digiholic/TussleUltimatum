using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Subactions
{
    public class DebugSubaction : SubactionBase
    {
        public string message;

        public override void Execute(FighterCharacterController fighter, AbstractFighterState state)
        {
            Debug.Log(message);
        }
    }
}