using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new equipment")]
public class EquipmentStats : ScriptableObject
{
    public int rarityIndex;
    public float attackStatsInc;
    public float defenseStatsInc;
    public float magicStatsInc;
    public float luckStatsInc;
}
