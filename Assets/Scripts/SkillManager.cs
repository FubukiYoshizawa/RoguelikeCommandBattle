using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillManager : Singleton<SkillManager>
{
    public TextMeshProUGUI mainText;
    public bool[] useSkill;

    private void Start()
    {
        
    }

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

        mainText.text = "30 damage to the enemy.";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
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
    }

    public IEnumerator Meditation()
    {
        mainText.text = "Using Meditation";

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
    }

    public IEnumerator IiceLance()
    {
        mainText.text = "Chanted IiceLance";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
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
    }
}
