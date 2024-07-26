using UnityEngine;

public class DebugScript : MonoBehaviour
{
    // EnemyStatusManager��ScriptableObject���A�T�C�����邽�߂̃t�B�[���h
    public EnemyStatusManager enemyStatusManager;

    void Start()
    {
        string EnemyName = enemyStatusManager.DataList[0].eNAME;
        int EnemyHP = enemyStatusManager.DataList[0].eHP;
        int EnemyATK = enemyStatusManager.DataList[0].eATK;
        int EnemyLv = enemyStatusManager.DataList[0].eLv;
        int EnemyEXP = enemyStatusManager.DataList[0].eEXP;

        Debug.Log($"Enemy Name: {EnemyName} \n FEnemy HP: {EnemyHP} \n Enemy ATK: {EnemyATK} \n Enemy Lv: {EnemyLv} \n Enemy EXP: {EnemyEXP}");
    }
}
