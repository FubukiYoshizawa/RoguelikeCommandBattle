using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public string eNAME; // �G��
    public int eLv; // �G���x��
    public int eHP; // �GHP
    public int eATK; // �G�U����
    public int eEXP; // �G�o���l
    public int skillValue1; // �e�G�X�L���̌��ʗ�
    public int skillValue2;
    public int skillValue3; 
}

[CreateAssetMenu(menuName = "ScriptableObject/Enemy Status Manager", fileName = "EnemyStatusManager")]
public class EnemyStatusManager : ScriptableObject
{
    public List<EnemyData> DataList;
}