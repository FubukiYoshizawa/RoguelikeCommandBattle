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
    /*
    0:�v���C���[��
    1:�v���C���[���x��
    2:�v���C���[HP
    3:�v���C���[SP
    4:�v���C���[�U����
    */
    public TextMeshProUGUI[] enemyStatusText; // ��ʂɕ\������G�̃X�e�[�^�X
    /*
    0:�G��
    1:�G���x��
    2:�GHP
    3:�G�U����
    */
    public TextMeshProUGUI battleText; // �o�g�����̃e�L�X�g

    public GameObject[] windows; // �e�E�B���h�E
    /*
    0:�G�X�e�[�^�X�E�B���h�E
    1:�A�C�e���E�B���h�E
    2:�R�}���h�E�B���h�E
    3:�X�L���E�B���h�E
    4:�o�g�����̑I���E�B���h�E
    */

    public GameObject[] defaultButton; // �I���E�B���h�E�ōŏ��ɑI�����Ă���{�^��
    /*
    0:�U���{�^��
    1:�X�L���P�{�^��
    2:�A�C�e���̎d�l�I���͂�
    */

    public bool[] buttonOn; // �o�g�����Ɏg�p����{�^���������Ă��邩�ǂ���
    /*
    0:�U��
    1:�X�L��
    2:�A�C�e��
    3:�X�L���P
    4:�X�L���Q
    5:�X�L���R
    6:�A�C�e���g�p
    7:�߂�
    */
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

        playerStatusText[0].text = playerName;
    }

    void Update()
    {
        playerStatusText[1].text = playerLv.ToString();
        playerStatusText[2].text = playerHP.ToString();
        playerStatusText[3].text = playerSP.ToString();
        playerStatusText[4].text = playerATK.ToString();

        enemyStatusText[1].text = enemyLv.ToString();
        enemyStatusText[2].text = enemyHP.ToString();
        enemyStatusText[3].text = enemyATK.ToString();

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
            enemyStatusText[0].text = enemyName;
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
            enemyStatusText[0].text = enemyName;
        }

        battleText.text = $"{enemyName} Appeared!";

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
        EventSystem.current.SetSelectedGameObject(defaultButton[0]);

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
            EventSystem.current.SetSelectedGameObject(defaultButton[1]);

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
        if (buttonOn[3])
        {
            buttonOn[3] = false;
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
        else if (buttonOn[4])
        {
            buttonOn[4] = false;
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
        else if (buttonOn[5])
        {
            buttonOn[5] = false;
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
            windows[4].SetActive(true);
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

