using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyActionManager : Singleton<EnemyActionManager>
{
    public TextMeshProUGUI battleText; // テキスト表示

    public IEnumerator EnemyAction()
    {
        if (BattleManager.Instance.enemyName == "Slime")
        {
            yield return StartCoroutine(SlimeAction());
        }
        else if (BattleManager.Instance.enemyName == "IkeBat")
        {
            yield return StartCoroutine(IkeBat());
        }
        else if (BattleManager.Instance.enemyName == "HatGhost")
        {
            yield return StartCoroutine(HatGhost());
        }
        else if (BattleManager.Instance.enemyName == "LightDragonBaby")
        {
            yield return StartCoroutine(BabyAction());
        }
        else if (BattleManager.Instance.enemyName == "LightDragon")
        {
            yield return StartCoroutine(LightDragonAction());
        }

    }

    public IEnumerator SlimeAction()
    {
        battleText.text = $"{BattleManager.Instance.enemyName} Slime Shoot!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int damage = (int)(BattleManager.Instance.enemyATK * 1.5);

        battleText.text = $"{damage} Damage!";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= damage;
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
        battleText.text = $"{BattleManager.Instance.enemyName} Flying attack!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int damage = (int)(BattleManager.Instance.enemyATK * 1.5);

        battleText.text = $"{damage} Damage!";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= damage;
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
        battleText.text = $"{BattleManager.Instance.enemyName} Fire Ball!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{BattleManager.Instance.enemyATK * 4} Damage!";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP = BattleManager.Instance.playerHP - (BattleManager.Instance.enemyATK * 2);
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

    public IEnumerator BabyAction()
    {
        battleText.text = $"{BattleManager.Instance.enemyName} LightDragonBaby breath!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int damage = (int)(BattleManager.Instance.enemyATK * 1.5);

        battleText.text = $"{damage} Damage!";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP -= damage;
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

    public IEnumerator LightDragonAction()
    {
        battleText.text = $"{BattleManager.Instance.enemyName} LightDragon breath!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{BattleManager.Instance.enemyATK * 2} Damage!";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.playerHP = BattleManager.Instance.playerHP - (BattleManager.Instance.enemyATK * 2);
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

}
