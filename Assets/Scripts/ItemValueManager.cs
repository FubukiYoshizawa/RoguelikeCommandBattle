using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemValue
{
    public string itemName; // �A�C�e����
    public int itemID; // �A�C�e����ID
    public int itemValue; // �A�C�e���̌��ʗ�
}

[CreateAssetMenu(menuName = "ScriptableObject/ItemValueManager", fileName = "ItemValueManager")]

public class ItemValueManager : ScriptableObject
{
    public List<ItemValue> DataList;
}