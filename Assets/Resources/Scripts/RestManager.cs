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
        // �eUI�I�u�W�F�N�g�̓ǂݍ���
        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        floorImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorSprite = Resources.Load<Sprite>("Images/FloorBacks/Rest");
    }

    // �x�e�̏���
    public IEnumerator Rest()
    {
        floorImage.sprite = floorSprite;

        mainText.text = "�x�e�ł������ȏꏊ���������I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        mainText.text = "���Ȃ��͂�����\n�����x�e���邱�Ƃɂ���";

        yield return StartCoroutine(NextProcess(1.0f));

        mainText.text = "���Ȃ��̗͉̑͂񕜂����I";
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Healing);
        FlashManager.Instance.FlashScreen(new Color(0.5f, 1f, 0f), 0.3f);
        BattleManager.Instance.playerHP = BattleManager.Instance.playerMaxHP;
        BattleManager.Instance.playerSP = BattleManager.Instance.playerMaxSP;

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        SoundManager.Instance.StopBGM();
    }

    // �R���[�`�����Ŏ��̏����Ɉړ�����ۂ̃f�B���C�̐ݒ�
    public IEnumerator NextProcess(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

}
