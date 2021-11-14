using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Subactions;


public class TestFighterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TestFighter fighter = (TestFighter)target;

        /*
        foreach(SubactionBase sub in fighter.states[0].OnStateEnterSubactions)
        {
            if (sub is ChangeXSpeed xSub)
            {
                Editor.CreateEditor(xSub);
                Editor.Create
            }
        }
        */

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
