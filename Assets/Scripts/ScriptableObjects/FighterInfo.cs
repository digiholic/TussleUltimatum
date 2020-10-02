using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TUSSLE Fighter", menuName = "Modules/Fighter", order = 1)]
public class FighterInfo : ScriptableObject
{
    /// <summary>
    /// The Fighter's display name, which will be shown in the UI and otherwise used to identify the character
    /// </summary>
    public string DisplayName;



    public string toJson()
    {
        return JsonUtility.ToJson(this);
    }

    public static FighterInfo fromJson(string jsonString)
    {
        FighterInfo info = ScriptableObject.CreateInstance<FighterInfo>();
        JsonUtility.FromJsonOverwrite(jsonString, info);
        return info;
    }
}
