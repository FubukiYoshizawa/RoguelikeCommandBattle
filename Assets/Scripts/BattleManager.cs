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
    public int pATP;

    public Image displayMonster;
    public Sprite[] Monster;
    public TextMeshProUGUI[] pStatus;
    public TextMeshProUGUI[] mStatus;
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

        battleText.text = "Batle Start";
        StartCoroutine(BattleStart());
    }

    void Update()
    {
        pStatus[0].text = pName;
        pStatus[1].text = pLv.ToString();
        pStatus[2].text = pHP.ToString();
        pStatus[3].text = pSP.ToString();
        pStatus[4].text = pATP.ToString();

        mStatus[0].text = enemyStatusManager.DataList[randomNumber].eNAME;
        mStatus[1].text = enemyStatusManager.DataList[randomNumber].eLv.ToString();
        mStatus[2].text = enemyStatusManager.DataList[randomNumber].eHP.ToString();
        mStatus[3].text = enemyStatusManager.DataList[randomNumber].eATK.ToString();

    }

    public IEnumerator BattleStart()
    {
        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (pLv > enemyStatusManager.DataList[randomNumber].eLv)
        {
            StartCoroutine(PlayerComand());

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            StartCoroutine(EnemyComand());
        }
        else if (pLv < enemyStatusManager.DataList[randomNumber].eLv)
        {
            StartCoroutine(EnemyComand());

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            StartCoroutine(PlayerComand());

        }
        else
        {
            int battlerandom;
            battlerandom = Random.Range(0, 2);
            if (battlerandom == 0)
            {
                StartCoroutine(PlayerComand());

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }

                StartCoroutine(EnemyComand());
            }
            else
            {
                StartCoroutine(EnemyComand());

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }

                StartCoroutine(PlayerComand());
            }
        }

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        StartCoroutine(BattleStart());

    }

    public IEnumerator PlayerComand()
    {
        battleText.text = $"{pName} Attack";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{pATP} Damage!";

        yield return new WaitForSeconds(0.5f);

        

        yield return new WaitForSeconds(1.0f);

    }

    public IEnumerator EnemyComand()
    {
        battleText.text = $"{enemyStatusManager.DataList[randomNumber].eNAME} Attack";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyStatusManager.DataList[randomNumber].eATK} Damage!";

        yield return new WaitForSeconds(0.5f);

        pHP = pHP - enemyStatusManager.DataList[randomNumber].eATK;
        if (pHP < 0 )
        {
            pHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        if (pHP == 0)
        {
            StartCoroutine(PlayerLose());
        }

    }

    public IEnumerator PlayerLose()
    {
        battleText.text = $"{pName} Lose";

        yield return new WaitForSeconds(1.0f);
    }

}

