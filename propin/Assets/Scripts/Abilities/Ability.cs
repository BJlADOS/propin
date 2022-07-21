using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public AbilityMetaData MetaData;
    public abstract void Use();
}
