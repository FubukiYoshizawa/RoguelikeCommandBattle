using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TreasureManager : Singleton<TreasureManager>
{
    public ItemValueManager itemValueManager; // �A�C�e���̊e�l�Ǘ��p�̃X�N���v�g

    public TextMeshProUGUI mainText; // �e�L�X�g�\��
    public GameObject selectWindow; // �I���E�B���h�E
    public bool yes, no; // �I����
    public GameObject defaultButton; // �I�����\���Ńf�t�H���g�őI������{�^��

    public Image floorImage; // �t���A�w�i
    public Sprite[] floorSprite; // �t���A�w�i
    public enum enumFloorSprite
    {
        NotOpenTreasure, // �󔠖��J���w�i
        OpenTreasure, // �󔠊J���w�i
        Num // �t���A�w�i��
    }
    public int[] getItemNumber;
    public enum enumGetItemNumber
    {
        Healherb,
        DamageBomb,
        ATKJewel,
        Num
    }
    public int itemNumber;
    /*
    0:��w�i���J��
    1:��w�i�J��
    */

    private void Start()
    {
        itemValueManager = Resources.Load<ItemValueManager>("ScriptableObject/ItemValueManager");

        floorSprite = new Sprite[(int)enumFloorSprite.Num];
        getItemNumber = new int[(int)enumGetItemNumber.Num];

        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        selectWindow = GameObject.Find("ItemChangeWindow");
        defaultButton = GameObject.Find("ItemChangeYes");
        floorImage = GameObject.Find("FloorImage").GetComponent<Image>();
        floorSprite[(int)enumFloorSprite.NotOpenTreasure] = Resources.Load<Sprite>("Images/FloorBacks/NotOpenTreasure");
        floorSprite[(int)enumFloorSprite.OpenTreasure] = Resources.Load<Sprite>("Images/FloorBacks/OpenTreasure");

        getItemNumber[(int)enumGetItemNumber.Healherb] = itemValueManager.DataList[3].itemID;
        getItemNumber[(int)enumGetItemNumber.DamageBomb] = itemValueManager.DataList[4].itemID;
        getItemNumber[(int)enumGetItemNumber.ATKJewel] = itemValueManager.DataList[5].itemID;

        selectWindow.SetActive(false);

    }

    public IEnumerator RandomItem()
    {
        int randomValue = Random.Range(0, 10);
        if (randomValue == 0)
        {
            itemNumber = getItemNumber[(int)enumGetItemNumber.Healherb];
            yield return StartCoroutine(Item());
        }
        else if (randomValue < 2)
        {
            itemNumber = getItemNumber[(int)enumGetItemNumber.DamageBomb];
            yield return StartCoroutine(Item());
        }
        else
        {
            itemNumber = getItemNumber[(int)enumGetItemNumber.ATKJewel];
            yield return StartCoroutine(Item());
        }

    }

    public IEnumerator Item()
    {
        floorImage.sprite = floorSprite[(int)enumFloorSprite.NotOpenTreasure];

        mainText.text = "���Ȃ��͕󔠂��������I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        FlashManager.Instance.FlashScreen(Color.yellow, 0.3f);
        floorImage.sprite = floorSprite[(int)enumFloorSprite.OpenTreasure];

        mainText.text = $"�󔠂ɂ�\n{itemValueManager.DataList[itemNumber].itemName}�������Ă����I";

        yield return StartCoroutine(NextProcess(1.0f));

        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        if (ItemManager.Instance.haveItem)
        {
            mainText.text = "�A�C�e�����������܂����H";

            yield return new WaitForSeconds(0.5f);

            selectWindow.SetActive(true);
            EventSystem.current.SetSelectedGameObject(defaultButton);

            while (!yes && !no)
            {
                yield return null;
            }

            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
            selectWindow.SetActive(false);

            if (yes)
            {
                for (int i = 0; i < ItemManager.Instance.getItem.Length; i++)
                {
                    ItemManager.Instance.getItem[i] = false;
                }
                ItemManager.Instance.getItem[itemNumber] = true;
                ItemManager.Instance.itemText.text = itemValueManager.DataList[itemNumber].itemName;
                mainText.text = $"{itemValueManager.DataList[itemNumber].itemName}����ɓ��ꂽ�I";
            }
            else if (no)
            {
                mainText.text = "���Ȃ��͕󔠂�������߂�";
            }
        }
        else
        {
            ItemManager.Instance.getItem[itemNumber] = true;
            ItemManager.Instance.haveItem = true;
            ItemManager.Instance.itemText.text = itemValueManager.DataList[itemNumber].itemName;
            mainText.text = $"{itemValueManager.DataList[itemNumber].itemName}����ɓ��ꂽ�I";
        }

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

    public void Yes()
    {
        yes = true;
    }

    public void No()
    {
        no = true;
    }

}
