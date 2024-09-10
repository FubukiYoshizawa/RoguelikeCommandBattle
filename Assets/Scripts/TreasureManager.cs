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

    public Image floorBack; // フロア背景
    public Sprite[] fBack; // フロア背景
    /*
    0:宝背景未開封
    1:宝背景開封
    */

    public IEnumerator Item()
    {
        floorBack.sprite = fBack[0];

        mainText.text = "You found a treasure chest";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        floorBack.sprite = fBack[1];

        int randomValue = Random.Range(0, 5);
        if (randomValue == 0)
        {
            mainText.text = "To my surprise, I found a bomb in the treasure chest!";
            // アイテムを持っていたら入れ替える処理

        }
        else if (randomValue < 2)
        {
            mainText.text = "To my surprise, I found medicinal herbs in the treasure chest!";
        }
        else
        {
            mainText.text = "To my surprise, I found a jewel of power in a treasure chest!";
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
