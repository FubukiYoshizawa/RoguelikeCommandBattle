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

    public GameObject enemyStatusWindow;
    public GameObject itemWindow;
    public GameObject comand;

    private bool[] buttonOn;

    void Start()
    {
        pStatus[0].text = pName;
        buttonOn = new bool[3];
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

        enemyStatusWindow.SetActive(true);
        itemWindow.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(Battle());

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

    public void StrongStart()
    {

    }

    public void BossStart()
    {

    }

    public IEnumerator Battle()
    {
        battleText.text = "Command?";
        comand.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        while (!buttonOn[0] && !buttonOn[1] && !buttonOn[2])
        {
            yield return null;
        }
        comand.SetActive(false);

        if (buttonOn[0])
        {
            comand.SetActive(false);
            buttonOn[0] = false;
            StartCoroutine(Attack());
        }
        else if (buttonOn[1])
        {
            comand.SetActive(false);
            buttonOn[1] = false;
            StartCoroutine(Battle());
        }
        else if (buttonOn[2])
        {
            comand.SetActive(false);
            buttonOn[2] = false;
            StartCoroutine(Battle());
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

        enemyStatusWindow.SetActive(false);
        itemWindow.SetActive(true);
        yield return StartCoroutine(GameManager.Instance.NextFloor());
    }

}

