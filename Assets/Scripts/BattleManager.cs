using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleManager: Singleton<BattleManager>
{
    public EnemyStatusManager esm;

    public string pName;
    public int pLv;
    public int pHP;
    public int pSP;
    public int pATK;

    private string eNAME;
    private int eLv;
    private int eHP;
    private int eATK;

    public Image displayEnemy;
    public Sprite[] Enemy;
    public TextMeshProUGUI[] pStatus;
    public TextMeshProUGUI[] eStatus;
    private Sprite[] sprites;
    private int randomNumber;

    public TextMeshProUGUI battleText;

    public GameObject[] windows;

    public bool[] buttonOn;
    public bool skillUse;
    public bool itemUse;
    public bool back;

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

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        sprites = new Sprite[] { Enemy[0], Enemy[1], Enemy[2] };
        randomNumber = Random.Range(0, sprites.Length);
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
        battleText.text = $"{eNAME} Attack";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{eATK} Damage!";

        yield return new WaitForSeconds(0.5f);

        pHP = pHP - eATK;
        if (pHP < 0 )
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
        else
        {
            battleText.text = "Item : Recovers 30 HP";
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
        displayEnemy.sprite = null;
        battleText.text = $"{pName} Win";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
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

