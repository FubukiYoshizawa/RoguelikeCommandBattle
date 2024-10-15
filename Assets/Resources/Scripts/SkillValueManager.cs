using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillValue
{
    public string skillName; // �X�L����
    public int needSkillValue; // �K�vSP
    public float skillValue; // �X�L����
}

[CreateAssetMenu(menuName = "ScriptableObject/SkillValueManager", fileName = "SkillValueManager")]

public class SkillValueManager : ScriptableObject
{
    public List<SkillValue> DataList;
}
