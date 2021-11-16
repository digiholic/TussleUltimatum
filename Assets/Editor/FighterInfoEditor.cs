using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Subactions;

[CustomEditor(typeof(FighterInfo))]
public class TestFighterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FighterInfo fighter = (FighterInfo)target;

        if (GUILayout.Button("Add ChangeX"))
        {
            fighter.states[0].OnStateEnterSubactions.Add(new ChangeXSpeed());
        }
        if (GUILayout.Button("Add ChangeY"))
        {
            fighter.states[0].OnStateEnterSubactions.Add(new ChangeYSpeed());
        }
    }
}