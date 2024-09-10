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
        if (BattleManager.Instance.eNAME == "Slime")
        {
            yield return StartCoroutine(SlimeAction());
        }
        else if (BattleManager.Instance.eNAME == "IkeBat")
        {
            yield return StartCoroutine(IkeBat());
        }
        else if (BattleManager.Instance.eNAME == "HatGhost")
        {
            yield return StartCoroutine(HatGhost());
        }
        else if (BattleManager.Instance.eNAME == "LightDragonBaby")
        {
            yield return StartCoroutine(BabyAction());
        }
        else if (BattleManager.Instance.eNAME == "LightDragon")
        {
            yield return StartCoroutine(LightDragonAction());
        }

    }

    public IEnumerator SlimeAction()
    {
        battleText.text = $"{BattleManager.Instance.eNAME} Slime Shoot!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int damage = (int)(BattleManager.Instance.eATK * 1.5);

        battleText.text = $"{damage} Damage!";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.pHP -= damage;
        if (BattleManager.Instance.pHP < 0)
        {
            BattleManager.Instance.pHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.pHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator IkeBat()
    {
        battleText.text = $"{BattleManager.Instance.eNAME} Flying attack!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int damage = (int)(BattleManager.Instance.eATK * 1.5);

        battleText.text = $"{damage} Damage!";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.pHP -= damage;
        if (BattleManager.Instance.pHP < 0)
        {
            BattleManager.Instance.pHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.pHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator HatGhost()
    {
        battleText.text = $"{BattleManager.Instance.eNAME} Fire Ball!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{BattleManager.Instance.eATK * 4} Damage!";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.pHP = BattleManager.Instance.pHP - (BattleManager.Instance.eATK * 2);
        if (BattleManager.Instance.pHP < 0)
        {
            BattleManager.Instance.pHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.pHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator BabyAction()
    {
        battleText.text = $"{BattleManager.Instance.eNAME} LightDragonBaby breath!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int damage = (int)(BattleManager.Instance.eATK * 1.5);

        battleText.text = $"{damage} Damage!";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.pHP -= damage;
        if (BattleManager.Instance.pHP < 0)
        {
            BattleManager.Instance.pHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.pHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

    public IEnumerator LightDragonAction()
    {
        battleText.text = $"{BattleManager.Instance.eNAME} LightDragon breath!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        battleText.text = $"{BattleManager.Instance.eATK * 2} Damage!";

        yield return new WaitForSeconds(0.5f);

        BattleManager.Instance.pHP = BattleManager.Instance.pHP - (BattleManager.Instance.eATK * 2);
        if (BattleManager.Instance.pHP < 0)
        {
            BattleManager.Instance.pHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.pHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerLose());
        }

    }

}
