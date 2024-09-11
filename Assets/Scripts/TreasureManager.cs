using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TreasureManager : Singleton<TreasureManager>
{
    public TextMeshProUGUI mainText; // テキスト表示
    public GameObject selectWindow; // 選択ウィンドウ
    public bool yes, no; // 選択肢

    public Image floorImage; // フロア背景
    public Sprite[] floorSprite; // フロア背景
    /*
    0:宝背景未開封
    1:宝背景開封
    */

    public IEnumerator Item()
    {
        floorImage.sprite = floorSprite[0];

        mainText.text = "You found a treasure chest";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        floorImage.sprite = floorSprite[1];

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
