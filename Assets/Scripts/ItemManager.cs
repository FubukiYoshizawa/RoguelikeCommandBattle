using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public ItemValueManager itemValueManager; // �A�C�e���̊e�l�Ǘ��p�̃X�N���v�g

    public TextMeshProUGUI mainText; // �e�L�X�g�\��
    public bool haveItem; // �A�C�e�����������Ă��邩�ǂ���
    public bool[] getItem; // �ǂ̃A�C�e������ɓ��ꂽ��
    public enum enumGetItem
    {
        HPPotion, // HP�|�[�V����
        SPPotion, // SP�|�[�V����
        ATKPotion, // �U���|�[�V����
        HealHerb, // ��
        DamageBomb, // ���e
        ATKJewel, // �U���̕��
        Num // �ǂ̃A�C�e������ɓ��ꂽ���̗v�f��
    }
    public int[] itemValue; // �A�C�e���g�p���̌��ʗ�
    public TextMeshProUGUI itemText; // �A�C�e�����\���p�e�L�X�g

    private void Start()
    {
        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        itemText = GameObject.Find("ItemText").GetComponent<TextMeshProUGUI>();
        getItem = new bool[(int)enumGetItem.Num];
    }

    private void Update()
    {
        if (getItem[(int)enumGetItem.HPPotion])
        {
            itemText.text = itemValueManager.DataList[0].itemName;
        }
        else if (getItem[(int)enumGetItem.SPPotion])
        {
            itemText.text = itemValueManager.DataList[1].itemName;
        }
        else if (getItem[(int)enumGetItem.ATKPotion])
        {
            itemText.text = itemValueManager.DataList[2].itemName;
        }
        else if (getItem[(int)enumGetItem.HealHerb])
        {
            itemText.text = itemValueManager.DataList[3].itemName;
        }
        else if (getItem[(int)enumGetItem.DamageBomb])
        {
            itemText.text = itemValueManager.DataList[4].itemName;
        }
        else if (getItem[(int)enumGetItem.ATKJewel])
        {
            itemText.text = itemValueManager.DataList[5].itemName;
        }
        else
        {
            itemText.text = itemValueManager.DataList[6].itemName;
        }
    }

    public IEnumerator HaveItem()
    {
        if (getItem[(int)enumGetItem.HPPotion])
        {
            getItem[(int)enumGetItem.HPPotion] = false;
            yield return StartCoroutine(HPPotion());
        }
        else if (getItem[(int)enumGetItem.SPPotion])
        {
            getItem[(int)enumGetItem.SPPotion] = false;
            yield return StartCoroutine(SPPotion());
        }
        else if (getItem[(int)enumGetItem.ATKPotion])
        {
            getItem[(int)enumGetItem.ATKPotion] = false;
            yield return StartCoroutine(ATKPotion());
        }
        else if (getItem[(int)enumGetItem.HealHerb])
        {
            getItem[(int)enumGetItem.HealHerb] = false;
            yield return StartCoroutine(HealHerb());
        }
        else if (getItem[(int)enumGetItem.DamageBomb])
        {
            getItem[(int)enumGetItem.DamageBomb] = false;
            yield return StartCoroutine(DamageBomb());
        }
        else if (getItem[(int)enumGetItem.ATKJewel])
        {
            getItem[(int)enumGetItem.ATKJewel] = false;
            yield return StartCoroutine(ATKJewel());
        }

    }

    public IEnumerator HPPotion()
    {
        mainText.text = "HP�|�[�V�������g�����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"HP��{itemValueManager.DataList[0].itemValue}�񕜂����I";

        BattleManager.Instance.playerHP += itemValueManager.DataList[0].itemValue;
        if (BattleManager.Instance.playerHP > BattleManager.Instance.playerMaxHP)
        {
            BattleManager.Instance.playerHP = BattleManager.Instance.playerMaxHP;
        }
        haveItem = false;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator SPPotion()
    {
        mainText.text = "SP�|�[�V�������g�����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"SP��{itemValueManager.DataList[1].itemValue}�񕜂����I";

        BattleManager.Instance.playerSP += itemValueManager.DataList[1].itemValue;
        if (BattleManager.Instance.playerSP > BattleManager.Instance.playerMaxSP)
        {
            BattleManager.Instance.playerSP = BattleManager.Instance.playerMaxSP;
        }
        haveItem = false;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator ATKPotion()
    {
        mainText.text = "�U���|�[�V�������g�����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "�U���͂��Q�{�ɂȂ����I";
        BattleManager.Instance.powerUp2 = true;
        BattleManager.Instance.playerATK *= itemValueManager.DataList[2].itemValue;
        haveItem = false;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator HealHerb()
    {
        mainText.text = "�򑐂��g�����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"HP��{itemValueManager.DataList[3].itemValue}�񕜂����I";

        BattleManager.Instance.playerHP += itemValueManager.DataList[3].itemValue;
        if (BattleManager.Instance.playerHP > BattleManager.Instance.playerMaxHP)
        {
            BattleManager.Instance.playerHP = BattleManager.Instance.playerMaxHP;
        }
        haveItem = false;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

    public IEnumerator DamageBomb()
    {
        mainText.text = "���e���g�����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{itemValueManager.DataList[4].itemValue}�̃_���[�W�I";

        BattleManager.Instance.enemyHP -= itemValueManager.DataList[4].itemValue;
        if (BattleManager.Instance.enemyHP < 0)
        {
            BattleManager.Instance.enemyHP = 0;
        }
        haveItem = false;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

    public IEnumerator ATKJewel()
    {
        mainText.text = "�U���W���G�����g�����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "�U���͂�3�{�ɂȂ����I";
        BattleManager.Instance.powerUp3 = true;
        BattleManager.Instance.playerATK *= itemValueManager.DataList[5].itemValue;
        haveItem = false;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

}
