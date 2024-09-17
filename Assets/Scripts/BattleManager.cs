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
    public TextMeshProUGUI[] playerStatusText; // ��ʂɕ\������v���C���[�̃X�e�[�^�X
    public enum enumPlayerStatusText
    {
        Name, // �v���C���[��.
        Lv, // �v���C���[���x��.
        HP, // �v���C���[HP.
        SP, // �v���C���[SP.
        ATK, // �v���C���[�U����.
        Num // �X�e�[�^�X�\��UI�̌�.
    }
    public TextMeshProUGUI[] enemyStatusText; // ��ʂɕ\������G�̃X�e�[�^�X
    public enum enumEnemyStatusText
    {
        Name, // �G��
        Lv, // �G���x��
        HP, // �GHP
        ATK, // �G�U����
        Num // �G�̃X�e�[�^�X��
    }
    public TextMeshProUGUI battleText; // �o�g�����̃e�L�X�g

    public GameObject[] windows; // �e�E�B���h�E
    public enum enumWindows
    {
        EnemyStatus, // �G�̃X�e�[�^�X�E�B���h�E
        ItemWindow, // �A�C�e���E�B���h�E
        ComandWindow, // �R�}���h�E�B���h�E
        SkillWindow, // �X�L���E�B���h�E
        BattleSelectWindow, // �o�g�����I���E�B���h�E
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

        // �z�������
        playerStatusText = new TextMeshProUGUI[(int)enumPlayerStatusText.Num];
        enemyStatusText = new TextMeshProUGUI[(int)enumEnemyStatusText.Num];
        windows = new GameObject[(int)enumWindows.Num];
        defaultButton = new GameObject[(int)enumDefaultButton.Num];
        buttonOn = new bool[(int)enumButtonOn.Num];
        playerStatusText[(int)enumPlayerStatusText.Name].text = playerName;
    }

    void Update()
    {
        playerStatusText[(int)enumPlayerStatusText.Lv].text = playerLv.ToString();
        playerStatusText[(int)enumPlayerStatusText.HP].text = playerHP.ToString();
        playerStatusText[(int)enumPlayerStatusText.SP].text = playerSP.ToString();
        playerStatusText[(int)enumPlayerStatusText.ATK].text = playerATK.ToString();

        enemyStatusText[(int)enumEnemyStatusText.Lv].text = enemyLv.ToString();
        enemyStatusText[(int)enumEnemyStatusText.HP].text = enemyHP.ToString();
        enemyStatusText[(int)enumEnemyStatusText.ATK].text = enemyATK.ToString();

    }

    public IEnumerator BattleStart()
    {
        battleText.text = "Battle Floor!";
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
            enemyATK = enemyStatusManager.DataList[randomNumber].eATK;
            enemyEXP = enemyStatusManager.DataList[randomNumber].eEXP;
            enemyStatusText[(int)enumEnemyStatusText.Name].text = enemyName;
        }

        battleText.text = $"{enemyName} Appeared!";

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
        battleText.text = $"{playerName} Attack";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{playerATK} Damage!";

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

            battleText.text = $"{enemyName} Attack";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyATK} Damage!";

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
            battleText.text = "I don't have the item.";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            yield return StartCoroutine(Battle());
        }
        else
        {
            windows[(int)enumWindows.BattleSelectWindow].SetActive(true);
            EventSystem.current.SetSelectedGameObject(defaultButton[2]);
        }

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

        while (!buttonOn[(int)enumButtonOn.ItemUse] && !buttonOn[(int)enumButtonOn.Back])
        {
            yield return null;
        }

        if (buttonOn[(int)enumButtonOn.ItemUse])
        {
            buttonOn[(int)enumButtonOn.ItemUse] = false;
            windows[(int)enumWindows.BattleSelectWindow].SetActive(false);
            yield return StartCoroutine(ItemManager.Instance.HaveItem());
        }
        else if (buttonOn[(int)enumButtonOn.Back])
        {
            buttonOn[(int)enumButtonOn.Back] = false;
            windows[(int)enumWindows.BattleSelectWindow].SetActive(false);
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
        battleText.text = $"{playerName} Lose";

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
        battleText.text = $"{playerName} Win";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyEXP} Experience gained.";
        playerEXP += enemyEXP;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (playerEXP >= playerNextLvEXP)
        {
            battleText.text = "Levels raised!\nYour Status Up.";
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

