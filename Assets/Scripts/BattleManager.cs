using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class BattleManager: Singleton<BattleManager>
{
    public EnemyStatusManager enemyStatusManager; // 敵ステータス用スクリプト
    public PlayerStatusManager playerStatusManager; // プレイヤー初期ステータス用スクリプト

    public string playerName;  // プレイヤー名
    public int playerLv; // プレイヤーレベル
    public int playerHP; // プレイヤーHP
    public int playerMaxHP; // プレイヤー最大HP
    public int playerSP; // プレイヤーSP
    public int playerMaxSP; // プレイヤー最大SP
    public int playerATK; // プレイヤー攻撃力
    public int playerEXP; // プレイヤー経験値
    public int playerNextLvEXP; // レベルアップまでの経験値

    public string enemyName; // 敵名
    public int enemyLv; // 敵レベル
    public int enemyHP; // 敵HP
    public int enemyMaxHP; // 敵最大HP
    public int enemyATK; // 敵攻撃力
    public int enemyEXP; // 敵経験値

    public bool powerUp2 = false; // 攻撃力2倍状態を表す
    public bool powerUp3 = false; // 攻撃力3倍状態を表す

    public Image floorBackImage; // フロアの背景を当てはめるImageオブジェクト
    public Sprite floorBackSprite; // フロア画像
    public Image displayEnemyImage; // 敵を当てはめるImageオブジェクト
    public Sprite[] enemySprite; // 敵の画像
    private Sprite[] nowEnemySprite; // 現在戦っている敵の画像
    public Sprite noneEnemy; // 敵がいないときの画像
    public TextMeshProUGUI battleText; // バトル時のテキスト

    public TextMeshProUGUI[] playerStatusText; // 画面に表示するプレイヤーのステータス
    public enum enumPlayerStatusText
    {
        Name, // プレイヤー名.
        Lv, // プレイヤーレベル.
        HP, // プレイヤーHP.
        MaxHP, // プレイヤー最大HP 
        SP, // プレイヤーSP.
        MaxSP, // プレイヤー最大SP
        ATK, // プレイヤー攻撃力.
        Num // ステータス表示UIの個数.
    }

    public TextMeshProUGUI[] enemyStatusText; // 画面に表示する敵のステータス
    public enum enumEnemyStatusText
    {
        Name, // 敵名
        Lv, // 敵レベル
        HP, // 敵HP
        MaxHP, // 敵最大HP
        ATK, // 敵攻撃力
        Num // 敵のステータス数
    }

    public GameObject[] windows; // 各ウィンドウ
    public enum enumWindows
    {
        EnemyStatus, // 敵のステータスウィンドウ
        ItemWindow, // アイテムウィンドウ
        ComandWindow, // コマンドウィンドウ
        SkillWindow, // スキルウィンドウ
        ItemUseSelect, // バトル時アイテム使用選択ウィンドウ
        Num // ウィンドウ数
    }

    public GameObject[] defaultButton; // 選択ウィンドウでの初期選択ボタン
    public enum enumDefaultButton
    {
        AttackButton, // 攻撃ボタン
        SkillBackButton, // スキルウィンドウでの初期選択ボタン
        ItemUseBackButton, // アイテムの仕様確認での初期選択ボタン
        Num // 初期選択ボタンの数
    }

    public bool[] buttonOn; // バトル時に使用するボタンを押しているかどうか
    public enum enumButtonOn
    {
        Attack, // 攻撃コマンド
        Skill, // スキルコマンド
        Item, // アイテムコマンド
        Skill1, // スキル１使用
        Skill2, // スキル２使用
        Skill3, // スキル３使用
        ItemUse, // アイテム使用ボタン
        Back, // 戻るボタン
        Num // ボタンを押しているかどうかの数
    }
    public bool skillUse; // スキルコマンドを表示
    public bool itemUse; // アイテムコマンドを表示
    public bool back; // 各表示から戻る

    void Start()
    {
        // 配列を準備
        playerStatusText = new TextMeshProUGUI[(int)enumPlayerStatusText.Num];
        enemyStatusText = new TextMeshProUGUI[(int)enumEnemyStatusText.Num];
        windows = new GameObject[(int)enumWindows.Num];
        defaultButton = new GameObject[(int)enumDefaultButton.Num];
        buttonOn = new bool[(int)enumButtonOn.Num];

        floorBackImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorBackSprite = Resources.Load<Sprite>("Images/FloorBacks/DefaultBack");
        displayEnemyImage = GameObject.Find("EnemyImage").GetComponent<Image>();
        noneEnemy = Resources.Load<Sprite>("Images/Enemys/Unknown");
        battleText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();

        playerStatusText[(int)enumPlayerStatusText.Name] = GameObject.Find("PlayerNameText").GetComponent<TextMeshProUGUI>();
        playerStatusText[(int)enumPlayerStatusText.Lv] = GameObject.Find("PlayerLvText").GetComponent<TextMeshProUGUI>();
        playerStatusText[(int)enumPlayerStatusText.HP] = GameObject.Find("PlayerHPText").GetComponent<TextMeshProUGUI>();
        playerStatusText[(int)enumPlayerStatusText.MaxHP] = GameObject.Find("PlayerMaxHPText").GetComponent<TextMeshProUGUI>();
        playerStatusText[(int)enumPlayerStatusText.SP] = GameObject.Find("PlayerSPText").GetComponent<TextMeshProUGUI>();
        playerStatusText[(int)enumPlayerStatusText.MaxSP] = GameObject.Find("PlayerMaxSPText").GetComponent<TextMeshProUGUI>();
        playerStatusText[(int)enumPlayerStatusText.ATK] = GameObject.Find("PlayerATKText").GetComponent<TextMeshProUGUI>();

        enemyStatusText[(int)enumEnemyStatusText.Name] = GameObject.Find("EnemyNameText").GetComponent<TextMeshProUGUI>();
        enemyStatusText[(int)enumEnemyStatusText.Lv] = GameObject.Find("EnemyLvText").GetComponent<TextMeshProUGUI>();
        enemyStatusText[(int)enumEnemyStatusText.HP] = GameObject.Find("EnemyHPText").GetComponent<TextMeshProUGUI>();
        enemyStatusText[(int)enumEnemyStatusText.MaxHP] = GameObject.Find("EnemyMaxHPText").GetComponent<TextMeshProUGUI>();
        enemyStatusText[(int)enumEnemyStatusText.ATK] = GameObject.Find("EnemyATKText").GetComponent<TextMeshProUGUI>();

        windows[(int)enumWindows.EnemyStatus] = GameObject.Find("enemyStatusWindow");
        windows[(int)enumWindows.ItemWindow] = GameObject.Find("itemWindow");
        windows[(int)enumWindows.ComandWindow] = GameObject.Find("comandWindow");
        windows[(int)enumWindows.SkillWindow] = GameObject.Find("skillWindow");
        windows[(int)enumWindows.ItemUseSelect] = GameObject.Find("ItemSelectWindow");

        defaultButton[(int)enumDefaultButton.AttackButton] = GameObject.Find("attackButton");
        defaultButton[(int)enumDefaultButton.SkillBackButton] = GameObject.Find("skillBackButton");
        defaultButton[(int)enumDefaultButton.ItemUseBackButton] = GameObject.Find("itemUseBackButton");

        windows[(int)enumWindows.EnemyStatus].SetActive(false);
        windows[(int)enumWindows.ComandWindow].SetActive(false);
        windows[(int)enumWindows.ItemUseSelect].SetActive(false);

        if (DebugScript.Instance.Fighter)
        {
            playerName = playerStatusManager.DataList[0].pNAME;
            playerLv = playerStatusManager.DataList[0].pLv;
            playerHP = playerStatusManager.DataList[0].pHP;
            playerMaxHP = playerStatusManager.DataList[0].pHP;
            playerSP = playerStatusManager.DataList[0].pSP;
            playerMaxSP = playerStatusManager.DataList[0].pSP;
            playerATK = playerStatusManager.DataList[0].pATK;

        }
        else if (DebugScript.Instance.Magician)
        {
            playerName = playerStatusManager.DataList[1].pNAME;
            playerLv = playerStatusManager.DataList[1].pLv;
            playerHP = playerStatusManager.DataList[1].pHP;
            playerMaxHP = playerStatusManager.DataList[1].pHP;
            playerSP = playerStatusManager.DataList[1].pSP;
            playerMaxSP = playerStatusManager.DataList[1].pSP;
            playerATK = playerStatusManager.DataList[1].pATK;
        }

        playerStatusText[(int)enumPlayerStatusText.Name].text = playerName;

    }

    void Update()
    {
        playerStatusText[(int)enumPlayerStatusText.Lv].text = playerLv.ToString();
        playerStatusText[(int)enumPlayerStatusText.HP].text = playerHP.ToString();
        playerStatusText[(int)enumPlayerStatusText.MaxHP].text = playerMaxHP.ToString();
        playerStatusText[(int)enumPlayerStatusText.SP].text = playerSP.ToString();
        playerStatusText[(int)enumPlayerStatusText.MaxSP].text = playerMaxSP.ToString();
        playerStatusText[(int)enumPlayerStatusText.ATK].text = playerATK.ToString();

        enemyStatusText[(int)enumEnemyStatusText.Lv].text = enemyLv.ToString();
        enemyStatusText[(int)enumEnemyStatusText.HP].text = enemyHP.ToString();
        enemyStatusText[(int)enumEnemyStatusText.MaxHP].text = enemyMaxHP.ToString();
        enemyStatusText[(int)enumEnemyStatusText.ATK].text = enemyATK.ToString();

    }

    public IEnumerator BattleStart()
    {
        battleText.text = "バトルフロアだ！";
        floorBackImage.sprite = floorBackSprite;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (GameManager.Instance.floorNumber <= GameManager.Instance.maxFloorNumber / 2)
        {
            nowEnemySprite = new Sprite[] { enemySprite[0], enemySprite[1], enemySprite[2] };
            int randomNumber = Random.Range(0, nowEnemySprite.Length);
            Sprite selectedSprite = nowEnemySprite[randomNumber];
            displayEnemyImage.sprite = selectedSprite;

            enemyName = enemyStatusManager.DataList[randomNumber].eNAME;
            enemyLv = enemyStatusManager.DataList[randomNumber].eLv;
            enemyHP = enemyStatusManager.DataList[randomNumber].eHP;
            enemyMaxHP = enemyStatusManager.DataList[randomNumber].eHP;
            enemyATK = enemyStatusManager.DataList[randomNumber].eATK;
            enemyEXP = enemyStatusManager.DataList[randomNumber].eEXP;
            enemyStatusText[(int)enumEnemyStatusText.Name].text = enemyName;
        }
        else
        {
            nowEnemySprite = new Sprite[] { enemySprite[3], enemySprite[4], enemySprite[5] };
            int randomNumber = Random.Range(3, nowEnemySprite.Length);
            Sprite selectedSprite = nowEnemySprite[randomNumber];
            displayEnemyImage.sprite = selectedSprite;

            enemyName = enemyStatusManager.DataList[randomNumber].eNAME;
            enemyLv = enemyStatusManager.DataList[randomNumber].eLv;
            enemyHP = enemyStatusManager.DataList[randomNumber].eHP;
            enemyMaxHP = enemyStatusManager.DataList[randomNumber].eHP;
            enemyATK = enemyStatusManager.DataList[randomNumber].eATK;
            enemyEXP = enemyStatusManager.DataList[randomNumber].eEXP;
            enemyStatusText[(int)enumEnemyStatusText.Name].text = enemyName;
        }

        battleText.text = $"{enemyName}が現れた！";

        windows[(int)enumWindows.EnemyStatus].SetActive(true);
        windows[(int)enumWindows.ItemWindow].SetActive(false);

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(Battle());

    }

    public IEnumerator StrongStart()
    {
        battleText.text = "強敵フロアだ！";
        floorBackImage.sprite = floorBackSprite;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        nowEnemySprite = new Sprite[] { enemySprite[6], enemySprite[7], enemySprite[8] };
        int randomNumber = Random.Range(0, nowEnemySprite.Length);
        Sprite selectedSprite = nowEnemySprite[randomNumber];
        displayEnemyImage.sprite = selectedSprite;

        enemyName = enemyStatusManager.DataList[randomNumber].eNAME;
        enemyLv = enemyStatusManager.DataList[randomNumber].eLv;
        enemyHP = enemyStatusManager.DataList[randomNumber].eHP;
        enemyMaxHP = enemyStatusManager.DataList[randomNumber].eHP;
        enemyATK = enemyStatusManager.DataList[randomNumber].eATK;
        enemyEXP = enemyStatusManager.DataList[randomNumber].eEXP;
        enemyStatusText[(int)enumEnemyStatusText.Name].text = enemyName;

        battleText.text = $"{enemyName}が現れた！";

        windows[(int)enumWindows.EnemyStatus].SetActive(true);
        windows[(int)enumWindows.ItemWindow].SetActive(false);

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(Battle());

    }

    public IEnumerator BossStart()
    {
        battleText.text = "ボスフロアだ！";
        floorBackImage.sprite = floorBackSprite;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        Sprite selectedSprite = nowEnemySprite[9];
        displayEnemyImage.sprite = selectedSprite;

        enemyName = enemyStatusManager.DataList[9].eNAME;
        enemyLv = enemyStatusManager.DataList[9].eLv;
        enemyHP = enemyStatusManager.DataList[9].eHP;
        enemyMaxHP = enemyStatusManager.DataList[9].eHP;
        enemyATK = enemyStatusManager.DataList[9].eATK;
        enemyEXP = enemyStatusManager.DataList[9].eEXP;
        enemyStatusText[(int)enumEnemyStatusText.Name].text = enemyName;

        battleText.text = $"{enemyName}が現れた！";

        windows[(int)enumWindows.EnemyStatus].SetActive(true);
        windows[(int)enumWindows.ItemWindow].SetActive(false);

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(Battle());

    }

    public IEnumerator Battle()
    {
        battleText.text = "コマンド？";
        windows[(int)enumWindows.ComandWindow].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[0]);

        yield return new WaitForSeconds(1.0f);

        while (!buttonOn[(int)enumButtonOn.Attack] && !buttonOn[(int)enumButtonOn.Skill] && !buttonOn[(int)enumButtonOn.Item])
        {
            yield return null;
        }
        windows[(int)enumWindows.ComandWindow].SetActive(false);

        if (buttonOn[(int)enumButtonOn.Attack])
        {
            windows[(int)enumWindows.ComandWindow].SetActive(false);
            buttonOn[(int)enumButtonOn.Attack] = false;
            yield return StartCoroutine(Attack());
        }
        else if (buttonOn[(int)enumButtonOn.Skill])
        {
            windows[(int)enumWindows.ComandWindow].SetActive(false);
            buttonOn[(int)enumButtonOn.Skill] = false;
            windows[(int)enumWindows.SkillWindow].SetActive(true);
            EventSystem.current.SetSelectedGameObject(defaultButton[1]);

            while (!skillUse && !back)
            {
                yield return null;
            }

            if(skillUse)
            {
                windows[(int)enumWindows.SkillWindow].SetActive(false);
                skillUse = false;
                yield return StartCoroutine(Skill());
            }
            else
            {
                windows[(int)enumWindows.SkillWindow].SetActive(false);
                back = false;
                yield return StartCoroutine(Battle());

            }

        }
        else if (buttonOn[(int)enumButtonOn.Item])
        {
            windows[(int)enumWindows.ComandWindow].SetActive(false);
            buttonOn[(int)enumButtonOn.Item] = false;

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
        battleText.text = $"{playerName}の攻撃！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{playerATK}のダメージ！";

        yield return new WaitForSeconds(0.5f);

        enemyHP = enemyHP - playerATK;
        if (enemyHP < 0)
        {
            enemyHP = 0;
        }

        if (powerUp2)
        {
            powerUp2 = false;
            playerATK /= 2;
        }
        else if (powerUp3)
        {
            powerUp3 = false;
            playerATK /= 3;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (enemyHP == 0)
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

            battleText.text = $"{enemyName}の攻撃！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyATK}のダメージ！";

            yield return new WaitForSeconds(0.5f);

            playerHP = playerHP - enemyATK;
            if (playerHP < 0)
            {
                playerHP = 0;
            }

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            if (playerHP == 0)
            {
                yield return StartCoroutine(PlayerLose());
            }
        }

    }

    public IEnumerator Skill()
    {
        if (buttonOn[(int)enumButtonOn.Skill1])
        {
            buttonOn[(int)enumButtonOn.Skill1] = false;
            if (DebugScript.Instance.Fighter)
            {
                SkillManager.Instance.useSkill[0] = true;
                yield return StartCoroutine(SkillManager.Instance.UseSkill());
            }
            else if (DebugScript.Instance.Magician)
            {
                SkillManager.Instance.useSkill[3] = true;
                yield return StartCoroutine(SkillManager.Instance.UseSkill());
            }
        }
        else if (buttonOn[(int)enumButtonOn.Skill2])
        {
            buttonOn[(int)enumButtonOn.Skill2] = false;
            if (DebugScript.Instance.Fighter)
            {
                SkillManager.Instance.useSkill[1] = true;
                yield return StartCoroutine(SkillManager.Instance.UseSkill());
            }
            else if (DebugScript.Instance.Magician)
            {
                SkillManager.Instance.useSkill[4] = true;
                yield return StartCoroutine(SkillManager.Instance.UseSkill());
            }
        }
        else if (buttonOn[(int)enumButtonOn.Skill3])
        {
            buttonOn[(int)enumButtonOn.Skill3] = false;
            if (DebugScript.Instance.Fighter)
            {
                SkillManager.Instance.useSkill[2] = true;
                yield return StartCoroutine(SkillManager.Instance.UseSkill());
            }
            else if (DebugScript.Instance.Magician)
            {
                SkillManager.Instance.useSkill[5] = true;
                yield return StartCoroutine(SkillManager.Instance.UseSkill());
            }
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
        if (!ItemManager.Instance.haveItem)
        {
            battleText.text = "アイテムを持っていない！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            yield return StartCoroutine(Battle());
        }
        else
        {
            windows[(int)enumWindows.ItemUseSelect].SetActive(true);
            EventSystem.current.SetSelectedGameObject(defaultButton[2]);
        }

        if (ItemManager.Instance.getItem[0])
        {
            battleText.text = "HPポーション : HPを30回復";
        }
        else if (ItemManager.Instance.getItem[1])
        {
            battleText.text = "SPポーション : SPを30回復";
        }
        else if (ItemManager.Instance.getItem[2])
        {
            battleText.text = "攻撃ポーション : 次の物理攻撃力が2倍";
        }
        else if (ItemManager.Instance.getItem[3])
        {
            battleText.text = "薬草 : HPを50回復";
        }
        else if (ItemManager.Instance.getItem[4])
        {
            battleText.text = "ボム : 敵に30のダメージ";
        }
        else if (ItemManager.Instance.getItem[5])
        {
            battleText.text = "攻撃ジュエル : 次の物理攻撃力が3倍";
        }

        while (!buttonOn[(int)enumButtonOn.ItemUse] && !buttonOn[(int)enumButtonOn.Back])
        {
            yield return null;
        }

        if (buttonOn[(int)enumButtonOn.ItemUse])
        {
            buttonOn[(int)enumButtonOn.ItemUse] = false;
            windows[(int)enumWindows.ItemUseSelect].SetActive(false);
            yield return StartCoroutine(ItemManager.Instance.HaveItem());
        }
        else if (buttonOn[(int)enumButtonOn.Back])
        {
            buttonOn[(int)enumButtonOn.Back] = false;
            windows[(int)enumWindows.ItemUseSelect].SetActive(false);
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
        battleText.text = $"{playerName}は負けた";

        yield return new WaitForSeconds(1.0f);

        StopAllCoroutines();
    }

    public IEnumerator PlayerWin()
    {
        if (powerUp2)
        {
            powerUp2 = false;
            playerATK /= 2;
        }
        else if (powerUp3)
        {
            powerUp3 = false;
            playerATK /= 3;
        }

        displayEnemyImage.sprite = noneEnemy;
        battleText.text = $"{playerName}の勝利！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyEXP}の経験値を獲得！";
        playerEXP += enemyEXP;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (playerEXP >= playerNextLvEXP)
        {
            battleText.text = "レベルが上がった！\nステータスが上がった！";
            if (DebugScript.Instance.Fighter)
            {
                playerLv += 1;
                playerMaxHP += 10;
                playerMaxSP += 2;
                playerATK += 2;
                playerEXP = 0;
                playerNextLvEXP *= 2;
            }
            else if (DebugScript.Instance.Magician)
            {
                playerLv += 1;
                playerMaxHP += 5;
                playerMaxSP += 10;
                playerATK += 1;
                playerEXP = 0;
                playerNextLvEXP *= 2;
            }

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }

        windows[(int)enumWindows.EnemyStatus].SetActive(false);
        windows[(int)enumWindows.ItemWindow].SetActive(true);
        yield return StartCoroutine(GameManager.Instance.NextFloor());
    }

    public void AttackComand()
    {
        buttonOn[(int)enumButtonOn.Attack] = true;
    }

    public void SkillComand()
    {
        buttonOn[(int)enumButtonOn.Skill] = true;
    }

    public void ItemComand()
    {
        buttonOn[(int)enumButtonOn.Item] = true;
    }

    public void Skill1()
    {
        skillUse = true;
        buttonOn[(int)enumButtonOn.Skill1] = true;
    }

    public void Skill2()
    {
        skillUse = true;
        buttonOn[(int)enumButtonOn.Skill2] = true;
    }

    public void Skill3()
    {
        skillUse = true;
        buttonOn[(int)enumButtonOn.Skill3] = true;
    }

    public void ItemUse()
    {
        buttonOn[(int)enumButtonOn.ItemUse] = true;
    }

    public void ItemBack()
    {
        buttonOn[(int)enumButtonOn.Back] = true;
    }

    public void Back()
    {
        back = true;
    }
}

