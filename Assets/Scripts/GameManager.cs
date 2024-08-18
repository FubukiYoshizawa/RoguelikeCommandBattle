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

    public Image floorDisplay;
    public Image floorIcon;
    // public Sprite[] floorImages;
    public Sprite[] fIcon;

    public GameObject selectWindow;
    public bool yes, no;

    void Start()
    {
        floorNumber.text = fn.ToString();
        StartCoroutine(StartAdventure());
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
            yield return StartCoroutine(BossFloor());
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
            StrongFloor()
            };

            int random = UnityEngine.Random.Range(0, coroutines.Length);
            yield return StartCoroutine(coroutines[random]);
        }

    }

    public IEnumerator BattleFloor()
    {
        floorIcon.sprite = fIcon[0];
        mainText.text = "Battle Floor";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(NextFloor());
    }

    public IEnumerator StrongFloor()
    {
        floorIcon.sprite = fIcon[1];
        mainText.text = "Difficult Battle Floor";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator BossFloor()
    {
        floorIcon.sprite = fIcon[2];
        mainText.text = "Boss Floor";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(Goal());

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

        mainText.text = "Welcome Shop";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "Do You Buy Potion?";

        yield return new WaitForSeconds(1.0f);

        selectWindow.SetActive(true);

        while (!yes && !no)
        {
            yield return null;
        }

        if (yes)
        {
            yes = false;
            mainText.text = "Thank you";
        }
        else
        {
            no = false;
            mainText.text = "Oh... See You";
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

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

        mainText.text = "Do You Want Power?";

        yield return new WaitForSeconds(1.0f);

        selectWindow.SetActive(true);

        while (!yes && !no)
        {
            yield return null;
        }

        if (yes)
        {
            yes = false;
            mainText.text = "Present For You";
        }
        else
        {
            no = false;
            mainText.text = "Ok Good Luck";
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

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

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator Goal()
    {
        floorDisplay.color = Color.white;
        mainText.text = "Goal";

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
