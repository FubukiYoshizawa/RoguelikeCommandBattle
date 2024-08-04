using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public string eNAME;
    public int eLv;
    public int eHP;
    public int eATK;
    public int eEXP;
}

[CreateAssetMenu(menuName = "ScriptableObject/Enemy Status Manager", fileName = "EnemyStatusManager")]
public class EnemyStatusManager : ScriptableObject
{
    public List<EnemyData> DataList;
}
