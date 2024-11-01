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
        // ScriptableObject�̓ǂݍ���
        itemValueManager = Resources.Load<ItemValueManager>("ScriptableObject/ItemValueManager");

        // ���C���e�L�X�g�ƃA�C�e������\������e�L�X�g��UI�I�u�W�F�N�g�̓ǂݍ���
        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        itemText = GameObject.Find("ItemText").GetComponent<TextMeshProUGUI>();

        // �e�z��̏�����
        getItem = new bool[(int)enumGetItem.Num];
        itemText.text = itemValueManager.DataList[(int)enumGetItem.Num].itemName;
    }

    // �ǂ̃A�C�e�����������Ă��邩�̏���
    public IEnumerator HaveItem()
    {
        if (getItem[(int)enumGetItem.HPPotion])
        {
            if (BattleManager.Instance.playerHP == BattleManager.Instance.playerMaxHP)
            {
                mainText.text = "HP�񕜂͕K�v�Ȃ��I";

                yield return StartCoroutine(NextProcess(1.0f));
                yield return StartCoroutine(BattleManager.Instance.Battle());

            }

            getItem[(int)enumGetItem.HPPotion] = false;
            yield return StartCoroutine(HPPotion());
        }
        else if (getItem[(int)enumGetItem.SPPotion])
        {
            if (BattleManager.Instance.playerSP == BattleManager.Instance.playerMaxSP)
            {
                mainText.text = "SP�񕜂͕K�v�Ȃ��I";

                yield return StartCoroutine(NextProcess(1.0f));
                yield return StartCoroutine(BattleManager.Instance.Battle());

            }

            getItem[(int)enumGetItem.SPPotion] = false;
            yield return StartCoroutine(SPPotion());
        }
        else if (getItem[(int)enumGetItem.ATKPotion])
        {
            if (BattleManager.Instance.powerUp)
            {
                mainText.text = "���łɍU���͂��オ���Ă���I";

                yield return StartCoroutine(NextProcess(1.0f));
                yield return StartCoroutine(BattleManager.Instance.Battle());

            }

            getItem[(int)enumGetItem.ATKPotion] = false;
            yield return StartCoroutine(ATKPotion());
        }
        else if (getItem[(int)enumGetItem.HealHerb])
        {
            if (BattleManager.Instance.playerHP == BattleManager.Instance.playerMaxHP)
            {
                mainText.text = "HP�񕜂͕K�v�Ȃ��I";

                yield return StartCoroutine(NextProcess(1.0f));
                yield return StartCoroutine(BattleManager.Instance.Battle());

            }

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
            if (BattleManager.Instance.powerUp)
            {
                mainText.text = "���łɍU���͂��オ���Ă���I";

                yield return StartCoroutine(NextProcess(1.0f));
                yield return StartCoroutine(BattleManager.Instance.Battle());

            }

            getItem[(int)enumGetItem.ATKJewel] = false;
            yield return StartCoroutine(ATKJewel());
        }

    }

    // HP�|�[�V����
    public IEnumerator HPPotion()
    {
        mainText.text = $"{itemValueManager.DataList[0].itemName}���g�����I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Healing);
        FlashManager.Instance.FlashScreen(new Color(0.5f, 1f, 0f), 0.3f);
        mainText.text = $"HP��{itemValueManager.DataList[0].itemValue}�񕜂����I";

        BattleManager.Instance.playerHP += itemValueManager.DataList[0].itemValue;
        if (BattleManager.Instance.playerHP > BattleManager.Instance.playerMaxHP)
        {
            BattleManager.Instance.playerHP = BattleManager.Instance.playerMaxHP;
        }
        haveItem = false;

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
    }

    // SP�|�[�V����
    public IEnumerator SPPotion()
    {
        mainText.text = $"{itemValueManager.DataList[1].itemName}���g�����I";

        yield return StartCoroutine(NextProcess(1.0f));

        FlashManager.Instance.FlashScreen(Color.cyan, 0.3f);
        mainText.text = $"SP��{itemValueManager.DataList[1].itemValue}�񕜂����I";

        BattleManager.Instance.playerSP += itemValueManager.DataList[1].itemValue;
        if (BattleManager.Instance.playerSP > BattleManager.Instance.playerMaxSP)
        {
            BattleManager.Instance.playerSP = BattleManager.Instance.playerMaxSP;
        }
        haveItem = false;

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
    }

    // �U���|�[�V����
    public IEnumerator ATKPotion()
    {
        mainText.text = $"{itemValueManager.DataList[2].itemName}���g�����I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.PowerCharge);
        FlashManager.Instance.FlashScreen(Color.yellow, 0.3f);
        mainText.text = "�U���͂��Q�{�ɂȂ����I";
        BattleManager.Instance.powerUp = true;
        BattleManager.Instance.baseAttack = BattleManager.Instance.playerATK;
        BattleManager.Instance.playerATK *= itemValueManager.DataList[2].itemValue;
        haveItem = false;

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
    }

    // ������
    public IEnumerator HealHerb()
    {
        mainText.text = $"{itemValueManager.DataList[3].itemName}���g�����I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Healing);
        FlashManager.Instance.FlashScreen(new Color(0.5f, 1f, 0f), 0.3f);
        mainText.text = $"HP��{itemValueManager.DataList[3].itemValue}�񕜂����I";

        BattleManager.Instance.playerHP += itemValueManager.DataList[3].itemValue;
        if (BattleManager.Instance.playerHP > BattleManager.Instance.playerMaxHP)
        {
            BattleManager.Instance.playerHP = BattleManager.Instance.playerMaxHP;
        }
        haveItem = false;

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
    }

    // ���e
    public IEnumerator DamageBomb()
    {
        mainText.text = $"{itemValueManager.DataList[4].itemName}���g�����I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Bomb);
        FlashManager.Instance.EnemyFlash(Color.red, 0.3f);
        mainText.text = $"{itemValueManager.DataList[4].itemValue}�̃_���[�W�I";

        BattleManager.Instance.enemyHP -= itemValueManager.DataList[4].itemValue;
        if (BattleManager.Instance.enemyHP <= 0)
        {
            BattleManager.Instance.enemyHP = 0;
        }
        haveItem = false;

        yield return StartCoroutine(NextProcess(1.0f));

        if (BattleManager.Instance.enemyHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerWin());
        }
        else
        {
            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        }

    }

    // �U���W���G��
    public IEnumerator ATKJewel()
    {
        mainText.text = $"{itemValueManager.DataList[5].itemName}���g�����I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.PowerCharge);
        FlashManager.Instance.FlashScreen(Color.yellow, 0.3f);
        mainText.text = "�U���͂�3�{�ɂȂ����I";
        BattleManager.Instance.powerUp = true;
        BattleManager.Instance.baseAttack = BattleManager.Instance.playerATK;
        BattleManager.Instance.playerATK *= itemValueManager.DataList[2].itemValue;
        haveItem = false;

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
    }

    // �R���[�`�����Ŏ��̏����Ɉړ�����ۂ̃f�B���C�̐ݒ�
    public IEnumerator NextProcess(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

}
