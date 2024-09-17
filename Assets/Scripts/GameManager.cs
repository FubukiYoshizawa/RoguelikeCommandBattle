using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public TextMeshProUGUI mainText; // �e�L�X�g�\��
    public TextMeshProUGUI floorNumberText; // �t���A���\��

    public float floorNumber = 0; // �t���A��
    public int maxFloorNumber; // �ő�t���A��

    public Image floorImage; // �t���A�w�i
    public Sprite floorSprite; // �t���A�w�i�摜
    public Image floorIconImage; // �t���A�A�C�R��
    public Sprite[] floorIconSprite; // �t���A�A�C�R���摜
    public enum enumFloorIconSprite
    {
        BattleFloor, // �퓬�t���A�A�C�R��
        StrongFloor, // ���G�t���A�A�C�R��
        BossFloor, // �{�X�t���A�A�C�R��
        ShopFloor, // �V���b�v�t���A�A�C�R��
        ItemFloor, // �A�C�e���t���A�A�C�R��
        RestFloor, // �x�e�t���A�A�C�R��
        Num // �t���A�A�C�R���摜��
    }

    void Start()
    {
        floorIconSprite = new Sprite[(int)enumFloorIconSprite.Num];
        floorNumberText.text = floorNumber.ToString();
        floorImage.sprite = floorSprite;
        StartCoroutine(StartAdventure());
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
        floorIconImage.sprite = floorIconSprite[(int)enumFloorIconSprite.ShopFloor];
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
        floorIconImage.sprite = floorIconSprite[(int)enumFloorIconSprite.ItemFloor];
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
        floorIconImage.sprite = floorIconSprite[(int)enumFloorIconSprite.RestFloor];
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
        floorIconImage.sprite = floorIconSprite[6];
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
