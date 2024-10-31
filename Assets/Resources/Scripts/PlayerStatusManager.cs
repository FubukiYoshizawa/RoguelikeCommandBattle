using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string pNAME; // �v���C���[��
    public int pLv; // �v���C���[���x��
    public int pHP; // �v���C���[HP
    public int pSP; // �v���C���[SP
    public int pATK; // �v���C���[�U����
    public int[] skillSlot; // �g�p�\�X�L��
}

[CreateAssetMenu(menuName = "ScriptableObject/Player Status Manager", fileName = "PlayerStatusManager")]

public class PlayerStatusManager : ScriptableObject
{
    public List<PlayerData> DataList;
}
