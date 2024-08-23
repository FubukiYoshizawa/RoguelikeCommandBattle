using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI floorNumber;

    public float fn = 0;
    public int maxFloor = 10;

    public Image floorBack;
    public Sprite fBacks;
    public Image floorIcon;
    public Sprite[] fIcon;

    void Start()
    {
        floorNumber.text = fn.ToString();
        StartCoroutine(StartAdventure());
        floorBack.sprite = fBacks;
    }

    void Update()
    {
        
    }

    public IEnumerator StartAdventure()
    {
        mainText.text = "Adventure Start!";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator NextFloor()
    {
        mainText.text = "Next Floor";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        floorNumber.text = (fn += 1).ToString();

        yield return new WaitForSeconds(2.0f);

        if (fn == maxFloor)
        {
            yield return StartCoroutine(BattleManager.Instance.BossStart());
        }
        else if (fn % 2 != 0)
        {
            floorIcon.sprite = fIcon[0];
            yield return StartCoroutine(BattleManager.Instance.BattleStart());
        }
        else
        {
            IEnumerator[] coroutines = new IEnumerator[]
            {
                ShopFloor(),
                EventFloor(),
                ItemFloor(),
                RestFloor(),
                BattleManager.Instance.StrongStart()
            };

            int random = UnityEngine.Random.Range(0, coroutines.Length);
            yield return StartCoroutine(coroutines[random]);
        }

    }

    public IEnumerator ShopFloor()
    {
        floorIcon.sprite = fIcon[3];
        mainText.text = "Shop Floor";

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
        floorIcon.sprite = fIcon[4];
        mainText.text = "Event Floor";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        IEnumerator[] eventcoroutines = new IEnumerator[]
            {
                EventManager.Instance.HPUpEvent(),
                EventManager.Instance.SPUpEvent(),
                EventManager.Instance.ATKUpEvent()
            };

        int random = UnityEngine.Random.Range(0, eventcoroutines.Length);
        yield return StartCoroutine(eventcoroutines[random]);

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator ItemFloor()
    {
        floorIcon.sprite = fIcon[5];
        mainText.text = "Item Floor";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(TreasureManager.Instance.Item());

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator RestFloor()
    {
        floorIcon.sprite = fIcon[6];
        mainText.text = "Rest Floor";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(RestManager.Instance.Rest());

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator Goal()
    {
        mainText.text = "Goal";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

}
