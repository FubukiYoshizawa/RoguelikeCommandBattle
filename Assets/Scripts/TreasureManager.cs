using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TreasureManager : Singleton<TreasureManager>
{
    public TextMeshProUGUI mainText; // テキスト表示
    public GameObject selectWindow; // 選択ウィンドウ
    public bool yes, no; // 選択肢
    public GameObject defaultButton; // 選択肢表示でデフォルトで選択するボタン

    public Image floorImage; // フロア背景
    public Sprite[] floorSprite; // フロア背景
    public enum enumFloorSprite
    {
        NotOpenTreasure, // 宝箱未開封背景
        OpenTreasure, // 宝箱開封背景
        Num // フロア背景数
    }
    /*
    0:宝背景未開封
    1:宝背景開封
    */

    private void Start()
    {
        floorSprite = new Sprite[(int)enumFloorSprite.Num];

        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        selectWindow = GameObject.Find("ItemChangeWindow");
        defaultButton = GameObject.Find("ItemChangeYes");
        floorImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorSprite[(int)enumFloorSprite.NotOpenTreasure] = Resources.Load<Sprite>("Images/FloorBacks/NotOpenTreasure");
        floorSprite[(int)enumFloorSprite.OpenTreasure] = Resources.Load<Sprite>("Images/FloorBacks/OpenTreasure");

        selectWindow.SetActive(false);

    }

    public IEnumerator Item()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.NotOpenTreasure];

        mainText.text = "あなたは宝箱を見つけた！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        floorImage.sprite = floorSprite[(int)enumFloorSprite.OpenTreasure];

        int randomValue = Random.Range(0, 10);
        if (randomValue == 0)
        {
            mainText.text = "宝箱には\n爆弾が入っていた！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            if (ItemManager.Instance.haveItem)
            {
                mainText.text = "アイテムを交換しますか？";

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
                    mainText.text = "爆弾を手に入れた！";
                }
                else if (no)
                {
                    mainText.text = "あなたは宝箱をあきらめた";
                }
            }
            else
            {
                ItemManager.Instance.getItem[4] = true;
                mainText.text = "爆弾を手に入れた！";
            }

        }
        else if (randomValue < 2)
        {
            mainText.text = "宝箱には\n攻撃ジュエルが入っていた！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            if (ItemManager.Instance.haveItem)
            {
                mainText.text = "アイテムを交換しますか？";

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
                    mainText.text = "攻撃ジュエルを手に入れた！";
                }
                else if (no)
                {
                    mainText.text = "あなたは宝箱をあきらめた";
                }
            }
            else
            {
                ItemManager.Instance.getItem[5] = true;
                mainText.text = "攻撃ジュエルを手に入れた！";
            }
        }
        else
        {
            mainText.text = "宝箱には\n薬草が入っていた！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            if (ItemManager.Instance.haveItem)
            {
                mainText.text = "アイテムを交換しますか？";

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
                    mainText.text = "薬草を手に入れた！";
                }
                else if (no)
                {
                    mainText.text = "あなたは宝箱をあきらめた";
                }
            }
            else
            {
                ItemManager.Instance.getItem[3] = true;
                mainText.text = "薬草を手に入れた！";
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
