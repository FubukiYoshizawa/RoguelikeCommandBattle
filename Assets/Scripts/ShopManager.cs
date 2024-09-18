using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ShopManager : Singleton<ShopManager>
{
    public TextMeshProUGUI mainText; // �e�L�X�g�\��
    public GameObject selectWindow; // �I���E�B���h�E
    public bool yes, no; // �I����
    public GameObject defaultButton; // �I�����\���Ńf�t�H���g�őI������{�^��

    public Image floorImage; // �t���A�w�i
    public Sprite[] floorSprite; // �w�i�摜
    public enum enumFloorSprite
    {
        HPPotion, // HP�|�[�V����
        SPPotion, // SP�|�[�V����
        ATKPotion, // �U���|�[�V����
        Num // �w�i��
    }

    public void Start()
    {
        floorSprite = new Sprite[(int)enumFloorSprite.Num];

        floorSprite[(int)enumFloorSprite.HPPotion] = Resources.Load<Sprite>("Images/FloorBacks/HPPotion");
        floorSprite[(int)enumFloorSprite.SPPotion] = Resources.Load<Sprite>("Images/FloorBacks/SPPotion");
        floorSprite[(int)enumFloorSprite.ATKPotion] = Resources.Load<Sprite>("Images/FloorBacks/ATKPotion");

        selectWindow.SetActive(false);

    }

    public IEnumerator HPShop()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.HPPotion];

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
            EventSystem.current.SetSelectedGameObject(defaultButton);

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
                    EventSystem.current.SetSelectedGameObject(defaultButton);

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
        floorImage.sprite = floorSprite[(int)enumFloorSprite.SPPotion];

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
            EventSystem.current.SetSelectedGameObject(defaultButton);

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
        floorImage.sprite = floorSprite[(int)enumFloorSprite.ATKPotion];

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
            EventSystem.current.SetSelectedGameObject(defaultButton);

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
