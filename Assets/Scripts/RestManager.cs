using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RestManager : Singleton<RestManager>
{
    public TextMeshProUGUI mainText; // ÉeÉLÉXÉgï\é¶

    public Image floorImage; // ÉtÉçÉAîwåi
    public Sprite floorSprite; // îwåiâÊëú

    private void Start()
    {
        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        floorImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorSprite = Resources.Load<Sprite>("Images/FloorBacks/Rest");
    }

    public IEnumerator Rest()
    {
        floorImage.sprite = floorSprite;

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
        BattleManager.Instance.playerHP = BattleManager.Instance.playerMaxHP;
        BattleManager.Instance.playerSP = BattleManager.Instance.playerMaxSP;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

}
