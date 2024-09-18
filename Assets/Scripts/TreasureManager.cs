using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TreasureManager : Singleton<TreasureManager>
{
    public TextMeshProUGUI mainText; // �e�L�X�g�\��
    public GameObject selectWindow; // �I���E�B���h�E
    public bool yes, no; // �I����
    public GameObject defaultButton; // �I�����\���Ńf�t�H���g�őI������{�^��

    public Image floorImage; // �t���A�w�i
    public Sprite[] floorSprite; // �t���A�w�i
    public enum enumFloorSprite
    {
        NotOpenTreasure, // �󔠖��J���w�i
        OpenTreasure, // �󔠊J���w�i
        Num // �t���A�w�i��
    }
    /*
    0:��w�i���J��
    1:��w�i�J��
    */

    private void Start()
    {
        floorSprite = new Sprite[(int)enumFloorSprite.Num];

        floorSprite[(int)enumFloorSprite.NotOpenTreasure] = Resources.Load<Sprite>("Images/FloorBacks/NotOpenTreasure");
        floorSprite[(int)enumFloorSprite.OpenTreasure] = Resources.Load<Sprite>("Images/FloorBacks/OpenTreasure");

        selectWindow.SetActive(false);

    }

    public IEnumerator Item()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.NotOpenTreasure];

        mainText.text = "You found a treasure chest";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        floorImage.sprite = floorSprite[(int)enumFloorSprite.OpenTreasure];

        int randomValue = Random.Range(0, 5);
        if (randomValue == 0)
        {
            mainText.text = "To my surprise, I found a bomb in the treasure chest!";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            if (ItemManager.Instance.haveItem)
            {
                mainText.text = "Do you want to replace items you already own?";

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
                    for (int i = 0; i < ItemManager.Instance.getItem.Length; i++)
                    {
                        ItemManager.Instance.getItem[i] = false;
                    }
                    ItemManager.Instance.getItem[4] = true;
                    mainText.text = "You got the bomb!";
                }
                else if (no)
                {
                    mainText.text = "You put the treasure chest back together.";
                }
            }
            else
            {
                ItemManager.Instance.getItem[4] = true;
                mainText.text = "You got the bomb!";
            }

        }
        else if (randomValue < 2)
        {
            mainText.text = "To my surprise, I found medicinal herbs in the treasure chest!";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            if (ItemManager.Instance.haveItem)
            {
                mainText.text = "Do you want to replace items you already own?";

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
                    for (int i = 0; i < ItemManager.Instance.getItem.Length; i++)
                    {
                        ItemManager.Instance.getItem[i] = false;
                    }
                    ItemManager.Instance.getItem[3] = true;
                    mainText.text = "You got medicinal herbs!";
                }
                else if (no)
                {
                    mainText.text = "You put the treasure chest back together.";
                }
            }
            else
            {
                ItemManager.Instance.getItem[3] = true;
                mainText.text = "You got medicinal herbs!";
            }
        }
        else
        {
            mainText.text = "To my surprise, I found a jewel of power in a treasure chest!";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            if (ItemManager.Instance.haveItem)
            {
                mainText.text = "Do you want to replace items you already own?";

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
                    for (int i = 0; i < ItemManager.Instance.getItem.Length; i++)
                    {
                        ItemManager.Instance.getItem[i] = false;
                    }
                    ItemManager.Instance.getItem[5] = true;
                    mainText.text = "You got a jewel of power!";
                }
                else if (no)
                {
                    mainText.text = "You put the treasure chest back together.";
                }
            }
            else
            {
                ItemManager.Instance.getItem[5] = true;
                mainText.text = "You got a jewel of power!";
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
