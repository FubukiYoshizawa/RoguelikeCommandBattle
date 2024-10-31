using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventManager : Singleton<EventManager>
{
    public TextMeshProUGUI mainText; // �e�L�X�g�\��

    public Image floorImage; // �t���A�w�i
    public Sprite[] floorSprite; // �w�i�摜
    public enum enumFloorSprite
    {
        Fountain, // ��C�x���g
        Magic, // ���@�g���C�x���g
        Muscle, // �ؓ��C�x���g
        Num // �w�i��
    }

    private void Start()
    {
        // �z��̏�����
        floorSprite = new Sprite[(int)enumFloorSprite.Num];

        // ���C���e�L�X�g��UI�I�u�W�F�N�g�ǂݍ���
        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        // �e�w�i�摜��Image�ASprite�̓ǂݍ���
        floorImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorSprite[(int)enumFloorSprite.Fountain] = Resources.Load<Sprite>("Images/FloorBacks/Fountain");
        floorSprite[(int)enumFloorSprite.Magic] = Resources.Load<Sprite>("Images/FloorBacks/Magic");
        floorSprite[(int)enumFloorSprite.Muscle] = Resources.Load<Sprite>("Images/FloorBacks/Muscle");
    }

    // ��Ղ̐�C�x���g
    public IEnumerator Fountain()
    {
        SoundManager.Instance.PlayBGM((int)SoundManager.enumBgmNumber.EventFountain);
        floorImage.sprite = floorSprite[(int)enumFloorSprite.Fountain];

        mainText.text = "���Ȃ��͊�Ղ̐���������I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        mainText.text = "���Ȃ��͋z�����܂��悤��\n��̐������񂾁I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            mainText.text = "�̗͂��݂�݂邤���ɉ񕜂����I";

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Healing);
            FlashManager.Instance.FlashScreen(new Color(0.5f, 1f, 0f), 0.3f);
            mainText.text = "HP��50�񕜂����I";
            BattleManager.Instance.playerHP += 50;
            if (BattleManager.Instance.playerMaxHP < BattleManager.Instance.playerHP)
            {
                BattleManager.Instance.playerHP = BattleManager.Instance.playerMaxHP;
            }

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);

        }
        else
        {
            mainText.text = "�̂��d���Ȃ�̂�������";

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.StatusDown);
            FlashManager.Instance.FlashScreen(Color.red, 0.3f);
            mainText.text = "�U���͂��P��������";
            BattleManager.Instance.playerATK -= 1;

            if (BattleManager.Instance.playerATK < 1)
            {
                BattleManager.Instance.playerATK = 1;
            }

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        }

        mainText.text = "���Ȃ��͐����ɂ���";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        SoundManager.Instance.StopBGM();

    }

    // ���@�g���Əo��C�x���g
    public IEnumerator Magic()
    {
        SoundManager.Instance.PlayBGM((int)SoundManager.enumBgmNumber.EventMagic);
        floorImage.sprite = floorSprite[(int)enumFloorSprite.Magic];

        mainText.text = "���Ȃ��͖��@�g���Əo������I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        mainText.text = "���Ȃ��I\n���傤�ǂ����Ƃ���ɂ����I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        mainText.text = "�������@�̗��K���Ȃ�\n���K�����āI\n�����I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            mainText.text = "���͂����ӂ�Ă���̂�������";

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Healing);
            FlashManager.Instance.FlashScreen(Color.cyan, 0.3f);
            mainText.text = "�ő�SP��10�������I";
            BattleManager.Instance.playerMaxSP += 10;
            BattleManager.Instance.playerSP += 10;

            yield return StartCoroutine(NextProcess(1.0f));
        }
        else
        {
            mainText.text = "���͂��z����̂悤�Ɋ�����";

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.StatusDown);
            FlashManager.Instance.FlashScreen(Color.red, 0.3f);
            mainText.text = "�ő�SP��5�������I";
            BattleManager.Instance.playerMaxSP -= 5;
            BattleManager.Instance.playerSP -= 5;

            if (BattleManager.Instance.playerMaxSP < 0)
            {
                BattleManager.Instance.playerMaxSP = 0;
                BattleManager.Instance.playerSP = 0;
            }
            else if (BattleManager.Instance.playerSP < 0)
            {
                BattleManager.Instance.playerSP = 0;
            }

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        }

        mainText.text = "�����͂��肪�Ƃ��I\n����͍��x�ł�����I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        mainText.text = "���@�g���͖��̂悤�ɏ�����";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        SoundManager.Instance.StopBGM();
    }

    // �ؓ��Əo��C�x���g
    public IEnumerator Muscle()
    {
        SoundManager.Instance.PlayBGM((int)SoundManager.enumBgmNumber.EventMuscle);
        floorImage.sprite = floorSprite[(int)enumFloorSprite.Muscle];

        mainText.text = "�ˑR�ؓ��Ɉ͂܂ꂽ�I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        mainText.text = "�ꏏ�ɋؓ���b���悤�I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        mainText.text = "���Ȃ��̓g���[�j���O�ɎQ�������I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            mainText.text = "�ؓ����������܂��ꂽ�I";

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.PowerCharge);
            FlashManager.Instance.FlashScreen(Color.yellow, 0.3f);
            mainText.text = "�U���͂�3�オ�����I";
            BattleManager.Instance.playerATK += 3;

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        }
        else
        {
            mainText.text = "�ؓ��ɂɂȂ����I";

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.StatusDown);
            FlashManager.Instance.FlashScreen(Color.red, 0.3f);
            mainText.text = "�U���͂�1���������I";
            BattleManager.Instance.playerATK -= 1;

            if (BattleManager.Instance.playerATK < 1)
            {
                BattleManager.Instance.playerATK = 1;
            }

            yield return StartCoroutine(NextProcess(1.0f));

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        }

        mainText.text = "�ؓ��͋����Ă�����";

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
