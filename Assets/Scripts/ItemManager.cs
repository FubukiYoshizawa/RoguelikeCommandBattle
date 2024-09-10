using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public TextMeshProUGUI mainText; // テキスト表示
    public bool haveItem; // アイテムを所持しているかどうか
    public bool[] getItem; // どのアイテムを手に入れたか
    /*
    0:HPポーション
    1:SPポーション
    2:攻撃ポーション
    3:薬草
    4:爆弾
    5:攻撃の宝石
    */
    public int[] itemValue; // アイテム使用時の効果量

    private void Start()
    {
        getItem[0] = true;
    }

    public IEnumerator HaveItem()
    {
        if (getItem[0])
        {
            getItem[0] = false;
            yield return StartCoroutine(HPPotion());
        }
        else if (getItem[1])
        {
            getItem[1] = false;
            yield return StartCoroutine(SPPotion());
        }
        else if (getItem[2])
        {
            getItem[2] = false;
            yield return StartCoroutine(ATKPotion());
        }
        else if (getItem[3])
        {
            getItem[3] = false;
            yield return StartCoroutine(HealHerb());
        }
        else if (getItem[4])
        {
            getItem[4] = false;
            yield return StartCoroutine(DamageBomb());
        }
        else if (getItem[5])
        {
            getItem[5] = false;
            yield return StartCoroutine(ATKJewel());
        }

    }

    public IEnumerator HPPotion()
    {
        mainText.text = "Using HP potion";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{itemValue[0]} recovered";

        BattleManager.Instance.pHP += itemValue[0];
        if (BattleManager.Instance.pHP > BattleManager.Instance.pMaxHP)
        {
            BattleManager.Instance.pHP = BattleManager.Instance.pMaxHP;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator SPPotion()
    {
        mainText.text = "Using SP potion";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{itemValue[1]} SP recovered";

        BattleManager.Instance.pSP += itemValue[1];
        if (BattleManager.Instance.pSP > BattleManager.Instance.pMaxSP)
        {
            BattleManager.Instance.pSP = BattleManager.Instance.pMaxSP;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator ATKPotion()
    {
        mainText.text = "Using ATK potion";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "Double the power of the next attack";
        BattleManager.Instance.powerUp2 = true;
        BattleManager.Instance.pATK *= 2;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator HealHerb()
    {
        mainText.text = "Using medicinal herbs.";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{itemValue[2]} recovered";

        BattleManager.Instance.pHP += itemValue[2];
        if (BattleManager.Instance.pHP > BattleManager.Instance.pMaxHP)
        {
            BattleManager.Instance.pHP = BattleManager.Instance.pMaxHP;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

    public IEnumerator DamageBomb()
    {
        mainText.text = "Using a bomb.";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{itemValue[3]} damage to the enemy.";

        BattleManager.Instance.eHP -= itemValue[3];
        if (BattleManager.Instance.eHP < 0)
        {
            BattleManager.Instance.eHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

    public IEnumerator ATKJewel()
    {
        mainText.text = "Using ATK Jewel";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "Double the power of the next attack";
        BattleManager.Instance.powerUp3 = true;
        BattleManager.Instance.pATK *= 3;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

}
