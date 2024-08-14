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
    // public Sprite[] floorImages;


    void Start()
    {
        mainText.text = "Start!";
        floorNumber.text = fn.ToString();
        StartCoroutine(NextFloor());
    }

    void Update()
    {
        
    }

    public IEnumerator NextFloor()
    {
        if (fn != 0)
        {
            mainText.text = "Next Floor";
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        floorNumber.text = (fn += 1).ToString();

        yield return new WaitForSeconds(2.0f);

        if (fn == maxFloor)
        {
            yield return StartCoroutine(BossBattleFloor());
        }
        else if (fn % 2 != 0)
        {
            yield return StartCoroutine(BattleFloor());
        }
        else
        {
            IEnumerator[] coroutines = new IEnumerator[]
            {
            ShopFloor(),
            EventFloor(),
            ItemFloor(),
            RestFloor(),
            DifficultBattleFloor()
            };

            int randomIndex = UnityEngine.Random.Range(0, coroutines.Length);
            yield return StartCoroutine(coroutines[randomIndex]);
        }

    }

    public IEnumerator BattleFloor()
    {
        floorDisplay.color = Color.yellow;
        mainText.text = "Battle Floor";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(NextFloor());
    }

    public IEnumerator ShopFloor()
    {
        floorDisplay.color = Color.blue;
        mainText.text = "Shop Floor";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator EventFloor()
    {
        floorDisplay.color = Color.cyan;
        mainText.text = "Event Floor";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator ItemFloor()
    {
        floorDisplay.color = Color.magenta;
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
        floorDisplay.color = Color.green;
        mainText.text = "Rest Floor";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator DifficultBattleFloor()
    {
        floorDisplay.color = Color.black;
        mainText.text = "Difficult Battle Floor";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(NextFloor());

    }

    public IEnumerator BossBattleFloor()
    {
        floorDisplay.color = Color.red;
        mainText.text = "Boss Floor";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        yield return StartCoroutine(Goal());

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

}
