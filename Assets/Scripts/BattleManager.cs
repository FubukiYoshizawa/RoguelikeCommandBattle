using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleManager: Singleton<BattleManager>
{
    public EnemyStatusManager esm; // 敵ステータス用スクリプト

    public string pName;  // プレイヤー名
    public int pLv; // プレイヤーレベル
    public int pHP; // プレイヤーHP
    public int pMaxHP; // プレイヤー最大HP
    public int pSP; // プレイヤーSP
    public int pMaxSP; // プレイヤー最大SP
    public int pATK; // プレイヤー攻撃力
    public int pEXP; // プレイヤー経験値
    public int nEXP; // レベルアップまでの経験値

    public string eNAME; // 敵名
    public int eLv; // 敵レベル
    public int eHP; // 敵HP
    public int eATK; // 敵攻撃力
    public int eEXP; // 敵経験値

    public bool powerUp2 = false; // 攻撃力2倍状態を表す
    public bool powerUp3 = false; // 攻撃力3倍状態を表す

    public Image floorBack; // フロアの背景を当てはめるImageオブジェクト
    public Sprite fBack; // フロア画像
    public Image displayEnemy; // 敵を当てはめるImageオブジェクト
    public Sprite[] Enemy; // 敵の画像
    private Sprite[] sprites; // 現在戦っている敵の画像
    public Sprite none; // 敵がいないときの画像
    public TextMeshProUGUI[] pStatus; // 画面に表示するプレイヤーのステータス
    /*
    0:プレイヤー名
    1:プレイヤーレベル
    2:プレイヤーHP
    3:プレイヤーSP
    4:プレイヤー攻撃力
    */
    public TextMeshProUGUI[] eStatus; // 画面に表示する敵のステータス
    /*
    0:敵名
    1:敵レベル
    2:敵HP
    3:敵攻撃力
    */
    public TextMeshProUGUI battleText; // バトル時のテキスト

    public GameObject[] windows; // 各ウィンドウ
    /*
    0:敵ステータスウィンドウ
    1:アイテムウィンドウ
    2:コマンドウィンドウ
    3:スキルウィンドウ
    4:バトル時の選択ウィンドウ
    */

    public bool[] buttonOn; // バトル時に使用するボタンを押しているかどうか
    /*
    0:攻撃
    1:スキル
    2:アイテム
    3:スキル１
    4:スキル２
    5:スキル３
    6:アイテム使用
    7:戻る
    */
    public bool skillUse; // スキルコマンドを表示
    public bool itemUse; // アイテムコマンドを表示
    public bool back; // 各表示から戻る

    void Start()
    {
        pStatus[0].text = pName;
    }

    void Update()
    {
        pStatus[1].text = pLv.ToString();
        pStatus[2].text = pHP.ToString();
        pStatus[3].text = pSP.ToString();
        pStatus[4].text = pATK.ToString();

        eStatus[1].text = eLv.ToString();
        eStatus[2].text = eHP.ToString();
        eStatus[3].text = eATK.ToString();

    }

    public IEnumerator BattleStart()
    {
        battleText.text = "Battle Floor!";
        floorBack.sprite = fBack;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        sprites = new Sprite[] { Enemy[0], Enemy[1], Enemy[2] };
        int randomNumber = Random.Range(0, sprites.Length);
        Sprite selectedSprite = sprites[randomNumber];
        displayEnemy.sprite = selectedSprite;

        eNAME = esm.DataList[randomNumber].eNAME;
        eLv = esm.DataList[randomNumber].eLv;
        eHP = esm.DataList[randomNumber].eHP;
        eATK = esm.DataList[randomNumber].eATK;
        eStatus[0].text = eNAME;

        battleText.text = $"{eNAME} Appeared!";

        windows[0].SetActive(true);
        windows[1].SetActive(false);

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(Battle());

    }

    public IEnumerator StrongStart()
    {
        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator BossStart()
    {
        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator Battle()
    {
        battleText.text = "Command?";
        windows[2].SetActive(true);

        yield return new WaitForSeconds(1.0f);

        while (!buttonOn[0] && !buttonOn[1] && !buttonOn[2])
        {
            yield return null;
        }
        windows[2].SetActive(false);

        if (buttonOn[0])
        {
            windows[2].SetActive(false);
            buttonOn[0] = false;
            yield return StartCoroutine(Attack());
        }
        else if (buttonOn[1])
        {
            windows[2].SetActive(false);
            buttonOn[1] = false;
            windows[3].SetActive(true);

            while (!skillUse && !back)
            {
                yield return null;
            }

            if(skillUse)
            {
                windows[3].SetActive(false);
                skillUse = false;
                yield return StartCoroutine(Skill());
            }
            else
            {
                windows[3].SetActive(false);
                back = false;
                yield return StartCoroutine(Battle());

            }

        }
        else if (buttonOn[2])
        {
            windows[2].SetActive(false);
            buttonOn[2] = false;
            windows[4].SetActive(true);

            yield return StartCoroutine(Item());

        }

    }

    public IEnumerator Attack()
    {
        yield return StartCoroutine(PlayerAttack());

        yield return StartCoroutine(EnemyAttack());


        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(Battle());
    }

    public IEnumerator PlayerAttack()
    {
        battleText.text = $"{pName} Attack";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{pATK} Damage!";

        yield return new WaitForSeconds(0.5f);

        eHP = eHP - pATK;
        if (eHP < 0)
        {
            eHP = 0;
        }

        if (powerUp2)
        {
            powerUp2 = false;
            pATK /= 2;
        }
        else if (powerUp3)
        {
            powerUp3 = false;
            pATK /= 3;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (eHP == 0)
        {
            yield return StartCoroutine(PlayerWin());
        }

    }

    public IEnumerator EnemyAttack()
    {
        if (Random.Range(0, 3) == 0)
        {
            yield return StartCoroutine(EnemyActionManager.Instance.EnemyAction());
        }
        else
        {

            battleText.text = $"{eNAME} Attack";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{eATK} Damage!";

            yield return new WaitForSeconds(0.5f);

            pHP = pHP - eATK;
            if (pHP < 0)
            {
                pHP = 0;
            }

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            if (pHP == 0)
            {
                yield return StartCoroutine(PlayerLose());
            }
        }

    }

    public IEnumerator Skill()
    {
        if (buttonOn[3])
        {
            buttonOn[3] = false;
            SkillManager.Instance.useSkill[0] = true;
            yield return StartCoroutine(SkillManager.Instance.UseSkill());
        }
        else if (buttonOn[4])
        {
            buttonOn[4] = false;
            SkillManager.Instance.useSkill[1] = true;
            yield return StartCoroutine(SkillManager.Instance.UseSkill());
        }
        else if (buttonOn[5])
        {
            buttonOn[5] = false;
            SkillManager.Instance.useSkill[2] = true;
            yield return StartCoroutine(SkillManager.Instance.UseSkill());
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(EnemyAttack());

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(Battle());
    }

    public IEnumerator Item()
    {
        if (ItemManager.Instance.getItem[0])
        {
            battleText.text = "HPPotion : Recovers 30 HP";
        }
        else if (ItemManager.Instance.getItem[1])
        {
            battleText.text = "SPPotion : Recovers 30 SP";
        }
        else if (ItemManager.Instance.getItem[2])
        {
            battleText.text = "ATKPotion : Double the next power";
        }
        else if (ItemManager.Instance.getItem[3])
        {
            battleText.text = "HealHerb : Recovers 50 HP";
        }
        else if (ItemManager.Instance.getItem[4])
        {
            battleText.text = "DamageBomb : 30 damage to the enemy";
        }
        else if (ItemManager.Instance.getItem[5])
        {
            battleText.text = "ATKJewel : Triple the next power";
        }

        while (!buttonOn[6] && !buttonOn[7])
        {
            yield return null;
        }

        if (buttonOn[6])
        {
            buttonOn[6] = false;
            windows[4].SetActive(false);
            yield return StartCoroutine(ItemManager.Instance.HaveItem());
        }
        else if (buttonOn[7])
        {
            buttonOn[7] = false;
            windows[4].SetActive(false);
            yield return StartCoroutine(Battle());
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(EnemyAttack());

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(Battle());


    }

    public IEnumerator PlayerLose()
    {
        battleText.text = $"{pName} Lose";

        yield return new WaitForSeconds(1.0f);

        StopAllCoroutines();
    }

    public IEnumerator PlayerWin()
    {
        if (powerUp2)
        {
            powerUp2 = false;
            pATK /= 2;
        }
        else if (powerUp3)
        {
            powerUp3 = false;
            pATK /= 3;
        }

        displayEnemy.sprite = none;
        battleText.text = $"{pName} Win";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{eEXP} Experience gained.";
        pEXP += eEXP;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (pEXP > nEXP)
        {
            battleText.text = "Levels raised!";
            pLv += 1;
            pHP += 10;
            pMaxHP += 10;
            pSP += 5;
            pMaxSP += 5;
            pATK += 5;
            nEXP *= 2;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }

        windows[0].SetActive(false);
        windows[1].SetActive(true);
        yield return StartCoroutine(GameManager.Instance.NextFloor());
    }

    public void AttackComand()
    {
        buttonOn[0] = true;
    }

    public void SkillComand()
    {
        buttonOn[1] = true;
    }

    public void ItemComand()
    {
        buttonOn[2] = true;
    }

    public void Skill1()
    {
        skillUse = true;
        buttonOn[3] = true;
    }

    public void Skill2()
    {
        skillUse = true;
        buttonOn[4] = true;
    }

    public void Skill3()
    {
        skillUse = true;
        buttonOn[5] = true;
    }

    public void ItemUse()
    {
        buttonOn[6] = true;
    }

    public void ItemBack()
    {
        buttonOn[7] = true;
    }

    public void Back()
    {
        back = true;
    }
}

