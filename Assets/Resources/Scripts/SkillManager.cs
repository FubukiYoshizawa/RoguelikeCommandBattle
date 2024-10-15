using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SkillManager : Singleton<SkillManager>
{
    public SkillValueManager skillValueManager; // �X�L���̊e�l�Ǘ��p�̃X�N���v�g

    public TextMeshProUGUI mainText; // �e�L�X�g�\��
    public GameObject[] useSkillButton; // �X�L���g�p���̃{�^��
    public enum enumSkillButton
    {
        Skill1, // �X�L���P�̃{�^��
        Skill2, // �X�L���Q�̃{�^��
        Skill3, // �X�L���R�̃{�^��
        Num // �X�L���{�^���̐�
    }
    public TextMeshProUGUI[] useSkillButtonText; // �\������X�L����
    public enum enumUseSkillButtontext
    {
        Skill1, // �X�L���P�̖��O
        Skill2, // �X�L���Q�̖��O
        Skill3, // �X�L���R�̖��O
        Num // �X�L�����\����
    }
    public bool skillDescriptionDisplay; // �X�L��������\�����邩�ǂ���
    public bool[] useSkill; // �ǂ̃X�L�����g�p���邩
    public enum enumUseSkill
    {
        PowerAttack, // �p���[�A�^�b�N
        PowerUp, // �p���[�A�b�v
        Meditation, // �ґz
        FireBall, // �t�@�C�A�{�[��
        IceLance, // �A�C�X�����X
        HealMagic, // �q�[��
        Num // �ǂ̃X�L�����g�����̐�
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
                    mainText.text = "�p���[�A�^�b�N\n�����͂����߂đ����\n�U���͂�1.5�{�̃_���[�W";
                }
                else if (selectedObject != null && selectedObject == useSkillButton[(int)enumSkillButton.Skill2].gameObject)
                {
                    mainText.text = "�p���[�`���[�W\n�͂����߂Ď��̍U�����Q�{";
                }
                else if (selectedObject != null && selectedObject == useSkillButton[(int)enumSkillButton.Skill3].gameObject)
                {
                    mainText.text = "�ґz\n�S��Â߂��ґz����\nHP��50��";
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
                    mainText.text = "�t�@�C�A�{�[��\n���̋��𑊎�ɕ���\n15�̌Œ�_���[�W";
                }
                else if (selectedObject != null && selectedObject == useSkillButton[(int)enumSkillButton.Skill2].gameObject)
                {
                    mainText.text = "�A�C�X�����X\n�X�̑��𑊎�ɕ���\n30�̌Œ�_���[�W";
                }
                else if (selectedObject != null && selectedObject == useSkillButton[(int)enumSkillButton.Skill3].gameObject)
                {
                    mainText.text = "�q�[��\n�����̎�����������\nHP��30��";
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
        mainText.text = "SP������Ȃ��I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(BattleManager.Instance.Battle());
    }

    public IEnumerator PowerAttack()
    {
        mainText.text = "�p���[�A�A�^�b�N���g�����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{BattleManager.Instance.playerATK*skillValueManager.DataList[0].skillValue}�̃_���[�W�I";

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
        mainText.text = "�p���[�`���[�W���g�����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "�U���͂�2�{�ɂȂ����I";

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
        mainText.text = "�ґz���g�����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"HP��{skillValueManager.DataList[2].skillValue}�񕜂����I";

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
        mainText.text = "�t�@�C�A�{�[�����������I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValueManager.DataList[3].skillValue}�̃_���[�W�I";

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
        mainText.text = "�A�C�X�����X���������I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValueManager.DataList[4].skillValue}�̃_���[�W�I";

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
        mainText.text = "�q�[�����������I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"HP��{skillValueManager.DataList[5].skillValue}�񕜂����I";

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
