using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ShopManager : Singleton<ShopManager>
{
    public TextMeshProUGUI mainText; // �e�L�X�g�\��
    public GameObject selectWindow; // �I���E�B���h�E
    public bool yes, no; // �I����
    public GameObject defaultButton; // �I�����\���Ńf�t�H���g�őI������{�^��

    public Image floorImage; // �t���A�w�i
    public Sprite[] floorSprite; // �w�i�摜
    public enum enumFloorSprite
    {
        HPPotion, // HP�|�[�V����
        SPPotion, // SP�|�[�V����
        ATKPotion, // �U���|�[�V����
        Num // �w�i��
    }

    public void Start()
    {
        floorSprite = new Sprite[(int)enumFloorSprite.Num];

        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        selectWindow = GameObject.Find("ShopSelectWindow");
        defaultButton = GameObject.Find("ShopSelectYes");
        floorImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorSprite[(int)enumFloorSprite.HPPotion] = Resources.Load<Sprite>("Images/FloorBacks/HPPotion");
        floorSprite[(int)enumFloorSprite.SPPotion] = Resources.Load<Sprite>("Images/FloorBacks/SPPotion");
        floorSprite[(int)enumFloorSprite.ATKPotion] = Resources.Load<Sprite>("Images/FloorBacks/ATKPotion");

        selectWindow.SetActive(false);

    }

    public IEnumerator HPShop()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.HPPotion];

        mainText.text = "��������Ⴂ�I\n�����̓|�[�V�����V���b�v����";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "���𕪂��Ă��ꂽ��\n�|�[�V�����𔄂��Ă����悤";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP <= 10)
        {
            mainText.text = "�����ƁAHP������Ȃ���\n�܂����Ă�����";
        }
        else
        {
            mainText.text = "HP�|�[�V�������K�v�����H";

            yield return new WaitForSeconds(0.5f);

            selectWindow.SetActive(true);
            EventSystem.current.SetSelectedGameObject(defaultButton);

            while (!yes && !no)
            {
                yield return null;
            }

            selectWindow.SetActive(false);

            if (yes)
            {
                yes = false;

                if (ItemManager.Instance.haveItem)
                {
                    mainText.text = "�����A�C�e���������Ă��\n�A�C�e�����������邩���H";

                    yield return new WaitForSeconds(0.5f);

                    selectWindow.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(defaultButton);

                    while (!yes && !no)
                    {
                        yield return null;
                    }

                    selectWindow.SetActive(false);

                    if (yes)
                    {
                        yes = false;
                        mainText.text = "����������\n�܂����Ƃ�����";
                        BattleManager.Instance.playerHP -= 10;
                        for (int i = 0; i < ItemManager.Instance.getItem.Length; i++)
                        {
                            ItemManager.Instance.getItem[i] = false;
                        }
                        ItemManager.Instance.getItem[0] = true;
                    }
                    else
                    {
                        no = false;
                        mainText.text = "������Ȃ����Ƃ��肤��";
                    }

                }
                else
                {
                    mainText.text = "����������\n�܂����Ƃ�����";
                    BattleManager.Instance.playerHP -= 10;
                    ItemManager.Instance.getItem[0] = true;
                    ItemManager.Instance.haveItem = true;
                }

                yield return new WaitForSeconds(1.0f);

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }
            }
            else
            {
                no = false;
                mainText.text = "������Ȃ����Ƃ��肤��";
            }
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
    }

    public IEnumerator SPShop()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.SPPotion];

        mainText.text = "��������Ⴂ�I\n�����̓|�[�V�����V���b�v����";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "���𕪂��Ă��ꂽ��\n�|�[�V�����𔄂��Ă����悤";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP <= 10)
        {
            mainText.text = "�����ƁAHP������Ȃ���\n�܂����Ă�����";
        }
        else
        {
            mainText.text = "SP�|�[�V�������K�v�����H";

            yield return new WaitForSeconds(0.5f);

            selectWindow.SetActive(true);
            EventSystem.current.SetSelectedGameObject(defaultButton);

            while (!yes && !no)
            {
                yield return null;
            }

            selectWindow.SetActive(false);

            if (yes)
            {
                yes = false;

                if (ItemManager.Instance.haveItem)
                {
                    mainText.text = "�����A�C�e���������Ă��\n�A�C�e�����������邩���H";

                    yield return new WaitForSeconds(0.5f);

                    selectWindow.SetActive(true);

                    while (!yes && !no)
                    {
                        yield return null;
                    }

                    selectWindow.SetActive(false);

                    if (yes)
                    {
                        yes = false;
                        mainText.text = "����������\n�܂����Ƃ�����";
                        BattleManager.Instance.playerHP -= 10;
                        for (int i = 0; i < ItemManager.Instance.getItem.Length; i++)
                        {
                            ItemManager.Instance.getItem[i] = false;
                        }
                        ItemManager.Instance.getItem[1] = true;
                    }
                    else
                    {
                        no = false;
                        mainText.text = "������Ȃ����Ƃ��肤��";
                    }

                }
                else
                {
                    mainText.text = "����������\n�܂����Ƃ�����";
                    BattleManager.Instance.playerHP -= 10;
                    ItemManager.Instance.getItem[1] = true;
                    ItemManager.Instance.haveItem = true;
                }

                yield return new WaitForSeconds(1.0f);

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }
            }
            else
            {
                no = false;
                mainText.text = "������Ȃ����Ƃ��肤��";
            }
        }

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

    }

    public IEnumerator ATKShop()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.ATKPotion];

        mainText.text = "��������Ⴂ�I\n�����̓|�[�V�����V���b�v����";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        mainText.text = "���𕪂��Ă��ꂽ��\n�|�[�V�����𔄂��Ă����悤";

        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        if (BattleManager.Instance.playerHP <= 10)
        {
            mainText.text = "�����ƁAHP������Ȃ���\n�܂����Ă�����";
        }
        else
        {
            mainText.text = "SP�|�[�V�������K�v�����H";

            yield return new WaitForSeconds(0.5f);

            selectWindow.SetActive(true);
            EventSystem.current.SetSelectedGameObject(defaultButton);

            while (!yes && !no)
            {
                yield return null;
            }

            selectWindow.SetActive(false);

            if (yes)
            {
                yes = false;

                if (ItemManager.Instance.haveItem)
                {
                    mainText.text = "�����A�C�e���������Ă��\n�A�C�e�����������邩���H";

                    yield return new WaitForSeconds(0.5f);

                    selectWindow.SetActive(true);

                    while (!yes && !no)
                    {
                        yield return null;
                    }

                    selectWindow.SetActive(false);

                    if (yes)
                    {
                        yes = false;
                        mainText.text = "����������\n�܂����Ƃ�����";
                        BattleManager.Instance.playerHP -= 10;
                        for (int i = 0; i < ItemManager.Instance.getItem.Length; i++)
                        {
                            ItemManager.Instance.getItem[i] = false;
                        }
                        ItemManager.Instance.getItem[2] = true;
                    }
                    else
                    {
                        no = false;
                        mainText.text = "������Ȃ����Ƃ��肤��";
                    }

                }
                else
                {
                    mainText.text = "����������\n�܂����Ƃ�����";
                    BattleManager.Instance.playerHP -= 10;
                    ItemManager.Instance.getItem[2] = true;
                    ItemManager.Instance.haveItem = true;
                }

                yield return new WaitForSeconds(1.0f);

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }
            }
            else
            {
                no = false;
                mainText.text = "������Ȃ����Ƃ��肤��";
            }
        }

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
