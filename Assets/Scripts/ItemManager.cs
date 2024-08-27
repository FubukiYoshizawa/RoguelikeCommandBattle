using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public TextMeshProUGUI mainText;
    public bool[] getItem;

    private void Start()
    {
        getItem[0] = true;
    }

    public IEnumerator HaveItem()
    {
        if (getItem[0])
        {
            getItem[0] = false;
            yield return StartCoroutine(HPPotion());
        }
        else if (getItem[1])
        {
            getItem[1] = false;
            yield return StartCoroutine(SPPotion());
        }
        else if (getItem[2])
        {
            getItem[2] = false;
            yield return StartCoroutine(ATKPotion());
        }
        else if (getItem[3])
        {
            getItem[3] = false;
            yield return StartCoroutine(HealHerb());
        }
        else if (getItem[4])
        {
            getItem[4] = false;
            yield return StartCoroutine(DamageBomb());
        }
        else if (getItem[5])
        {
            getItem[5] = false;
            yield return StartCoroutine(ATKJewel());
        }

    }

    public IEnumerator HPPotion()
    {
        mainText.text = "Using HP potion";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "HP recovered 30 times.";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator SPPotion()
    {
        mainText.text = "Using SP potion";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator ATKPotion()
    {
        mainText.text = "Using ATK potion";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator HealHerb()
    {
        mainText.text = "Using medicinal herbs.";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator DamageBomb()
    {
        mainText.text = "Using a bomb.";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator ATKJewel()
    {
        mainText.text = "Using ATK Jewel";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

}
