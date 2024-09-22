using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class BattleManager: Singleton<BattleManager>
{
    public EnemyStatusManager enemyStatusManager; // �G�X�e�[�^�X�p�X�N���v�g
    public PlayerStatusManager playerStatusManager; // �v���C���[�����X�e�[�^�X�p�X�N���v�g

    public string playerName;  // �v���C���[��
    public int playerLv; // �v���C���[���x��
    public int playerHP; // �v���C���[HP
    public int playerMaxHP; // �v���C���[�ő�HP
    public int playerSP; // �v���C���[SP
    public int playerMaxSP; // �v���C���[�ő�SP
    public int playerATK; // �v���C���[�U����
    public int playerEXP; // �v���C���[�o���l
    public int playerNextLvEXP; // ���x���A�b�v�܂ł̌o���l

    public string enemyName; // �G��
    public int enemyLv; // �G���x��
    public int enemyHP; // �GHP
    public int enemyMaxHP; // �G�ő�HP
    public int enemyATK; // �G�U����
    public int enemyEXP; // �G�o���l

    public bool powerUp2 = false; // �U����2�{��Ԃ�\��
    public bool powerUp3 = false; // �U����3�{��Ԃ�\��

    public Image floorBackImage; // �t���A�̔w�i�𓖂Ă͂߂�Image�I�u�W�F�N�g
    public Sprite floorBackSprite; // �t���A�摜
    public Image displayEnemyImage; // �G�𓖂Ă͂߂�Image�I�u�W�F�N�g
    public Sprite[] enemySprite; // �G�̉摜
    private Sprite[] nowEnemySprite; // ���ݐ���Ă���G�̉摜
    public Sprite noneEnemy; // �G�����Ȃ��Ƃ��̉摜
    public TextMeshProUGUI battleText; // �o�g�����̃e�L�X�g

    public TextMeshProUGUI[] playerStatusText; // ��ʂɕ\������v���C���[�̃X�e�[�^�X
    public enum enumPlayerStatusText
    {
        Name, // �v���C���[��.
        Lv, // �v���C���[���x��.
        HP, // �v���C���[HP.
        MaxHP, // �v���C���[�ő�HP 
        SP, // �v���C���[SP.
        MaxSP, // �v���C���[�ő�SP
        ATK, // �v���C���[�U����.
        Num // �X�e�[�^�X�\��UI�̌�.
    }

    public TextMeshProUGUI[] enemyStatusText; // ��ʂɕ\������G�̃X�e�[�^�X
    public enum enumEnemyStatusText
    {
        Name, // �G��
        Lv, // �G���x��
        HP, // �GHP
        MaxHP, // �G�ő�HP
        ATK, // �G�U����
        Num // �G�̃X�e�[�^�X��
    }

    public GameObject[] windows; // �e�E�B���h�E
    public enum enumWindows
    {
        EnemyStatus, // �G�̃X�e�[�^�X�E�B���h�E
        ItemWindow, // �A�C�e���E�B���h�E
        ComandWindow, // �R�}���h�E�B���h�E
        SkillWindow, // �X�L���E�B���h�E
        ItemUseSelect, // �o�g�����A�C�e���g�p�I���E�B���h�E
        Num // �E�B���h�E��
    }

    public GameObject[] defaultButton; // �I���E�B���h�E�ł̏����I���{�^��
    public enum enumDefaultButton
    {
        AttackButton, // �U���{�^��
        SkillBackButton, // �X�L���E�B���h�E�ł̏����I���{�^��
        ItemUseBackButton, // �A�C�e���̎d�l�m�F�ł̏����I���{�^��
        Num // �����I���{�^���̐�
    }

    public bool[] buttonOn; // �o�g�����Ɏg�p����{�^���������Ă��邩�ǂ���
    public enum enumButtonOn
    {
        Attack, // �U���R�}���h
        Skill, // �X�L���R�}���h
        Item, // �A�C�e���R�}���h
        Skill1, // �X�L���P�g�p
        Skill2, // �X�L���Q�g�p
        Skill3, // �X�L���R�g�p
        ItemUse, // �A�C�e���g�p�{�^��
        Back, // �߂�{�^��
        Num // �{�^���������Ă��邩�ǂ����̐�
    }
    public bool skillUse; // �X�L���R�}���h��\��
    public bool itemUse; // �A�C�e���R�}���h��\��
    public bool back; // �e�\������߂�

    void Start()
    {
        // �z�������
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
        battleText.text = "�o�g���t���A���I";
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

        battleText.text = $"{enemyName}�����ꂽ�I";

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
        battleText.text = "���G�t���A���I";
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

        battleText.text = $"{enemyName}�����ꂽ�I";

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
        battleText.text = "�{�X�t���A���I";
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

        battleText.text = $"{enemyName}�����ꂽ�I";

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
        battleText.text = "�R�}���h�H";
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
        battleText.text = $"{playerName}�̍U���I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{playerATK}�̃_���[�W�I";

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

            battleText.text = $"{enemyName}�̍U���I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyATK}�̃_���[�W�I";

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
            battleText.text = "�A�C�e���������Ă��Ȃ��I";

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
            battleText.text = "HP�|�[�V���� : HP��30��";
        }
        else if (ItemManager.Instance.getItem[1])
        {
            battleText.text = "SP�|�[�V���� : SP��30��";
        }
        else if (ItemManager.Instance.getItem[2])
        {
            battleText.text = "�U���|�[�V���� : ���̕����U���͂�2�{";
        }
        else if (ItemManager.Instance.getItem[3])
        {
            battleText.text = "�� : HP��50��";
        }
        else if (ItemManager.Instance.getItem[4])
        {
            battleText.text = "�{�� : �G��30�̃_���[�W";
        }
        else if (ItemManager.Instance.getItem[5])
        {
            battleText.text = "�U���W���G�� : ���̕����U���͂�3�{";
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
        battleText.text = $"{playerName}�͕�����";

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
        battleText.text = $"{playerName}�̏����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyEXP}�̌o���l���l���I";
        playerEXP += enemyEXP;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (playerEXP >= playerNextLvEXP)
        {
            battleText.text = "���x�����オ�����I\n�X�e�[�^�X���オ�����I";
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

