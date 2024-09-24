using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public ItemValueManager itemValueManager; // アイテムの各値管理用のスクリプト

    public TextMeshProUGUI mainText; // テキスト表示
    public bool haveItem; // アイテムを所持しているかどうか
    public bool[] getItem; // どのアイテムを手に入れたか
    public enum enumGetItem
    {
        HPPotion, // HPポーション
        SPPotion, // SPポーション
        ATKPotion, // 攻撃ポーション
        HealHerb, // 薬草
        DamageBomb, // 爆弾
        ATKJewel, // 攻撃の宝石
        Num // どのアイテムを手に入れたかの要素数
    }
    public int[] itemValue; // アイテム使用時の効果量
    public TextMeshProUGUI itemText; // アイテム名表示用テキスト

    private void Start()
    {
        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        itemText = GameObject.Find("ItemText").GetComponent<TextMeshProUGUI>();
        getItem = new bool[(int)enumGetItem.Num];
        itemText.text = itemValueManager.DataList[(int)enumGetItem.Num].itemName;
    }

    private void Update()
    {
        
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
        mainText.text = $"{itemValueManager.DataList[0].itemName}を使った！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"HPが{itemValueManager.DataList[0].itemValue}回復した！";

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
        mainText.text = $"{itemValueManager.DataList[1].itemName}を使った！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"SPが{itemValueManager.DataList[1].itemValue}回復した！";

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
        mainText.text = $"{itemValueManager.DataList[2].itemName}を使った！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "攻撃力が２倍になった！";
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
        mainText.text = $"{itemValueManager.DataList[3].itemName}を使った！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"HPが{itemValueManager.DataList[3].itemValue}回復した！";

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
        mainText.text = $"{itemValueManager.DataList[4].itemName}を使った！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{itemValueManager.DataList[4].itemValue}のダメージ！";

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
        mainText.text = $"{itemValueManager.DataList[5].itemName}を使った！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "攻撃力が3倍になった！";
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
