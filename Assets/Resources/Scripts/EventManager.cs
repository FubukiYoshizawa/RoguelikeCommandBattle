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
        floorSprite = new Sprite[(int)enumFloorSprite.Num];

        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        floorImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorSprite[(int)enumFloorSprite.Fountain] = Resources.Load<Sprite>("Images/FloorBacks/Fountain");
        floorSprite[(int)enumFloorSprite.Magic] = Resources.Load<Sprite>("Images/FloorBacks/Magic");
        floorSprite[(int)enumFloorSprite.Muscle] = Resources.Load<Sprite>("Images/FloorBacks/Muscle");
    }

    public IEnumerator Fountain()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.Fountain];

        mainText.text = "���Ȃ��͊�Ղ̐���������I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "���Ȃ��͋z�����܂��悤��\n��̐������񂾁I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            mainText.text = "�̗͂��݂�݂邤���ɉ񕜂����I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "HP��50�񕜂����I";
            BattleManager.Instance.playerHP += 50;
            if (BattleManager.Instance.playerMaxHP < BattleManager.Instance.playerHP)
            {
                BattleManager.Instance.playerHP = BattleManager.Instance.playerMaxHP;
            }

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

        }
        else
        {
            mainText.text = "�̂��d���Ȃ�̂�������";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "�U���͂��P��������";
            BattleManager.Instance.playerATK -= 1;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }

        mainText.text = "���Ȃ��͐����ɂ���";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

    public IEnumerator Magic()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.Magic];

        mainText.text = "���Ȃ��͖��@�g���Əo������I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "���Ȃ��I\n���傤�ǂ����Ƃ���ɂ����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "�������@�̗��K���Ȃ�\n���K�����āI\n�����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            mainText.text = "���͂����ӂ�Ă���̂�������";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "�ő�SP��10�������I";
            BattleManager.Instance.playerMaxSP += 10;
            BattleManager.Instance.playerSP += 10;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }
        else
        {
            mainText.text = "���͂��z����̂悤�Ɋ�����";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "�ő�SP��5�������I";
            BattleManager.Instance.playerMaxSP -= 5;
            BattleManager.Instance.playerSP -= 5;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }

        mainText.text = "�����͂��肪�Ƃ��I\n����͍��x�ł�����I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "���@�g���͖��̂悤�ɏ�����";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator Muscle()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.Muscle];

        mainText.text = "�ˑR�ؓ��Ɉ͂܂ꂽ�I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "�ꏏ�ɋؓ���b���悤�I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "���Ȃ��̓g���[�j���O�ɎQ�������I";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            mainText.text = "�ؓ����������܂��ꂽ�I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "�U���͂�3�オ�����I";
            BattleManager.Instance.playerATK += 3;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }
        else
        {
            mainText.text = "�ؓ��ɂɂȂ����I";

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            mainText.text = "�U���͂�1���������I";
            BattleManager.Instance.playerATK -= 1;

            yield return new WaitForSeconds(1.0f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }

        mainText.text = "�ؓ��͋����Ă�����";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }


}
