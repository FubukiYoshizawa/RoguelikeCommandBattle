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
            yield return StartCoroutine(Slime());
        }
        else if (BattleManager.Instance.enemyName == "IkeBat")
        {
            yield return StartCoroutine(IkeBat());
        }
        else if (BattleManager.Instance.enemyName == "HatGhost")
        {
            yield return StartCoroutine(HatGhost());
        }
        else if (BattleManager.Instance.enemyName == "GodADeath")
        {
            yield return StartCoroutine(GodADeath());
        }
        else if (BattleManager.Instance.enemyName == "TornadoMan")
        {
            yield return StartCoroutine(TornadoMan());
        }
        else if (BattleManager.Instance.enemyName == "ThunderOni")
        {
            yield return StartCoroutine(ThunderOni());
        }
        else if (BattleManager.Instance.enemyName == "InfernoButterfly")
        {
            yield return StartCoroutine(InfernoButterfly());
        }
        else if (BattleManager.Instance.enemyName == "DarkDragon")
        {
            yield return StartCoroutine(DarkDragon());
        }
        else if (BattleManager.Instance.enemyName == "IceDragon")
        {
            yield return StartCoroutine(IceDragon());
        }
        else if (BattleManager.Instance.enemyName == "LightDragon")
        {
            yield return StartCoroutine(LightDragon());
        }

    }

    public IEnumerator Slime()
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

    public IEnumerator GodADeath()
    {
        battleText.text = $"{BattleManager.Instance.enemyName} swung his sickle!";

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

    public IEnumerator TornadoMan()
    {
        battleText.text = $"{BattleManager.Instance.enemyName} created a tremendous tornado!";

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

    public IEnumerator ThunderOni()
    {
        battleText.text = $"{BattleManager.Instance.enemyName} called down the thunder!";

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

    public IEnumerator InfernoButterfly()
    {
        int randomValue = Random.Range(0, 5);
        if (randomValue <= 3)
        {
            battleText.text = $"{BattleManager.Instance.enemyName} was a firebrand!";

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
        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName} collected firebombs!";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            int damage = (int)(BattleManager.Instance.enemyATK);

            battleText.text = $"{BattleManager.Instance.enemyName} recovered {damage} HP!";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.enemyHP += damage;

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
            battleText.text = $"{BattleManager.Instance.enemyName} breathed a dark breath!";

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
        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName} cast dark magic!";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            int damage = (int)(BattleManager.Instance.enemyATK * 2);

            battleText.text = $"{damage} Damage!";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= damage;
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
            battleText.text = $"{BattleManager.Instance.enemyName} breathed a Ice breath!";

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
        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName} cast Ice magic!";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            int damage = (int)(BattleManager.Instance.enemyATK * 2);

            battleText.text = $"{damage} Damage!";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= damage;
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

    public IEnumerator LightDragon()
    {
        int randomValue = Random.Range(0, 8);
        if (randomValue <= 4)
        {
            battleText.text = $"{BattleManager.Instance.enemyName} breathed a Light breath!";

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
        }
        else if (randomValue <= 6)
        {
            battleText.text = $"{BattleManager.Instance.enemyName} cast Light magic!";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            int damage = (int)(BattleManager.Instance.enemyATK * 2);

            battleText.text = $"{damage} Damage!";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.playerHP -= damage;
            if (BattleManager.Instance.playerHP < 0)
            {
                BattleManager.Instance.playerHP = 0;
            }

        }
        else
        {
            battleText.text = $"{BattleManager.Instance.enemyName} collected firebombs!";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            int damage = (int)(BattleManager.Instance.enemyATK);

            battleText.text = $"{BattleManager.Instance.enemyName} recovered {damage} HP!";

            yield return new WaitForSeconds(0.5f);

            BattleManager.Instance.enemyHP += damage;

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
