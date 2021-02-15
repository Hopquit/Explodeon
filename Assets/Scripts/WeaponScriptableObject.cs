using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/WeaponScriptableObject", order =1)]
public class WeaponScriptableObject : ScriptableObject
{
    public string name;
    public float cooldownTime;
    public Transform prefab;
}
