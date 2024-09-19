using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillManager : Singleton<SkillManager>
{
    public TextMeshProUGUI mainText; // テキスト表示
    public GameObject[] useSkillButton; // スキル使用時のボタン
    public enum enumSkillButton
    {
        Skill1, // スキル１のボタン
        Skill2, // スキル２のボタン
        Skill3, // スキル３のボタン
        Num // スキルボタンの数
    }
    public TextMeshProUGUI[] useSkillButtonText; // 表示するスキル名
    public enum enumUseSkillButtontext
    {
        Skill1, // スキル１の名前
        Skill2, // スキル２の名前
        Skill3, // スキル３の名前
        Num // スキル名表示数
    }
    public bool[] useSkill; // どのスキルを使用するか
    public enum enumUseSkill
    {
        PowerAttack, // パワーアタック
        PowerUp, // パワーアップ
        Meditation, // 瞑想
        FireBall, // ファイアボール
        IceLance, // アイスランス
        HealMagic, // ヒール
        Num // どのスキルを使うかの数
    }
    public int[] needSkillPoint; // スキル使用に必要なSP量
    public int[] skillValue; // スキルの効果量

    private void Start()
    {
        useSkillButton = new GameObject[(int)enumSkillButton.Num];
        useSkillButtonText = new TextMeshProUGUI[(int)enumUseSkillButtontext.Num];
        useSkill = new bool[(int)enumUseSkill.Num];

        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        useSkillButton[(int)enumSkillButton.Skill1] = GameObject.Find("Skill1");
        useSkillButton[(int)enumSkillButton.Skill2] = GameObject.Find("Skill2");
        useSkillButton[(int)enumSkillButton.Skill3] = GameObject.Find("Skill3");

        if (DebugScript.Instance.Fighter)
        {
            useSkillButtonText[(int)enumUseSkillButtontext.Skill1].text = "パワーアタック";
            useSkillButtonText[(int)enumUseSkillButtontext.Skill2].text = "パワーチャージ";
            useSkillButtonText[(int)enumUseSkillButtontext.Skill3].text = "瞑想";
        }
        else if (DebugScript.Instance.Magician)
        {
            useSkillButtonText[(int)enumUseSkillButtontext.Skill1].text = "ファイアボール";
            useSkillButtonText[(int)enumUseSkillButtontext.Skill2].text = "アイスランス";
            useSkillButtonText[(int)enumUseSkillButtontext.Skill3].text = "ヒール";
        }

        useSkillButton[(int)enumSkillButton.Skill1].SetActive(false);
        useSkillButton[(int)enumSkillButton.Skill2].SetActive(false);
        useSkillButton[(int)enumSkillButton.Skill3].SetActive(false);

    }

    private void Update()
    {
        if (BattleManager.Instance.playerLv >= 2)
        {
            useSkillButton[(int)enumSkillButton.Skill1].SetActive(true);
        }
        
        if (BattleManager.Instance.playerLv >= 5)
        {
            useSkillButton[(int)enumSkillButton.Skill2].SetActive(true);
        }

        if (BattleManager.Instance.playerLv >= 7)
        {
            useSkillButton[(int)enumSkillButton.Skill3].SetActive(true);
        }

    }

    public IEnumerator UseSkill()
    {
        if (useSkill[(int)enumUseSkill.PowerAttack])
        {
            if (BattleManager.Instance.playerSP < needSkillPoint[0])
            {
                yield return StartCoroutine(NotEnoughSP());
            }
            else
            {
                useSkill[(int)enumUseSkill.PowerAttack] = false;
                yield return StartCoroutine(PowerAttack());
            }
        }
        else if (useSkill[(int)enumUseSkill.PowerUp])
        {
            if (BattleManager.Instance.playerSP < needSkillPoint[1])
            {
                yield return StartCoroutine(NotEnoughSP());
            }
            else
            {
                useSkill[(int)enumUseSkill.PowerUp] = false;
                yield return StartCoroutine(PowerUp());
            }
        }
        else if (useSkill[(int)enumUseSkill.Meditation])
        {
            if (BattleManager.Instance.playerSP < needSkillPoint[2])
            {
                yield return StartCoroutine(NotEnoughSP());
            }
            else
            {
                useSkill[(int)enumUseSkill.Meditation] = false;
                yield return StartCoroutine(Meditation());
            }
        }
        else if (useSkill[(int)enumUseSkill.FireBall])
        {
            if (BattleManager.Instance.playerSP < needSkillPoint[3])
            {
                yield return StartCoroutine(NotEnoughSP());
            }
            else
            {
                useSkill[(int)enumUseSkill.FireBall] = false;
                yield return StartCoroutine(FireBall());
            }
        }
        else if (useSkill[(int)enumUseSkill.IceLance])
        {
            if (BattleManager.Instance.playerSP < needSkillPoint[4])
            {
                yield return StartCoroutine(NotEnoughSP());
            }
            else
            {
                useSkill[(int)enumUseSkill.IceLance] = false;
                yield return StartCoroutine(IiceLance());
            }
        }
        else if (useSkill[(int)enumUseSkill.HealMagic])
        {
            if (BattleManager.Instance.playerSP < needSkillPoint[5])
            {
                yield return StartCoroutine(NotEnoughSP());
            }
            else
            {
                useSkill[(int)enumUseSkill.HealMagic] = false;
                yield return StartCoroutine(HealMagic());
            }
        }

    }

    public IEnumerator NotEnoughSP()
    {
        mainText.text = "SPが足りない！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(BattleManager.Instance.Battle());
    }

    public IEnumerator PowerAttack()
    {
        mainText.text = "Using PowerAttack";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValue[0]} damage to the enemy.";

        BattleManager.Instance.playerSP -= needSkillPoint[0];
        BattleManager.Instance.enemyHP -= skillValue[0];
        if (BattleManager.Instance.enemyHP < 0)
        {
            BattleManager.Instance.enemyHP = 0;
        }

        if (BattleManager.Instance.powerUp2)
        {
            BattleManager.Instance.powerUp2 = false;
            BattleManager.Instance.playerATK /= 2;
        }
        else if (BattleManager.Instance.powerUp3)
        {
            BattleManager.Instance.powerUp3 = false;
            BattleManager.Instance.playerATK /= 3;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.enemyHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerWin());
        }

    }

    public IEnumerator PowerUp()
    {
        mainText.text = "Using PowerUp";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "Double the power of the next attack";

        BattleManager.Instance.playerSP -= needSkillPoint[1];
        BattleManager.Instance.powerUp2 = true;
        BattleManager.Instance.playerATK *= 2;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator Meditation()
    {
        mainText.text = "Using Meditation";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValue[1]} HP recovered";

        BattleManager.Instance.playerSP -= needSkillPoint[2];
        BattleManager.Instance.playerHP += skillValue[1];
        if (BattleManager.Instance.playerHP > BattleManager.Instance.playerMaxHP)
        {
            BattleManager.Instance.playerHP = BattleManager.Instance.playerMaxHP;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

    public IEnumerator FireBall()
    {
        mainText.text = "Chanted FireBall";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValue[2]} damage to the enemy.";

        BattleManager.Instance.playerSP -= needSkillPoint[3];
        BattleManager.Instance.enemyHP -= skillValue[2];
        if (BattleManager.Instance.enemyHP < 0)
        {
            BattleManager.Instance.enemyHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.enemyHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerWin());
        }
    }

    public IEnumerator IiceLance()
    {
        mainText.text = "Chanted IiceLance";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValue[3]} damage to the enemy.";

        BattleManager.Instance.playerSP -= needSkillPoint[4];
        BattleManager.Instance.enemyHP -= skillValue[3];
        if (BattleManager.Instance.enemyHP < 0)
        {
            BattleManager.Instance.enemyHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.enemyHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerWin());
        }
    }

    public IEnumerator HealMagic()
    {
        mainText.text = "Chanted HealMagic";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValue[1]} HP recovered";

        BattleManager.Instance.playerSP -= needSkillPoint[5];
        BattleManager.Instance.playerHP += skillValue[1];
        if (BattleManager.Instance.playerHP > BattleManager.Instance.playerMaxHP)
        {
            BattleManager.Instance.playerHP = BattleManager.Instance.playerMaxHP;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }
}
