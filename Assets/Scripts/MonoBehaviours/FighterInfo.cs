using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="fighterInfo",menuName ="Tussle/Create/Fighter Info")]
public class FighterInfo : ScriptableObject
{
    public string DisplayName = "Test Fighter";
    

    public List<FighterState> states;
}
