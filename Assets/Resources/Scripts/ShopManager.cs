using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ShopManager : Singleton<ShopManager>
{
    public ItemValueManager itemValueManager; // アイテムの各値管理用のスクリプト

    public TextMeshProUGUI mainText; // テキスト表示
    public GameObject selectWindow; // 選択ウィンドウ
    public bool yes, no; // 選択肢
    public GameObject defaultButton; // 選択肢表示でデフォルトで選択するボタン

    public Image floorImage; // フロア背景
    public Sprite[] floorSprite; // 背景画像
    public enum enumFloorSprite
    {
        HPPotion, // HPポーション
        SPPotion, // SPポーション
        ATKPotion, // 攻撃ポーション
        Num // 背景数
    }
    public int[] getItemNumber;
    public enum enumGetItemNumber
    {
        HPPotion,
        SPPotion,
        ATKPotion,
        Num
    }
    public int getItem;

    public void Start()
    {
        floorSprite = new Sprite[(int)enumFloorSprite.Num];
        getItemNumber = new int[(int)enumGetItemNumber.Num];

        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        selectWindow = GameObject.Find("ShopSelectWindow");
        defaultButton = GameObject.Find("ShopSelectYes");
        floorImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorSprite[(int)enumFloorSprite.HPPotion] = Resources.Load<Sprite>("Images/FloorBacks/HPPotion");
        floorSprite[(int)enumFloorSprite.SPPotion] = Resources.Load<Sprite>("Images/FloorBacks/SPPotion");
        floorSprite[(int)enumFloorSprite.ATKPotion] = Resources.Load<Sprite>("Images/FloorBacks/ATKPotion");

        getItemNumber[(int)enumGetItemNumber.HPPotion] = itemValueManager.DataList[0].itemID;
        getItemNumber[(int)enumGetItemNumber.SPPotion] = itemValueManager.DataList[1].itemID;
        getItemNumber[(int)enumGetItemNumber.ATKPotion] = itemValueManager.DataList[2].itemID;

        selectWindow.SetActive(false);

    }

    public IEnumerator HPShop()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.HPPotion];
        getItem = getItemNumber[(int)enumGetItemNumber.HPPotion];
        yield return StartCoroutine(PotionShop());
    }

    public IEnumerator SPShop()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.SPPotion];
        getItem = getItemNumber[(int)enumGetItemNumber.SPPotion];
        yield return StartCoroutine(PotionShop());
    }

    public IEnumerator ATKShop()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.ATKPotion];
        getItem = getItemNumber[(int)enumGetItemNumber.ATKPotion];
        yield return StartCoroutine(PotionShop());
    }

    public IEnumerator PotionShop()
    {
        mainText.text = "いらっしゃい！\nここはポーションショップだよ";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        SoundManager.Instance.PlaySE("Select");
        mainText.text = "血を分けてくれたら\nポーションを売ってあげよう";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        SoundManager.Instance.PlaySE("Select");
        if (BattleManager.Instance.playerHP <= 10)
        {
            mainText.text = "おっと、HPが足りないね\nまた来ておくれ";
        }
        else
        {
            mainText.text = $"{itemValueManager.DataList[getItem].itemName}が必要かい？";

            yield return new WaitForSeconds(0.5f);

            selectWindow.SetActive(true);
            EventSystem.current.SetSelectedGameObject(defaultButton);

            while (!yes && !no)
            {
                yield return null;
            }
            SoundManager.Instance.PlaySE("Select");
            selectWindow.SetActive(false);

            if (yes)
            {
                yes = false;

                if (ItemManager.Instance.haveItem)
                {
                    mainText.text = "もうアイテムを持ってるね\nアイテムを交換するかい？";

                    yield return new WaitForSeconds(0.5f);

                    selectWindow.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(defaultButton);

                    while (!yes && !no)
                    {
                        yield return null;
                    }
                    SoundManager.Instance.PlaySE("Select");
                    selectWindow.SetActive(false);

                    if (yes)
                    {
                        yes = false;
                        mainText.text = "交換成立だ\nまた会えるといいね";
                        BattleManager.Instance.playerHP -= 10;
                        for (int i = 0; i < ItemManager.Instance.getItem.Length; i++)
                        {
                            ItemManager.Instance.getItem[i] = false;
                        }
                        ItemManager.Instance.getItem[getItem] = true;
                        ItemManager.Instance.itemText.text = itemValueManager.DataList[getItem].itemName;
                    }
                    else
                    {
                        no = false;
                        mainText.text = "後悔しないことを願うよ";
                    }

                }
                else
                {
                    mainText.text = "交換成立だ\nまた会えるといいね";
                    BattleManager.Instance.playerHP -= 10;
                    ItemManager.Instance.getItem[getItem] = true;
                    ItemManager.Instance.haveItem = true;
                    ItemManager.Instance.itemText.text = itemValueManager.DataList[getItem].itemName;
                }

            }
            else
            {
                no = false;
                mainText.text = "後悔しないことを願うよ";
            }
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        SoundManager.Instance.PlaySE("Select");
        SoundManager.Instance.StopBGM();
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
