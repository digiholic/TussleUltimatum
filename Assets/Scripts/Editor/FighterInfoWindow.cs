using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FighterInfoWindow : ExtendedEditorWindow
{
    public static void Open(FighterInfo info)
    {
        FighterInfoWindow window = GetWindow<FighterInfoWindow>($"Fighter Editor - {info.DisplayName}");
        window.serializedObject = new SerializedObject(info);
    }

    private void OnGUI()
    {
        //EditorGUILayout.PropertyField(serializedObject.FindProperty("DisplayName"));
        currentProperty = serializedObject.FindProperty("states");

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical("box",GUILayout.MaxWidth(150),GUILayout.ExpandHeight(true));
        DrawSidebar(currentProperty);
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
        if (selectedProperty != null)
        {
            DrawProperties(selectedProperty, true);
        } else
        {
            if (GUILayout.Button("Add New State"))
            {
                currentProperty.arraySize++;
            }
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        Event e;

        serializedObject.ApplyModifiedProperties();
    }
}
