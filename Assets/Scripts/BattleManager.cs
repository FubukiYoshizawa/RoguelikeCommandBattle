using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleManager: Singleton<BattleManager>
{
    public EnemyStatusManager esm; // �G�X�e�[�^�X�p�X�N���v�g

    public string pName;  // �v���C���[��
    public int pLv; // �v���C���[���x��
    public int pHP; // �v���C���[HP
    public int pMaxHP; // �v���C���[�ő�HP
    public int pSP; // �v���C���[SP
    public int pMaxSP; // �v���C���[�ő�SP
    public int pATK; // �v���C���[�U����
    public int pEXP; // �v���C���[�o���l
    public int nEXP; // ���x���A�b�v�܂ł̌o���l

    public string eNAME; // �G��
    public int eLv; // �G���x��
    public int eHP; // �GHP
    public int eATK; // �G�U����
    public int eEXP; // �G�o���l

    public bool powerUp2 = false; // �U����2�{��Ԃ�\��
    public bool powerUp3 = false; // �U����3�{��Ԃ�\��

    public Image floorBack; // �t���A�̔w�i�𓖂Ă͂߂�Image�I�u�W�F�N�g
    public Sprite fBack; // �t���A�摜
    public Image displayEnemy; // �G�𓖂Ă͂߂�Image�I�u�W�F�N�g
    public Sprite[] Enemy; // �G�̉摜
    private Sprite[] sprites; // ���ݐ���Ă���G�̉摜
    public Sprite none; // �G�����Ȃ��Ƃ��̉摜
    public TextMeshProUGUI[] pStatus; // ��ʂɕ\������v���C���[�̃X�e�[�^�X
    /*
    0:�v���C���[��
    1:�v���C���[���x��
    2:�v���C���[HP
    3:�v���C���[SP
    4:�v���C���[�U����
    */
    public TextMeshProUGUI[] eStatus; // ��ʂɕ\������G�̃X�e�[�^�X
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

