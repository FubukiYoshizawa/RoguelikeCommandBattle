using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleManager: MonoBehaviour
{
    public EnemyStatusManager enemyStatusManager;

    public string pName;
    public int pLv;
    public int pHP;
    public int pSP;
    public int pATK;

    private string eNAME;
    private int eLv;
    private int eHP;
    private int eATK;

    public Image displayMonster;
    public Sprite[] Monster;
    public TextMeshProUGUI[] pStatus;
    public TextMeshProUGUI[] eStatus;
    private Sprite[] sprites;
    private int randomNumber;

    public TextMeshProUGUI battleText;

    void Start()
    {
        // スプライトを配列に格納
        sprites = new Sprite[] { Monster[0], Monster[1], Monster[2] };

        randomNumber = Random.Range(0, sprites.Length);
        Sprite selectedSprite = sprites[randomNumber];
        displayMonster.sprite = selectedSprite;

        eNAME = enemyStatusManager.DataList[randomNumber].eNAME;
        eLv = enemyStatusManager.DataList[randomNumber].eLv;
        eHP = enemyStatusManager.DataList[randomNumber].eHP;
        eATK = enemyStatusManager.DataList[randomNumber].eATK;

        pStatus[0].text = pName;
        eStatus[0].text = eNAME;

        battleText.text = "Battle Start";
        StartCoroutine(BattleStart());
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
        Debug.Log("BattleStart");
        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (pLv > eLv)
        {
            yield return StartCoroutine(PlayerComand());

            yield return StartCoroutine(EnemyComand());
        }
        else if (pLv < eLv)
        {
            yield return StartCoroutine(EnemyComand());

            yield return StartCoroutine(PlayerComand());

        }
        else
        {
            int battlerandom;
            battlerandom = Random.Range(0, 2);
            if (battlerandom == 0)
            {
                yield return StartCoroutine(PlayerComand());

                yield return StartCoroutine(EnemyComand());
            }
            else
            {
                yield return StartCoroutine(EnemyComand());

                yield return StartCoroutine(PlayerComand());
            }
        }

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(BattleStart());

    }

    public IEnumerator PlayerComand()
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

        if (eHP == 0)
        {
            yield return StartCoroutine(PlayerWin());
        }

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

    public IEnumerator EnemyComand()
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

        if (pHP == 0)
        {
            yield return StartCoroutine(PlayerLose());
        }

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
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
        battleText.text = $"{pName} Win";

        yield return new WaitForSeconds(1.0f);

        StopAllCoroutines();
    }

}

