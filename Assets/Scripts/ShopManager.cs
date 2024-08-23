using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : Singleton<ShopManager>
{
    public TextMeshProUGUI mainText;
    public GameObject selectWindow;
    public bool yes, no;

    public Image floorBack;
    public Sprite[] fBack;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public IEnumerator HPShop()
    {
        floorBack.sprite = fBack[0];

        mainText.text = "Welcome Shop";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "If You Pay Your Health\nYou Can Get Potion!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "Do You Need Health Potion?";

        yield return new WaitForSeconds(1.0f);

        selectWindow.SetActive(true);

        while (!yes && !no)
        {
            yield return null;
        }

        selectWindow.SetActive(false);

        if (yes)
        {
            yes = false;
            mainText.text = "Fine, You're A Good Customer.";
        }
        else
        {
            no = false;
            mainText.text = "Oh... See You";
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator SPShop()
    {
        floorBack.sprite = fBack[1];

        mainText.text = "Welcome Shop";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "If You Pay Your Health\nYou Can Get Potion!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "Do You Need SP Potion?";

        yield return new WaitForSeconds(1.0f);

        selectWindow.SetActive(true);

        while (!yes && !no)
        {
            yield return null;
        }

        selectWindow.SetActive(false);

        if (yes)
        {
            yes = false;
            mainText.text = "Fine, You're A Good Customer.";
        }
        else
        {
            no = false;
            mainText.text = "Oh... See You";
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator ATKShop()
    {
        floorBack.sprite = fBack[2];

        mainText.text = "Welcome Shop";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "If You Pay Your Health\nYou Can Get Potion!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "Do You Need ATK Potion?";

        yield return new WaitForSeconds(1.0f);

        selectWindow.SetActive(true);

        while (!yes && !no)
        {
            yield return null;
        }

        selectWindow.SetActive(false);

        if (yes)
        {
            yes = false;
            mainText.text = "Fine, You're A Good Customer.";
        }
        else
        {
            no = false;
            mainText.text = "Oh... See You";
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public void Yes()
    {
        yes = true;
    }

    public void No()
    {
        no = true;
    }

}
