using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RestManager : Singleton<RestManager>
{
    public TextMeshProUGUI mainText; // �e�L�X�g�\��

    public Image floorImage; // �t���A�w�i
    public Sprite floorSprite; // �w�i�摜

    private void Start()
    {
        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        floorImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorSprite = Resources.Load<Sprite>("Images/FloorBacks/Rest");
    }

    public IEnumerator Rest()
    {
        floorImage.sprite = floorSprite;

        mainText.text = "�x�e�ł������ȏꏊ���������I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "���Ȃ��͂�����\n�����x�e���邱�Ƃɂ���";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "���Ȃ��̗͉̑͂񕜂����I";
        BattleManager.Instance.playerHP = BattleManager.Instance.playerMaxHP;
        BattleManager.Instance.playerSP = BattleManager.Instance.playerMaxSP;

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

}
