using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
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

    private void Start()
    {
        getItem = new bool[(int)enumGetItem.Num];

        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
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

        mainText.text = $"HP��{itemValue[0]}�񕜂����I";

        BattleManager.Instance.playerHP += itemValue[0];
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

        mainText.text = $"SP��{itemValue[1]}�񕜂����I";

        BattleManager.Instance.playerSP += itemValue[1];
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
        BattleManager.Instance.playerATK *= 2;
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

        mainText.text = $"HP��{itemValue[2]}�񕜂����I";

        BattleManager.Instance.playerHP += itemValue[2];
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

        mainText.text = $"{itemValue[3]}�̃_���[�W�I";

        BattleManager.Instance.enemyHP -= itemValue[3];
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
        BattleManager.Instance.playerATK *= 3;
        haveItem = false;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

}
