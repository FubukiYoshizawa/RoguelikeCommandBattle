using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BGMData
{
    public string BGMName; // BGM�̖��O
    public AudioClip AudioClip; // BGM��AudioClip
}

[CreateAssetMenu(menuName = "ScriptableObject/BGMManager", fileName = "BGMManager")]
public class BGMManager : ScriptableObject
{
    public List<BGMData> DataList;
}