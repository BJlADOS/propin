using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "ScriptableObjects/Ability", order = 3)]
public class AbilityMetaData : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public float Cost;
}
