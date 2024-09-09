using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillManager : Singleton<SkillManager>
{
    public TextMeshProUGUI mainText;
    public bool[] useSkill;
    public int[] skillValue;

    public IEnumerator UseSkill()
    {
        if (useSkill[0])
        {
            useSkill[0] = false;
            yield return StartCoroutine(PowerAttack());
        }
        else if (useSkill[1])
        {
            useSkill[1] = false;
            yield return StartCoroutine(PowerUp());
        }
        else if (useSkill[2])
        {
            useSkill[2] = false;
            yield return StartCoroutine(Meditation());
        }
        else if (useSkill[3])
        {
            useSkill[3] = false;
            yield return StartCoroutine(FireBall());
        }
        else if (useSkill[4])
        {
            useSkill[4] = false;
            yield return StartCoroutine(IiceLance());
        }
        else if (useSkill[5])
        {
            useSkill[5] = false;
            yield return StartCoroutine(HealMagic());
        }

    }

    public IEnumerator PowerAttack()
    {
        mainText.text = "Using PowerAttack";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValue[0]} damage to the enemy.";

        BattleManager.Instance.eHP -= skillValue[0];
        if (BattleManager.Instance.eHP < 0)
        {
            BattleManager.Instance.eHP = 0;
        }

        if (BattleManager.Instance.powerUp2)
        {
            BattleManager.Instance.powerUp2 = false;
            BattleManager.Instance.pATK /= 2;
        }
        else if (BattleManager.Instance.powerUp3)
        {
            BattleManager.Instance.powerUp3 = false;
            BattleManager.Instance.pATK /= 3;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.eHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerWin());
        }

    }

    public IEnumerator PowerUp()
    {
        mainText.text = "Using PowerUp";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "Double the power of the next attack";
        BattleManager.Instance.powerUp2 = true;
        BattleManager.Instance.pATK *= 2;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator Meditation()
    {
        mainText.text = "Using Meditation";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValue[1]} HP recovered";

        BattleManager.Instance.pHP += skillValue[1];
        if (BattleManager.Instance.pHP > BattleManager.Instance.pMaxHP)
        {
            BattleManager.Instance.pHP = BattleManager.Instance.pMaxHP;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

    public IEnumerator FireBall()
    {
        mainText.text = "Chanted FireBall";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValue[2]} damage to the enemy.";

        BattleManager.Instance.eHP -= skillValue[2];
        if (BattleManager.Instance.eHP < 0)
        {
            BattleManager.Instance.eHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.eHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerWin());
        }
    }

    public IEnumerator IiceLance()
    {
        mainText.text = "Chanted IiceLance";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValue[3]} damage to the enemy.";

        BattleManager.Instance.eHP -= skillValue[3];
        if (BattleManager.Instance.eHP < 0)
        {
            BattleManager.Instance.eHP = 0;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.eHP == 0)
        {
            yield return StartCoroutine(BattleManager.Instance.PlayerWin());
        }
    }

    public IEnumerator HealMagic()
    {
        mainText.text = "Chanted HealMagic";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = $"{skillValue[1]} HP recovered";

        BattleManager.Instance.pHP += skillValue[1];
        if (BattleManager.Instance.pHP > BattleManager.Instance.pMaxHP)
        {
            BattleManager.Instance.pHP = BattleManager.Instance.pMaxHP;
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }
}
