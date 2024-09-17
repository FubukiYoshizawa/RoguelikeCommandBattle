using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventManager : Singleton<EventManager>
{
    public TextMeshProUGUI mainText; // テキスト表示

    public Image floorImage; // フロア背景
    public Sprite[] floorSprite; // 背景画像
    public enum enumFloorSprite
    {
        HPUpEvent, // 泉イベント
        ATKUpEvent, // 筋肉イベント
        SPUpEvent, // 魔法使いイベント
        Num // 背景数
    }

    private void Start()
    {
        floorSprite = new Sprite[(int)enumFloorSprite.Num];
    }

    public IEnumerator HPUpEvent()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.HPUpEvent];

        mainText.text = "You have found the fountain of miracles!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "You drank from the fountain as if you were being sucked in!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            mainText.text = "You felt your strength recovering quickly!";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "Your physical strength has been restored 50 times.";
            BattleManager.Instance.playerHP += 50;
            if (BattleManager.Instance.playerMaxHP < BattleManager.Instance.playerHP)
            {
                BattleManager.Instance.playerHP = BattleManager.Instance.playerMaxHP;
            }

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

        }
        else
        {
            mainText.text = "Your body was gradually losing its strength!";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "Attack power reduced by one.";
            BattleManager.Instance.playerATK -= 1;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }

        mainText.text = "You left the Fountain..";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

    public IEnumerator ATKUpEvent()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.ATKUpEvent];

        mainText.text = "You Are Suddenly Surrounded By Muscle!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "You Too Can Build Muscle Through Training!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "You Participated In Training!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            mainText.text = "Your Muscles Have Been Sharpened!";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "Attack power increased by three.";
            BattleManager.Instance.playerATK += 3;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }
        else
        {
            mainText.text = "You Have Sore Muscles!";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "Attack power reduced by one.";
            BattleManager.Instance.playerATK -= 1;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }

        mainText.text = "The Muscles Left.";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator SPUpEvent()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.SPUpEvent];

        mainText.text = "You have met the magician!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "You! I was just in the right place!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "Be in the middle of practicing my enhancement magic!Ei!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            mainText.text = "You felt the magic surge through you.";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "SP increased by 10.";
            BattleManager.Instance.playerMaxSP += 10;
            BattleManager.Instance.playerSP += 10;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }
        else
        {
            mainText.text = "You felt the magic drain out of you.";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "SP reduced by five.";
            BattleManager.Instance.playerMaxSP -= 5;
            BattleManager.Instance.playerSP -= 5;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }

        mainText.text = "Thanks for your cooperation!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "The sorcerer vanished like a mist.";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

}
