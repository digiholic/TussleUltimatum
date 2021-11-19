using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Subactions;
using UnityEditor.Callbacks;

[CustomEditor(typeof(FighterInfo))]
public class TestFighterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FighterInfo fighter = (FighterInfo)target;
        
        if (GUILayout.Button("Open Fighter Editor"))
        {
            FighterInfoWindow.Open(fighter);
        }
    }
}

public class AssetHandler
{
    [OnOpenAsset()]
    public static bool OpenEditor(int instanceId, int line)
    {
        FighterInfo info = EditorUtility.InstanceIDToObject(instanceId) as FighterInfo;
        if (info != null)
        {
            FighterInfoWindow.Open(info);
            return true;
        }
        return false;
    }
}
/*
[CustomPropertyDrawer(typeof(FighterState))]
public class FighterStateDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        base.OnGUI(position, property, label);
        //FighterState state = (FighterState) property.objectReferenceValue;

    }
}
*/