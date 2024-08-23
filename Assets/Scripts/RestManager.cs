using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RestManager : Singleton<RestManager>
{
    public TextMeshProUGUI mainText;

    public Image floorBack;
    public Sprite fBack;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public IEnumerator Rest()
    {
        floorBack.sprite = fBack;

        mainText.text = "You've Found A Place Where You Can Take A Break";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "You Decided To Take Some Time Off";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "Your Strength Has Been Restored";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

}
