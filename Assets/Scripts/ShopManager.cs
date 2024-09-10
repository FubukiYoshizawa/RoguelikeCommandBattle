using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : Singleton<ShopManager>
{
    public TextMeshProUGUI mainText; // �e�L�X�g�\��
    public GameObject selectWindow; // �I���E�B���h�E
    public bool yes, no; // �I����

    public Image floorBack; // �t���A�w�i
    public Sprite[] fBack; // �w�i�摜
    /*
    0:HP�|�[�V����
    1:SP�|�[�V����
    2:�U���|�[�V����
    */

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

            if (BattleManager.Instance.pHP <= 10)
            {
                mainText.text = "You don't have anything to pay for!";

                yield return new WaitForSeconds(1.0f);

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }

            }
            else
            {
                mainText.text = "Fine, You're A Good Customer.";
            }
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
            if (BattleManager.Instance.pHP <= 10)
            {
                mainText.text = "You don't have anything to pay for!";

                yield return new WaitForSeconds(1.0f);

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }

            }
            else
            {
                mainText.text = "Fine, You're A Good Customer.";
            }
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
            if (BattleManager.Instance.pHP <= 10)
            {
                mainText.text = "You don't have anything to pay for!";

                yield return new WaitForSeconds(1.0f);

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }

            }
            else
            {
                mainText.text = "Fine, You're A Good Customer.";
            }
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
