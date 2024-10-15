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
        Fountain, // 泉イベント
        Magic, // 魔法使いイベント
        Muscle, // 筋肉イベント
        Num // 背景数
    }

    private void Start()
    {
        floorSprite = new Sprite[(int)enumFloorSprite.Num];

        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        floorImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorSprite[(int)enumFloorSprite.Fountain] = Resources.Load<Sprite>("Images/FloorBacks/Fountain");
        floorSprite[(int)enumFloorSprite.Magic] = Resources.Load<Sprite>("Images/FloorBacks/Magic");
        floorSprite[(int)enumFloorSprite.Muscle] = Resources.Load<Sprite>("Images/FloorBacks/Muscle");
    }

    public IEnumerator Fountain()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.Fountain];

        mainText.text = "あなたは奇跡の泉を見つけた！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "あなたは吸い込まれるように\n泉の水を飲んだ！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            mainText.text = "体力がみるみるうちに回復した！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "HPが50回復した！";
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
            mainText.text = "体が重くなるのを感じた";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "攻撃力が１下がった";
            BattleManager.Instance.playerATK -= 1;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }

        mainText.text = "あなたは泉を後にした";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

    public IEnumerator Magic()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.Magic];

        mainText.text = "あなたは魔法使いと出会った！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "あなた！\nちょうどいいところにいた！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "強化魔法の練習中なの\n練習させて！\nえい！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            mainText.text = "魔力があふれてくるのを感じた";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "最大SPが10増えた！";
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
            mainText.text = "魔力が吸われるのように感じた";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "最大SPが5減った！";
            BattleManager.Instance.playerMaxSP -= 5;
            BattleManager.Instance.playerSP -= 5;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }

        mainText.text = "ご協力ありがとう！\nお礼は今度でいいよ！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "魔法使いは霧のように消えた";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator Muscle()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.Muscle];

        mainText.text = "突然筋肉に囲まれた！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "一緒に筋肉を鍛えよう！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "あなたはトレーニングに参加した！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            mainText.text = "筋肉が研ぎ澄まされた！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "攻撃力が3上がった！";
            BattleManager.Instance.playerATK += 3;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }
        else
        {
            mainText.text = "筋肉痛になった！";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "攻撃力が1下がった！";
            BattleManager.Instance.playerATK -= 1;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }

        mainText.text = "筋肉は去っていった";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }


}
