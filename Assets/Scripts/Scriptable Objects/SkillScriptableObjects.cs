using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new skill")]
public class SkillsScriptable : ScriptableObject
{
    public string skillName;
    public int cost;
    public int damage;
    public float statsUp;
}
