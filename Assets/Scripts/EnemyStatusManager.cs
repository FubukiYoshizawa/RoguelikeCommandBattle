using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public string eNAME; // G¼
    public int eLv; // Gx
    public int eHP; // GHP
    public int eATK; // GUÍ
    public int eEXP; // Go±l
}

[CreateAssetMenu(menuName = "ScriptableObject/Enemy Status Manager", fileName = "EnemyStatusManager")]
public class EnemyStatusManager : ScriptableObject
{
    public List<EnemyData> DataList;
}