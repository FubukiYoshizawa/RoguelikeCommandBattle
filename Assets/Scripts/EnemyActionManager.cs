using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyActionManager : Singleton<EnemyActionManager>
{
    public EnemyStatusManager enemyStatusManager; // スキルの各値管理用のスクリプト

    public TextMeshProUGUI battleText; // テキスト表示

    public IEnumerator EnemyAction()
    {
        if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[0].eNAME)
        {
            yield return StartCoroutine(Slime());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[1].eNAME)
        {
            yield return StartCoroutine(IkeBat());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[2].eNAME)
        {
            yield return StartCoroutine(HatGhost());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[3].eNAME)
        {
            yield return StartCoroutine(GodADeath());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[4].eNAME)
        {
            yield return StartCoroutine(TornadoMan());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[5].eNAME)
        {
            yield return StartCoroutine(ThunderOni());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[6].eNAME)
        {
            yield return StartCoroutine(InfernoButterfly());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[7].eNAME)
        {
            yield return StartCoroutine(DarkDragon());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[8].eNAME)
        {
            yield return StartCoroutine(IceDragon());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[9].eNAME)
        {
            yield return StartCoroutine(BabyDragon());
        }
        else if (BattleManager.Instance.enemyName == enemyStatusManager.DataList[10].eNAME)
        {
            yield return StartCoroutine(LightDragon());
        }

    }

    public IEnumerator Slime()
    {
        battleText.text = $"{BattleManager.Instance.enemyName}は\nスライムショットを放った！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyStatusManager.DataList[0].skillValue1}のダメージ！";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= enemyStatusManager.DataList[0].skillValue1;
        if (BattleManager.Instance.playerHP < 0)
        {
            BattleManager.Instance.playerHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator IkeBat()
    {
        battleText.text = $"{BattleManager.Instance.enemyName}は\nフライングアタックを放った！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyStatusManager.DataList[1].skillValue1}のダメージ！";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= enemyStatusManager.DataList[1].skillValue1;
        if (BattleManager.Instance.playerHP < 0)
        {
            BattleManager.Instance.playerHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator HatGhost()
    {
        battleText.text = $"{BattleManager.Instance.enemyName}は\nファイアボールを放った！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyStatusManager.DataList[2].skillValue1}のダメージ！";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= enemyStatusManager.DataList[2].skillValue1;
        if (BattleManager.Instance.playerHP < 0)
        {
            BattleManager.Instance.playerHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator GodADeath()
    {
        battleText.text = $"{BattleManager.Instance.enemyName}は\n鎌を振りかぶった！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyStatusManager.DataList[3].skillValue1}のダメージ！";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= enemyStatusManager.DataList[3].skillValue1;
        if (BattleManager.Instance.playerHP < 0)
        {
            BattleManager.Instance.playerHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator TornadoMan()
    {
        battleText.text = $"{BattleManager.Instance.enemyName}は\n竜巻を巻き起こした！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyStatusManager.DataList[4].skillValue1}のダメージ！";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= enemyStatusManager.DataList[4].skillValue1;
        if (BattleManager.Instance.playerHP < 0)
        {
            BattleManager.Instance.playerHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator ThunderOni()
    {
        battleText.text = $"{BattleManager.Instance.enemyName}は\n雷雲を呼んだ！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{enemyStatusManager.DataList[5].skillValue1}のダメージ！";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= enemyStatusManager.DataList[5].skillValue1;
        if (BattleManager.Instance.playerHP < 0)
        {
            BattleManager.Instance.playerHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator InfernoButterfly()
    {
        int randomValue = Random.Range(0, 5);
        if (randomValue <= 3)
        {
            battleText.text = $"{BattleManager.Instance.enemyName}は\nファイアボールを唱えた！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[6].skillValue1}のダメージ！";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[6].skillValue1;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }
        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName}は\n火の粉を集めた！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{BattleManager.Instance.enemyName}は\nHPを{enemyStatusManager.DataList[7].skillValue1}回復した！";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.enemyHP += enemyStatusManager.DataList[7].skillValue1;
            if (BattleManager.Instance.enemyHP > BattleManager.Instance.enemyMaxHP)
            {
                BattleManager.Instance.enemyHP = BattleManager.Instance.enemyMaxHP;
            }

        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator DarkDragon()
    {
        int randomValue = Random.Range(0, 5);
        if (randomValue <= 2)
        {
            battleText.text = $"{BattleManager.Instance.enemyName}は\nダークブレスを放った！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[7].skillValue1}のダメージ";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[7].skillValue1;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }
        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName}は\nダークオーラを放った！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[7].skillValue2}のダメージ！";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[7].skillValue2;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }

        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator IceDragon()
    {
        int randomValue = Random.Range(0, 5);
        if (randomValue <= 2)
        {
            battleText.text = $"{BattleManager.Instance.enemyName}は\nアイスブレスを放った！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[8].skillValue1}のダメージ！";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[8].skillValue1;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }
        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName}は\nアイスレインを放った！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[8].skillValue2}のダメージ！";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[8].skillValue2;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }

        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator BabyDragon()
    {
        int randomValue = Random.Range(0, 3);
        if (randomValue <= 1)
        {
            battleText.text = $"{BattleManager.Instance.enemyName}は\nプチブレスを放った！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[9].skillValue1}のダメージ！";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[9].skillValue1;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }
        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName}は\n光を集めた！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{BattleManager.Instance.enemyName}は\nHPを{enemyStatusManager.DataList[9].skillValue3}回復した！";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.enemyHP += enemyStatusManager.DataList[9].skillValue3;

        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator LightDragon()
    {
        int randomValue = Random.Range(0, 8);
        if (randomValue <= 4)
        {
            battleText.text = $"{BattleManager.Instance.enemyName}は\nライトニングブレスを放った！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[10].skillValue1}のダメージ！";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[10].skillValue1;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }
        }
        else if (randomValue <= 6)
        {
            battleText.text = $"{BattleManager.Instance.enemyName}は\nライトニングショットを放った！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{enemyStatusManager.DataList[10].skillValue2}のダメージ！";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= enemyStatusManager.DataList[10].skillValue2;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }

        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName}は\n光を集めた！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            battleText.text = $"{BattleManager.Instance.enemyName}は\nHPを{enemyStatusManager.DataList[10].skillValue3}回復した！";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.enemyHP += enemyStatusManager.DataList[10].skillValue3;

        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

}
