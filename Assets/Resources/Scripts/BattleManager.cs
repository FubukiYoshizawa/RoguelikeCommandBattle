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
    public int[] skillSlot; // �L�����N�^�[���Ƃ̎g�p�\�X�L��
    public enum enumSkillSlot
    {
        Skill1,
        Skill2,
        Skill3,
        Num
    }

    public string enemyName; // �G��
    public int enemyLv; // �G���x��
    public int enemyHP; // �GHP
    public int enemyMaxHP; // �G�ő�HP
    public int enemyATK; // �G�U����
    public int enemyEXP; // �G�o���l

    public int baseAttack; // �U���͏㏸���̌��̍U����
    public bool powerUp; // �U���͏㏸��Ԃ�\��

    public bool bossBattle; // ���݂��{�X�o�g�����ǂ���

    public Image floorBackImage; // �t���A�̔w�i�𓖂Ă͂߂�Image�I�u�W�F�N�g
    public Sprite floorBackSprite; // �t���A�摜
    public Image displayEnemyImage; // �G�𓖂Ă͂߂�Image�I�u�W�F�N�g
    public Sprite[] enemySprite; // �G�̉摜
    public enum enumEnemySprite
    {
        Slime,
        IkeBat,
        HatGhost,
        GodADeath,
        Tornado,
        ThunderOni,
        InfernoButterfly,
        DarkDragon,
        IceDragon,
        BabyDragon,
        LightDragon,
        Num
    }
    private Sprite[] nowEnemySprite; // ���ݐ���Ă���G�̉摜
    public Sprite noneEnemy; // �G�����Ȃ��Ƃ��̉摜
    public TextMeshProUGUI mainText; // ���C���̃e�L�X�g

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
    public bool skillBack; // �X�L���R�}���h�\������߂�

    void Start()
    {
        // ScriptableObject�̓ǂݍ���
        enemyStatusManager = Resources.Load<EnemyStatusManager>("ScriptableObject/EnemyStatusManager");
        playerStatusManager = Resources.Load<PlayerStatusManager>("ScriptableObject/PlayerStatusManager");

        // �e�z��̏�����
        skillSlot = new int[(int)enumSkillSlot.Num];
        enemySprite = new Sprite[(int)enumEnemySprite.Num];
        playerStatusText = new TextMeshProUGUI[(int)enumPlayerStatusText.Num];
        enemyStatusText = new TextMeshProUGUI[(int)enumEnemyStatusText.Num];
        windows = new GameObject[(int)enumWindows.Num];
        defaultButton = new GameObject[(int)enumDefaultButton.Num];
        buttonOn = new bool[(int)enumButtonOn.Num];

        // �\������Image�R���|�[�l���g�̎擾�ƊeSprite�̓ǂݍ���
        floorBackImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorBackSprite = Resources.Load<Sprite>("Images/FloorBacks/DefaultBack");
        displayEnemyImage = GameObject.Find("EnemyImage").GetComponent<Image>();
        noneEnemy = Resources.Load<Sprite>("Images/Enemys/Unknown");

        // ���C���e�L�X�g��UI�I�u�W�F�N�g�ǂݍ���
        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();

        // �G�摜��Sprite�̓ǂݍ���
        enemySprite[(int)enumEnemySprite.Slime] = Resources.Load<Sprite>("Images/Enemys/Slime");
        enemySprite[(int)enumEnemySprite.IkeBat] = Resources.Load<Sprite>("Images/Enemys/IkeBat");
        enemySprite[(int)enumEnemySprite.HatGhost] = Resources.Load<Sprite>("Images/Enemys/HatGhost");
        enemySprite[(int)enumEnemySprite.GodADeath] = Resources.Load<Sprite>("Images/Enemys/GodADeath");
        enemySprite[(int)enumEnemySprite.Tornado] = Resources.Load<Sprite>("Images/Enemys/Tornado");
        enemySprite[(int)enumEnemySprite.ThunderOni] = Resources.Load<Sprite>("Images/Enemys/ThunderOni");
        enemySprite[(int)enumEnemySprite.InfernoButterfly] = Resources.Load<Sprite>("Images/Enemys/InfernoButterfly");
        enemySprite[(int)enumEnemySprite.DarkDragon] = Resources.Load<Sprite>("Images/Enemys/DarkDragon");
        enemySprite[(int)enumEnemySprite.IceDragon] = Resources.Load<Sprite>("Images/Enemys/IceDragon");
        enemySprite[(int)enumEnemySprite.BabyDragon] = Resources.Load<Sprite>("Images/Enemys/BabyDragon");
        enemySprite[(int)enumEnemySprite.LightDragon] = Resources.Load<Sprite>("Images/Enemys/LightDragon");

        // �v���C���[�X�e�[�^�X��\������UI�I�u�W�F�N�g�̓ǂݍ���
        playerStatusText[(int)enumPlayerStatusText.Name] = GameObject.Find("PlayerNameText").GetComponent<TextMeshProUGUI>();
        playerStatusText[(int)enumPlayerStatusText.Lv] = GameObject.Find("PlayerLvText").GetComponent<TextMeshProUGUI>();
        playerStatusText[(int)enumPlayerStatusText.HP] = GameObject.Find("PlayerHPText").GetComponent<TextMeshProUGUI>();
        playerStatusText[(int)enumPlayerStatusText.MaxHP] = GameObject.Find("PlayerMaxHPText").GetComponent<TextMeshProUGUI>();
        playerStatusText[(int)enumPlayerStatusText.SP] = GameObject.Find("PlayerSPText").GetComponent<TextMeshProUGUI>();
        playerStatusText[(int)enumPlayerStatusText.MaxSP] = GameObject.Find("PlayerMaxSPText").GetComponent<TextMeshProUGUI>();
        playerStatusText[(int)enumPlayerStatusText.ATK] = GameObject.Find("PlayerATKText").GetComponent<TextMeshProUGUI>();

        // �G�X�e�[�^�X��\������UI�I�u�W�F�N�g�̓ǂݍ���
        enemyStatusText[(int)enumEnemyStatusText.Name] = GameObject.Find("EnemyNameText").GetComponent<TextMeshProUGUI>();
        enemyStatusText[(int)enumEnemyStatusText.Lv] = GameObject.Find("EnemyLvText").GetComponent<TextMeshProUGUI>();
        enemyStatusText[(int)enumEnemyStatusText.HP] = GameObject.Find("EnemyHPText").GetComponent<TextMeshProUGUI>();
        enemyStatusText[(int)enumEnemyStatusText.MaxHP] = GameObject.Find("EnemyMaxHPText").GetComponent<TextMeshProUGUI>();
        enemyStatusText[(int)enumEnemyStatusText.ATK] = GameObject.Find("EnemyATKText").GetComponent<TextMeshProUGUI>();

        // �\����؂�ւ���E�B���h�E�̓ǂݍ���
        windows[(int)enumWindows.EnemyStatus] = GameObject.Find("enemyStatusWindow");
        windows[(int)enumWindows.ItemWindow] = GameObject.Find("itemWindow");
        windows[(int)enumWindows.ComandWindow] = GameObject.Find("comandWindow");
        windows[(int)enumWindows.SkillWindow] = GameObject.Find("skillWindow");
        windows[(int)enumWindows.ItemUseSelect] = GameObject.Find("ItemSelectWindow");

        // �E�B���h�E�؂�ւ����̑I���{�^���̓ǂݍ���
        defaultButton[(int)enumDefaultButton.AttackButton] = GameObject.Find("attackButton");
        defaultButton[(int)enumDefaultButton.SkillBackButton] = GameObject.Find("SkillBackButton");
        defaultButton[(int)enumDefaultButton.ItemUseBackButton] = GameObject.Find("itemUseBackButton");

        // ������\���E�B���h�E�̐ݒ�
        windows[(int)enumWindows.EnemyStatus].SetActive(false);
        windows[(int)enumWindows.ComandWindow].SetActive(false);
        windows[(int)enumWindows.ItemUseSelect].SetActive(false);

        // �v���C���[�̃X�e�[�^�X������
        int baseCharacterStatus = PlayerPrefs.GetInt("Character");
        playerName = playerStatusManager.DataList[baseCharacterStatus].pNAME;
        playerLv = playerStatusManager.DataList[baseCharacterStatus].pLv;
        playerHP = playerStatusManager.DataList[baseCharacterStatus].pHP;
        playerMaxHP = playerStatusManager.DataList[baseCharacterStatus].pHP;
        playerSP = playerStatusManager.DataList[baseCharacterStatus].pSP;
        playerMaxSP = playerStatusManager.DataList[baseCharacterStatus].pSP;
        playerATK = playerStatusManager.DataList[baseCharacterStatus].pATK;
        skillSlot[0] = playerStatusManager.DataList[baseCharacterStatus].skillSlot[0];
        skillSlot[1] = playerStatusManager.DataList[baseCharacterStatus].skillSlot[1];
        skillSlot[2] = playerStatusManager.DataList[baseCharacterStatus].skillSlot[2];

        // �v���C���[���̕\��
        playerStatusText[(int)enumPlayerStatusText.Name].text = playerName;

    }

    void Update()
    {
        // �e�X�e�[�^�X�̍X�V
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

    // �ʏ�퓬�J�n���̏���
    public IEnumerator BattleStart()
    {
        mainText.text = "�o�g���t���A���I";
        floorBackImage.sprite = floorBackSprite;

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlayBGM((int)SoundManager.enumBgmNumber.Battle);
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);

        // �I��������Փx���i�s�󋵂œG��ς���
        nowEnemySprite = new Sprite[] { enemySprite[(int)enumEnemySprite.Slime], enemySprite[(int)enumEnemySprite.IkeBat], enemySprite[(int)enumEnemySprite.HatGhost] };
        int randomNumber = Random.Range(0, nowEnemySprite.Length);
        if (GameManager.Instance.floorNumber > GameManager.Instance.maxFloorNumber / 2 && PlayerPrefs.GetInt("Difficulty") >= 1)
        {
            randomNumber += 3;
        }
        Sprite selectedSprite = nowEnemySprite[randomNumber];
        displayEnemyImage.sprite = selectedSprite;
        enemyName = enemyStatusManager.DataList[randomNumber].eNAME;
        enemyLv = enemyStatusManager.DataList[randomNumber].eLv;
        enemyHP = enemyStatusManager.DataList[randomNumber].eHP;
        enemyMaxHP = enemyStatusManager.DataList[randomNumber].eHP;
        enemyATK = enemyStatusManager.DataList[randomNumber].eATK;
        enemyEXP = enemyStatusManager.DataList[randomNumber].eEXP;
        enemyStatusText[(int)enumEnemyStatusText.Name].text = enemyName;

        mainText.text = $"{enemyName}�����ꂽ�I";

        windows[(int)enumWindows.EnemyStatus].SetActive(true);
        windows[(int)enumWindows.ItemWindow].SetActive(false);

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        yield return StartCoroutine(Battle());

    }

    // ���G�퓬�J�n���̏���
    public IEnumerator StrongStart()
    {
        mainText.text = "���G�t���A���I";
        floorBackImage.sprite = floorBackSprite;
        GameManager.Instance.floorIconImage.sprite = GameManager.Instance.floorIconSprite[(int)GameManager.enumFloorIconSprite.StrongFloor];

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlayBGM((int)SoundManager.enumBgmNumber.StrongBattle);
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        nowEnemySprite = new Sprite[] { enemySprite[(int)enumEnemySprite.InfernoButterfly], enemySprite[(int)enumEnemySprite.DarkDragon], enemySprite[(int)enumEnemySprite.IceDragon] };
        int randomNumber = Random.Range(0, nowEnemySprite.Length);
        Sprite selectedSprite = nowEnemySprite[randomNumber];
        displayEnemyImage.sprite = selectedSprite;

        randomNumber += 6;
        enemyName = enemyStatusManager.DataList[randomNumber].eNAME;
        enemyLv = enemyStatusManager.DataList[randomNumber].eLv;
        enemyHP = enemyStatusManager.DataList[randomNumber].eHP;
        enemyMaxHP = enemyStatusManager.DataList[randomNumber].eHP;
        enemyATK = enemyStatusManager.DataList[randomNumber].eATK;
        enemyEXP = enemyStatusManager.DataList[randomNumber].eEXP;
        enemyStatusText[(int)enumEnemyStatusText.Name].text = enemyName;

        mainText.text = $"{enemyName}�����ꂽ�I";

        windows[(int)enumWindows.EnemyStatus].SetActive(true);
        windows[(int)enumWindows.ItemWindow].SetActive(false);

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        yield return StartCoroutine(Battle());

    }

    // �{�X�퓬�J�n���̏���
    public IEnumerator BossStart()
    {
        mainText.text = "�{�X�t���A���I";
        floorBackImage.sprite = floorBackSprite;
        GameManager.Instance.floorIconImage.sprite = GameManager.Instance.floorIconSprite[(int)GameManager.enumFloorIconSprite.BossFloor];
        bossBattle = true;

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlayBGM((int)SoundManager.enumBgmNumber.BossBattle);
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        if (PlayerPrefs.GetInt("Difficulty") == (int)TitleManager.enumDifficultyID.Easy)
        {
            displayEnemyImage.sprite = enemySprite[(int)enumEnemySprite.BabyDragon];

            enemyName = enemyStatusManager.DataList[9].eNAME;
            enemyLv = enemyStatusManager.DataList[9].eLv;
            enemyHP = enemyStatusManager.DataList[9].eHP;
            enemyMaxHP = enemyStatusManager.DataList[9].eHP;
            enemyATK = enemyStatusManager.DataList[9].eATK;
            enemyEXP = enemyStatusManager.DataList[9].eEXP;
            enemyStatusText[(int)enumEnemyStatusText.Name].text = enemyName;
        }
        else if (PlayerPrefs.GetInt("Difficulty") == (int)TitleManager.enumDifficultyID.Normal)
        {
            displayEnemyImage.sprite = enemySprite[(int)enumEnemySprite.LightDragon];

            enemyName = enemyStatusManager.DataList[10].eNAME;
            enemyLv = enemyStatusManager.DataList[10].eLv;
            enemyHP = enemyStatusManager.DataList[10].eHP;
            enemyMaxHP = enemyStatusManager.DataList[10].eHP;
            enemyATK = enemyStatusManager.DataList[10].eATK;
            enemyEXP = enemyStatusManager.DataList[10].eEXP;
            enemyStatusText[(int)enumEnemyStatusText.Name].text = enemyName;
        }

        mainText.text = $"{enemyName}�����ꂽ�I";

        windows[(int)enumWindows.EnemyStatus].SetActive(true);
        windows[(int)enumWindows.ItemWindow].SetActive(false);

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        yield return StartCoroutine(Battle());

    }

    // �퓬���̋��ʏ���
    public IEnumerator Battle()
    {
        mainText.text = "�R�}���h�H";

        yield return new WaitForSeconds(0.5f);

        windows[(int)enumWindows.ComandWindow].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[0]);

        while (!buttonOn[(int)enumButtonOn.Attack] && !buttonOn[(int)enumButtonOn.Skill] && !buttonOn[(int)enumButtonOn.Item])
        {
            yield return null;
        }

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
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
            SkillManager.Instance.skillDescriptionDisplay = true;
            EventSystem.current.SetSelectedGameObject(defaultButton[1]);

            while (!skillUse && !skillBack)
            {
                yield return null;
            }

            if (skillUse)
            {
                SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
                windows[(int)enumWindows.SkillWindow].SetActive(false);
                skillUse = false;
                SkillManager.Instance.skillDescriptionDisplay = false;
                yield return StartCoroutine(Skill());
            }
            else
            {
                SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Back);
                windows[(int)enumWindows.SkillWindow].SetActive(false);
                skillBack = false;
                SkillManager.Instance.skillDescriptionDisplay = false;
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

    // �U���R�}���h�I�����̏���
    public IEnumerator Attack()
    {
        yield return StartCoroutine(PlayerAttack());

        yield return StartCoroutine(EnemyAttack());

        yield return StartCoroutine(Battle());
    }

    // �v���C���[�̒ʏ�U���̏���
    public IEnumerator PlayerAttack()
    {
        mainText.text = $"{playerName}�̍U���I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Attack);
        FlashManager.Instance.EnemyFlash(Color.red, 0.3f);
        mainText.text = $"{playerATK}�̃_���[�W�I";

        yield return new WaitForSeconds(0.5f);

        enemyHP = enemyHP - playerATK;
        if (enemyHP < 0)
        {
            enemyHP = 0;
        }

        if (powerUp)
        {
            powerUp = false;
            playerATK = baseAttack;
        }

        yield return StartCoroutine(NextProcess(1.0f));

        if (enemyHP == 0)
        {
            yield return StartCoroutine(PlayerWin());
        }
        else
        {
            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        }

    }

    // �G�̍U���̏���
    public IEnumerator EnemyAttack()
    {
        if (Random.Range(0, 3) == 0)
        {
            yield return StartCoroutine(EnemyActionManager.Instance.EnemyAction());
        }
        else
        {

            mainText.text = $"{enemyName}�̍U���I";

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Damage);
            FlashManager.Instance.FlashScreen(Color.red, 0.3f);
            mainText.text = $"{enemyATK}�̃_���[�W�I";

            yield return new WaitForSeconds(0.5f);

            playerHP = playerHP - enemyATK;
            if (playerHP < 0)
            {
                playerHP = 0;
            }

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
            if (playerHP == 0)
            {
                yield return StartCoroutine(PlayerLose());
            }
        }

    }

    // �X�L���g�p���̏���
    public IEnumerator Skill()
    {
        // �X�L�����Ƃ̏�������
        if (buttonOn[(int)enumButtonOn.Skill1])
        {
            buttonOn[(int)enumButtonOn.Skill1] = false;
            SkillManager.Instance.useSkill[skillSlot[0]] = true;
            yield return StartCoroutine(SkillManager.Instance.UseSkill());
        }
        else if (buttonOn[(int)enumButtonOn.Skill2])
        {
            buttonOn[(int)enumButtonOn.Skill1] = false;
            SkillManager.Instance.useSkill[skillSlot[1]] = true;
            yield return StartCoroutine(SkillManager.Instance.UseSkill());
        }
        else if (buttonOn[(int)enumButtonOn.Skill3])
        {
            buttonOn[(int)enumButtonOn.Skill1] = false;
            SkillManager.Instance.useSkill[skillSlot[2]] = true;
            yield return StartCoroutine(SkillManager.Instance.UseSkill());
        }

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        yield return StartCoroutine(EnemyAttack());

        yield return StartCoroutine(Battle());
    }

    // �A�C�e���g�p���̏���
    public IEnumerator Item()
    {
        if (!ItemManager.Instance.haveItem)
        {
            mainText.text = "�A�C�e���������Ă��Ȃ��I";

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
            yield return StartCoroutine(Battle());
        }
        else
        {
            windows[(int)enumWindows.ItemUseSelect].SetActive(true);
            EventSystem.current.SetSelectedGameObject(defaultButton[2]);
        }

        if (ItemManager.Instance.getItem[(int)ItemManager.enumGetItem.HPPotion])
        {
            mainText.text = "HP�|�[�V����:HP��30��";
        }
        else if (ItemManager.Instance.getItem[(int)ItemManager.enumGetItem.SPPotion])
        {
            mainText.text = "SP�|�[�V����:SP��30��";
        }
        else if (ItemManager.Instance.getItem[(int)ItemManager.enumGetItem.ATKPotion])
        {
            mainText.text = "�U���|�[�V����:���̍U���͂�2�{";
        }
        else if (ItemManager.Instance.getItem[(int)ItemManager.enumGetItem.HealHerb])
        {
            mainText.text = "������:HP��50��";
        }
        else if (ItemManager.Instance.getItem[(int)ItemManager.enumGetItem.DamageBomb])
        {
            mainText.text = "�{��:�G��30�̃_���[�W";
        }
        else if (ItemManager.Instance.getItem[(int)ItemManager.enumGetItem.ATKJewel])
        {
            mainText.text = "�U���W���G��:���̍U���͂�3�{";
        }

        while (!buttonOn[(int)enumButtonOn.ItemUse] && !buttonOn[(int)enumButtonOn.Back])
        {
            yield return null;
        }

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
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

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        yield return StartCoroutine(EnemyAttack());

        yield return StartCoroutine(Battle());


    }

    // �v���C���[�s�k���̏���
    public IEnumerator PlayerLose()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Lose);
        SoundManager.Instance.StopBGM();
        mainText.text = $"{playerName}�͕�����";
        // ���݂̃t���A�̈�O�̃t���A�܂ł��N���A�t���A���Ƃ��ĕۑ�
        if (PlayerPrefs.GetInt("Difficulty") == (int)TitleManager.enumDifficultyID.Easy)
        {
            if (PlayerPrefs.GetInt("EasyClearFloor") < GameManager.Instance.floorNumber-1)
            {
                PlayerPrefs.SetInt("EasyClearFloor", (int)GameManager.Instance.floorNumber-1);
            }
        }
        else if (PlayerPrefs.GetInt("Difficulty") == (int)TitleManager.enumDifficultyID.Normal)
        {
            if (PlayerPrefs.GetInt("NormalClearFloor") < GameManager.Instance.floorNumber-1)
            {
                PlayerPrefs.SetInt("NormalClearFloor", (int)GameManager.Instance.floorNumber-1);
            }
        }

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        Initiate.Fade("GameOverScene", Color.black, 1.0f);
        yield return new WaitForSeconds(5.0f);
    }

    // �v���C���[�������̏���
    public IEnumerator PlayerWin()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Win);
        SoundManager.Instance.StopBGM();
        
        if (powerUp)
        {
            powerUp = false;
            playerATK = baseAttack;
        }

        displayEnemyImage.sprite = noneEnemy;
        mainText.text = $"{playerName}�̏����I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        mainText.text = $"{enemyEXP}�̌o���l���l���I";
        playerEXP += enemyEXP;

        yield return StartCoroutine(NextProcess(1.0f));

        // �o���l�����ɒB�����烌�x���A�b�v
        if (playerEXP >= playerNextLvEXP)
        {
            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.LvUp);
            mainText.text = "���x�����オ�����I\n�X�e�[�^�X���㏸�I";
            if (PlayerPrefs.GetInt("Character") == (int)TitleManager.enumCharacterID.Warrior)
            {
                playerLv += 1;
                playerMaxHP += 10;
                playerMaxSP += 5;
                playerATK += 2;
                playerEXP = 0;
                playerNextLvEXP *= 2;
            }
            else if (PlayerPrefs.GetInt("Character") == (int)TitleManager.enumCharacterID.Magician)
            {
                playerLv += 1;
                playerMaxHP += 5;
                playerMaxSP += 10;
                playerATK += 1;
                playerEXP = 0;
                playerNextLvEXP *= 2;
            }

            if (playerLv >= 2)
            {
                SkillManager.Instance.useSkillButton[(int)SkillManager.enumSkillButton.Skill1].SetActive(true);
            }

            if (playerLv >= 4)
            {
                SkillManager.Instance.useSkillButton[(int)SkillManager.enumSkillButton.Skill2].SetActive(true);
            }

            if (playerLv >= 6)
            {
                SkillManager.Instance.useSkillButton[(int)SkillManager.enumSkillButton.Skill3].SetActive(true);
            }

            yield return StartCoroutine(NextProcess(1.0f));

        }

        // �{�X�o�g���������ꍇ�̓N���A�V�[����
        if (bossBattle)
        {
            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Win);
            mainText.text = "�_���W�����𐧔e�����I";

            yield return StartCoroutine(NextProcess(1.0f));

            if (PlayerPrefs.GetInt("Difficulty") == (int)TitleManager.enumDifficultyID.Easy)
            {
                if (PlayerPrefs.GetInt("EasyClearFloor") < GameManager.Instance.floorNumber)
                {
                    PlayerPrefs.SetInt("EasyClearFloor", (int)GameManager.Instance.floorNumber);
                }
            }
            else if (PlayerPrefs.GetInt("Difficulty") == (int)TitleManager.enumDifficultyID.Normal)
            {
                if (PlayerPrefs.GetInt("NormalClearFloor") < GameManager.Instance.floorNumber)
                {
                    PlayerPrefs.SetInt("NormalClearFloor", (int)GameManager.Instance.floorNumber);
                }
            }
            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
            Initiate.Fade("GameClearScene", Color.black, 1.0f);
            yield return new WaitForSeconds(5.0f);
        }

        windows[(int)enumWindows.EnemyStatus].SetActive(false);
        windows[(int)enumWindows.ItemWindow].SetActive(true);
        yield return StartCoroutine(GameManager.Instance.NextFloor());
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

    // �U���R�}���h�̃{�^��
    public void AttackComand()
    {
        buttonOn[(int)enumButtonOn.Attack] = true;
    }

    // �X�L���R�}���h�̃{�^��
    public void SkillComand()
    {
        buttonOn[(int)enumButtonOn.Skill] = true;
    }

    // �A�C�e���R�}���h�̃{�^��
    public void ItemComand()
    {
        buttonOn[(int)enumButtonOn.Item] = true;
    }

    // �X�L���P�̃{�^��
    public void Skill1()
    {
        skillUse = true;
        buttonOn[(int)enumButtonOn.Skill1] = true;
    }

    // �X�L���Q�̃{�^��
    public void Skill2()
    {
        skillUse = true;
        buttonOn[(int)enumButtonOn.Skill2] = true;
    }

    // �X�L���R�̃{�^��
    public void Skill3()
    {
        skillUse = true;
        buttonOn[(int)enumButtonOn.Skill3] = true;
    }

    // �A�C�e���g�p�m�F���̎g�p�{�^��
    public void ItemUse()
    {
        buttonOn[(int)enumButtonOn.ItemUse] = true;
    }

    // �A�C�e���g�p�m�F���̖߂�{�^��
    public void ItemBack()
    {
        buttonOn[(int)enumButtonOn.Back] = true;
    }

    // �X�L���I���E�B���h�E�����{�^��
    public void SkillBack()
    {
        skillBack = true;
    }
}

