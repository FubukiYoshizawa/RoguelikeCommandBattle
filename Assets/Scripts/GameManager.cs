using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public TextMeshProUGUI mainText; // テキスト表示
    public TextMeshProUGUI floorNumberText; // フロア数表示

    public float floorNumber = 0; // フロア数
    public int maxFloorNumber; // 最大フロア数

    public Image floorImage; // フロア背景
    public Sprite floorSprite; // フロア背景画像
    public Image floorIconImage; // フロアアイコン
    public Sprite[] floorIconSprite; // フロアアイコン画像
    public enum enumFloorIconSprite
    {
        BattleFloor, // 戦闘フロアアイコン
        StrongFloor, // 強敵フロアアイコン
        BossFloor, // ボスフロアアイコン
        ShopFloor, // ショップフロアアイコン
        EventFloor, // イベントフロアアイコン
        TreasureFloor, // 宝箱フロアアイコン
        RestFloor, // 休憩フロアアイコン
        Num // フロアアイコン画像数
    }

    void Start()
    {
        floorIconSprite = new Sprite[(int)enumFloorIconSprite.Num];

        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        floorNumberText = GameObject.Find("FloorNumber").GetComponent<TextMeshProUGUI>();
        floorImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorSprite = Resources.Load<Sprite>("Images/FloorBacks/DefaultBack");
        floorIconImage = GameObject.Find("FloorIcon").GetComponent<Image>();

        floorIconSprite[(int)enumFloorIconSprite.BattleFloor] = Resources.Load<Sprite>("Images/FloorIcons/BattleFloor");
        floorIconSprite[(int)enumFloorIconSprite.StrongFloor] = Resources.Load<Sprite>("Images/FloorIcons/StrongFloor");
        floorIconSprite[(int)enumFloorIconSprite.BossFloor] = Resources.Load<Sprite>("Images/FloorIcons/BossFloor");
        floorIconSprite[(int)enumFloorIconSprite.ShopFloor] = Resources.Load<Sprite>("Images/FloorIcons/ShopFloor");
        floorIconSprite[(int)enumFloorIconSprite.EventFloor] = Resources.Load<Sprite>("Images/FloorIcons/EventFloor");
        floorIconSprite[(int)enumFloorIconSprite.TreasureFloor] = Resources.Load<Sprite>("Images/FloorIcons/TreasureFloor");
        floorIconSprite[(int)enumFloorIconSprite.RestFloor] = Resources.Load<Sprite>("Images/FloorIcons/RestFloor");


        floorNumberText.text = floorNumber.ToString();
        floorImage.sprite = floorSprite;
        StartCoroutine(StartAdventure());
    }

    public IEnumerator StartAdventure()
    {
        mainText.text = "探索スタート！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator NextFloor()
    {
        mainText.text = "次のフロアへ";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        floorNumberText.text = (floorNumber += 1).ToString();

        yield return new WaitForSeconds(1.0f);

        if (floorNumber == maxFloorNumber)
        {
            yield return StartCoroutine(BattleManager.Instance.BossStart());
        }
        else if (floorNumber % 2 != 0)
        {
            floorIconImage.sprite = floorIconSprite[(int)enumFloorIconSprite.BattleFloor];
            yield return StartCoroutine(BattleManager.Instance.BattleStart());
        }
        else if (floorNumber < maxFloorNumber&& floorNumber > maxFloorNumber/2 && floorNumber % 2 == 0 || PlayerPrefs.GetInt("Difficulty") != 0)
        {
            IEnumerator[] coroutines = new IEnumerator[]
            {
                ShopFloor(),
                EventFloor(),
                TreasureFloor(),
                RestFloor(),
                BattleManager.Instance.StrongStart()
            };

            int random = UnityEngine.Random.Range(0, coroutines.Length);
            yield return StartCoroutine(coroutines[random]);
        }
        else
        {
            IEnumerator[] coroutines = new IEnumerator[]
            {
                ShopFloor(),
                EventFloor(),
                TreasureFloor(),
                RestFloor(),
            };

            int random = UnityEngine.Random.Range(0, coroutines.Length);
            yield return StartCoroutine(coroutines[random]);
        }

    }

    public IEnumerator ShopFloor()
    {
        floorIconImage.sprite = floorIconSprite[(int)enumFloorIconSprite.ShopFloor];
        mainText.text = "ショップフロアだ！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        IEnumerator[] shopcoroutines = new IEnumerator[]
            {
                ShopManager.Instance.HPShop(),
                ShopManager.Instance.SPShop(),
                ShopManager.Instance.ATKShop()
            };

        int random = UnityEngine.Random.Range(0, shopcoroutines.Length);
        yield return StartCoroutine(shopcoroutines[random]);

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator EventFloor()
    {
        floorIconImage.sprite = floorIconSprite[(int)enumFloorIconSprite.EventFloor];
        mainText.text = "イベントフロアだ！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        IEnumerator[] eventcoroutines = new IEnumerator[]
            {
                EventManager.Instance.Fountain(),
                EventManager.Instance.Magic(),
                EventManager.Instance.Muscle()
            };

        int random = UnityEngine.Random.Range(0, eventcoroutines.Length);
        yield return StartCoroutine(eventcoroutines[random]);

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator TreasureFloor()
    {
        floorIconImage.sprite = floorIconSprite[(int)enumFloorIconSprite.TreasureFloor];
        mainText.text = "お宝フロアだ！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(TreasureManager.Instance.RandomItem());

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator RestFloor()
    {
        floorIconImage.sprite = floorIconSprite[(int)enumFloorIconSprite.RestFloor];
        mainText.text = "休憩フロアだ！";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(RestManager.Instance.Rest());

        yield return StartCoroutine(NextFloor());

    }

}
