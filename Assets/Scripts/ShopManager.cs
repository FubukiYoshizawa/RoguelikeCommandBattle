using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : Singleton<ShopManager>
{
    public TextMeshProUGUI mainText; // テキスト表示
    public GameObject selectWindow; // 選択ウィンドウ
    public bool yes, no; // 選択肢

    public Image floorImage; // フロア背景
    public Sprite[] floorSprite; // 背景画像
    /*
    0:HPポーション
    1:SPポーション
    2:攻撃ポーション
    */

    public IEnumerator HPShop()
    {
        floorImage.sprite = floorSprite[0];

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

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP <= 10)
        {
            mainText.text = "Oops, looks like you don't have anything to pay for.\nCome back in.";
        }
        else
        {
            mainText.text = "Do You Need HP Potion?";

            yield return new WaitForSeconds(0.5f);

            selectWindow.SetActive(true);

            while (!yes && !no)
            {
                yield return null;
            }

            selectWindow.SetActive(false);

            if (yes)
            {
                yes = false;

                if (ItemManager.Instance.haveItem)
                {
                    mainText.text = "I already have the item, do you want to buy it?";

                    yield return new WaitForSeconds(0.5f);

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
                        BattleManager.Instance.playerHP -= 10;
                        for (int i = 0; i < ItemManager.Instance.getItem.Length; i++)
                        {
                            ItemManager.Instance.getItem[i] = false;
                        }
                        ItemManager.Instance.getItem[0] = true;
                    }
                    else
                    {
                        no = false;
                        mainText.text = "I hope you don't regret it.";
                    }

                }
                else
                {
                    mainText.text = "Fine, You're A Good Customer.";
                    BattleManager.Instance.playerHP -= 10;
                    ItemManager.Instance.getItem[0] = true;
                }

                yield return new WaitForSeconds(1.0f);

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }
            }
            else
            {
                no = false;
                mainText.text = "I hope you don't regret it.";
            }
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator SPShop()
    {
        floorImage.sprite = floorSprite[1];

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

        if (BattleManager.Instance.playerHP <= 10)
        {
            mainText.text = "Oops, looks like you don't have anything to pay for.\nCome back in.";
        }
        else
        {
            mainText.text = "Do You Need SP Potion?";

            yield return new WaitForSeconds(0.5f);

            selectWindow.SetActive(true);

            while (!yes && !no)
            {
                yield return null;
            }

            selectWindow.SetActive(false);

            if (yes)
            {
                yes = false;

                if (ItemManager.Instance.haveItem)
                {
                    mainText.text = "I already have the item, do you want to buy it?";

                    yield return new WaitForSeconds(0.5f);

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
                        BattleManager.Instance.playerHP -= 10;
                        for (int i = 0; i < ItemManager.Instance.getItem.Length; i++)
                        {
                            ItemManager.Instance.getItem[i] = false;
                        }
                        ItemManager.Instance.getItem[1] = true;
                    }
                    else
                    {
                        no = false;
                        mainText.text = "I hope you don't regret it.";
                    }

                }
                else
                {
                    mainText.text = "Fine, You're A Good Customer.";
                    BattleManager.Instance.playerHP -= 10;
                    ItemManager.Instance.getItem[1] = true;
                }

                yield return new WaitForSeconds(1.0f);

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }
            }
            else
            {
                no = false;
                mainText.text = "I hope you don't regret it.";
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
        floorImage.sprite = floorSprite[2];

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

        if (BattleManager.Instance.playerHP <= 10)
        {
            mainText.text = "Oops, looks like you don't have anything to pay for.\nCome back in.";
        }
        else
        {
            mainText.text = "Do You Need ATK Potion?";

            yield return new WaitForSeconds(0.5f);

            selectWindow.SetActive(true);

            while (!yes && !no)
            {
                yield return null;
            }

            selectWindow.SetActive(false);

            if (yes)
            {
                yes = false;

                if (ItemManager.Instance.haveItem)
                {
                    mainText.text = "I already have the item, do you want to buy it?";

                    yield return new WaitForSeconds(0.5f);

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
                        BattleManager.Instance.playerHP -= 10;
                        for (int i = 0; i < ItemManager.Instance.getItem.Length; i++)
                        {
                            ItemManager.Instance.getItem[i] = false;
                        }
                        ItemManager.Instance.getItem[2] = true;
                    }
                    else
                    {
                        no = false;
                        mainText.text = "I hope you don't regret it.";
                    }

                }
                else
                {
                    mainText.text = "Fine, You're A Good Customer.";
                    BattleManager.Instance.playerHP -= 10;
                    ItemManager.Instance.getItem[2] = true;
                }

                yield return new WaitForSeconds(1.0f);

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }
            }
            else
            {
                no = false;
                mainText.text = "I hope you don't regret it.";
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
