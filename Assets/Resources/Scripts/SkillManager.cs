using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SkillManager : Singleton<SkillManager>
{
    public SkillValueManager skillValueManager; // スキルの各値管理用のスクリプト

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
    public bool skillDescriptionDisplay; // スキル説明を表示するかどうか
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

    private void Start()
    {
        useSkillButton = new GameObject[(int)enumSkillButton.Num];
        useSkillButtonText = new TextMeshProUGUI[(int)enumUseSkillButtontext.Num];
        useSkill = new bool[(int)enumUseSkill.Num];

        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();

        useSkillButton[(int)enumSkillButton.Skill1] = GameObject.Find("SkillButton1");
        useSkillButton[(int)enumSkillButton.Skill2] = GameObject.Find("SkillButton2");
        useSkillButton[(int)enumSkillButton.Skill3] = GameObject.Find("SkillButton3");

        useSkillButtonText[(int)enumUseSkillButtontext.Skill1] = GameObject.Find("SkillButtonText1").GetComponent<TextMeshProUGUI>();
        useSkillButtonText[(int)enumUseSkillButtontext.Skill2] = GameObject.Find("SkillButtonText2").GetComponent<TextMeshProUGUI>();
        useSkillButtonText[(int)enumUseSkillButtontext.Skill3] = GameObject.Find("SkillButtonText3").GetComponent<TextMeshProUGUI>();

        if (DebugScript.Instance.Fighter)
        {
            useSkillButtonText[(int)enumUseSkillButtontext.Skill1].text = skillValueManager.DataList[0].skillName;
            useSkillButtonText[(int)enumUseSkillButtontext.Skill2].text = skillValueManager.DataList[1].skillName;
            useSkillButtonText[(int)enumUseSkillButtontext.Skill3].text = skillValueManager.DataList[2].skillName;
        }
        else if (DebugScript.Instance.Magician)
        {
            useSkillButtonText[(int)enumUseSkillButtontext.Skill1].text = skillValueManager.DataList[3].skillName;
            useSkillButtonText[(int)enumUseSkillButtontext.Skill2].text = skillValueManager.DataList[4].skillName;
            useSkillButtonText[(int)enumUseSkillButtontext.Skill3].text = skillValueManager.DataList[5].skillName;
        }

        useSkillButton[(int)enumSkillButton.Skill1].SetActive(false);
        useSkillButton[(int)enumSkillButton.Skill2].SetActive(false);
        useSkillButton[(int)enumSkillButton.Skill3].SetActive(false);

        BattleManager.Instance.windows[(int)BattleManager.enumWindows.SkillWindow].SetActive(false);

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

        if (skillDescriptionDisplay)
        {
            if (DebugScript.Instance.Fighter)
            {
                GameObject selectedObject = EventSystem.current.currentSelectedGameObject;
                if (selectedObject != null && selectedObject == useSkillButton[(int)enumSkillButton.Skill1].gameObject)
                {
                    mainText.text = "パワーアタック\n強い力を込めて相手に\n攻撃力の1.5倍のダメージ";
                }
                else if (selectedObject != null && selectedObject == useSkillButton[(int)enumSkillButton.Skill2].gameObject)
                {
                    mainText.text = "パワーチャージ\n力をためて次の攻撃が２倍";
                }
                else if (selectedObject != null && selectedObject == useSkillButton[(int)enumSkillButton.Skill3].gameObject)
                {
                    mainText.text = "瞑想\n心を静めて瞑想する\nHPを50回復";
                }
                else if (BattleManager.Instance.defaultButton[(int)BattleManager.enumDefaultButton.SkillBackButton])
                {
                    mainText.text = "";
                }
            }
            else if (DebugScript.Instance.Magician)
            {
                GameObject selectedObject = EventSystem.current.currentSelectedGameObject;
                if (selectedObject != null && selectedObject == useSkillButton[(int)enumSkillButton.Skill1].gameObject)
                {
                    mainText.text = "ファイアボール\n炎の球を相手に放つ\n15の固定ダメージ";
                }
                else if (selectedObject != null && selectedObject == useSkillButton[(int)enumSkillButton.Skill2].gameObject)
                {
                    mainText.text = "アイスランス\n氷の槍を相手に放つ\n30の固定ダメージ";
                }
                else if (selectedObject != null && selectedObject == useSkillButton[(int)enumSkillButton.Skill3].gameObject)
                {
                    mainText.text = "ヒール\n癒しの呪文を唱える\nHPを30回復";
                }
                else if (BattleManager.Instance.defaultButton[(int)BattleManager.enumDefaultButton.SkillBackButton])
                {
                    mainText.text = "";
                }
            }
        }

    }

    public IEnumerator UseSkill()
    {
        if (useSkill[(int)enumUseSkill.PowerAttack])
        {
            if (BattleManager.Instance.playerSP < skillValueManager.DataList[0].needSkillValue)
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
            if (BattleManager.Instance.playerSP < skillValueManager.DataList[1].needSkillValue)
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
            if (BattleManager.Instance.playerSP < skillValueManager.DataList[2].needSkillValue)
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
            if (BattleManager.Instance.playerSP < skillValueManager.DataList[3].needSkillValue)
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
            if (BattleManager.Instance.playerSP < skillValueManager.DataList[4].needSkillValue)
            {
                yield return StartCoroutine(NotEnoughSP());
            }
            else
            {
                useSkill[(int)enumUseSkill.IceLance] = false;
                yield return StartCoroutine(IceLance());
            }
        }
        else if (useSkill[(int)enumUseSkill.HealMagic])
        {
            if (BattleManager.Instance.playerSP < skillValueManager.DataList[5].needSkillValue)
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
        mainText.text = "パワーアアタックを使った！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{BattleManager.Instance.playerATK*skillValueManager.DataList[0].skillValue}のダメージ！";

        BattleManager.Instance.playerSP -= skillValueManager.DataList[0].needSkillValue;
        BattleManager.Instance.enemyHP -= (int)(BattleManager.Instance.playerATK * skillValueManager.DataList[0].skillValue);
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
        mainText.text = "パワーチャージを使った！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "攻撃力が2倍になった！";

        BattleManager.Instance.playerSP -= skillValueManager.DataList[1].needSkillValue;
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
        mainText.text = "瞑想を使った！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"HPを{skillValueManager.DataList[2].skillValue}回復した！";

        BattleManager.Instance.playerSP -= skillValueManager.DataList[2].needSkillValue;
        BattleManager.Instance.playerHP += (int)skillValueManager.DataList[2].skillValue;
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
        mainText.text = "ファイアボールを唱えた！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValueManager.DataList[3].skillValue}のダメージ！";

        BattleManager.Instance.playerSP -= skillValueManager.DataList[3].needSkillValue;
        BattleManager.Instance.enemyHP -= (int)skillValueManager.DataList[3].skillValue;
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

    public IEnumerator IceLance()
    {
        mainText.text = "アイスランスを唱えた！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValueManager.DataList[4].skillValue}のダメージ！";

        BattleManager.Instance.playerSP -= skillValueManager.DataList[4].needSkillValue;
        BattleManager.Instance.enemyHP -= (int)skillValueManager.DataList[4].skillValue;
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
        mainText.text = "ヒールを唱えた！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"HPが{skillValueManager.DataList[5].skillValue}回復した！";

        BattleManager.Instance.playerSP -= skillValueManager.DataList[5].needSkillValue;
        BattleManager.Instance.playerHP += (int)skillValueManager.DataList[5].skillValue;
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
