using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RestManager : Singleton<RestManager>
{
    public TextMeshProUGUI mainText; // ƒeƒLƒXƒg•\¦

    public Image floorImage; // ƒtƒƒA”wŒi
    public Sprite floorSprite; // ”wŒi‰æ‘œ

    private void Start()
    {
        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        floorImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorSprite = Resources.Load<Sprite>("Images/FloorBacks/Rest");
    }

    public IEnumerator Rest()
    {
        floorImage.sprite = floorSprite;

        mainText.text = "‹xŒe‚Å‚«‚»‚¤‚ÈêŠ‚ğŒ©‚Â‚¯‚½I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "‚ ‚È‚½‚Í‚±‚±‚Å\n­‚µ‹xŒe‚·‚é‚±‚Æ‚É‚µ‚½";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "‚ ‚È‚½‚Ì‘Ì—Í‚Í‰ñ•œ‚µ‚½I";
        BattleManager.Instance.playerHP = BattleManager.Instance.playerMaxHP;
        BattleManager.Instance.playerSP = BattleManager.Instance.playerMaxSP;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

}
