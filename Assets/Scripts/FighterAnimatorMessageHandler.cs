using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAnimatorMessageHandler : MonoBehaviour
{
    public FighterCharacterController fighter;

    private void Start()
    {
        if (fighter == null) fighter = GetComponentInParent<FighterCharacterController>();
    }

    public void ReceiveAnimatorMessage(string message)
    {
        fighter.ReceiveAnimatorMessage(message);
    }
}
