using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TitleManager : MonoBehaviour
{
    public GameObject[] canvas; // �^�C�g���V�[���Ŏg�p����L�����o�X
    public enum enumCanvas
    {
        Title, // �^�C�g����\������L�����o�X
        Select, // ���[�h�I���̃L�����o�X
        Stage, // �X�e�[�W�I���̃L�����o�X
        Character, // �L�����N�^�[�I���̃L�����o�X
        Check, // �m�F�̃L�����o�X
        Num
    }
    public TextMeshProUGUI[] highestFloor; // �ō��t���A�\���p�̃e�L�X�g
    public enum enumHighesetFloor
    {
        Easy,
        Normal,
        Num
    }
    public GameObject[] clearImage; // �N���A�̍ۂɕ\������Image
    public enum enumClearImage
    {
        Easy,
        Normal,
        Num
    }
    public GameObject[] defaultButton; // �f�t�H���g�I���{�^��
    public enum enumDefaultButton
    {
        SelectButton,
        VolumeButton,
        StageButton,
        CharacterButton,
        CheckBackButton,
        Num
    }
    public int[] characterID; // �L�����N�^�[ID
    public enum enumCharacterID
    {
        Warrior,
        Magician,
        Num
    }
    public int[] DifficultyID; // ��ՓxID
    public enum enumDifficultyID
    {
        Easy,
        Normal,
        Num
    }

    public GameObject SelectWindow; // �����I���E�B���h�E
    public GameObject VolumeOptionWindow; // ���ʐݒ�E�B���h�E
    public Image StageCheckImage; // �X�e�[�W�I���E�B���h�E
    public Image CharacterCheckImage; // �L�����N�^�[�I���E�B���h�E

    public TextMeshProUGUI pressButtonText; // �^�C�g���\���e�L�X�g
    public float flishingTime = 0.5f; // �_�ŊԊu
    public float fadeTime = 1f; // �_�Ŏ���

    private bool TitleOff = false; // �����\���p�ϐ�

    void Start()
    {
        // �e�z��̏�����
        canvas = new GameObject[(int)enumCanvas.Num];
        highestFloor = new TextMeshProUGUI[(int)enumHighesetFloor.Num];
        clearImage = new GameObject[(int)enumClearImage.Num];
        defaultButton = new GameObject[(int)enumDefaultButton.Num];
        characterID = new int[(int)enumCharacterID.Num];
        DifficultyID = new int[(int)enumDifficultyID.Num];

        // �eUI�I�u�W�F�N�g�̓ǂݍ���
        canvas[(int)enumCanvas.Title] = GameObject.Find("TitleCanvas");
        canvas[(int)enumCanvas.Select] = GameObject.Find("SelectCanvas");
        canvas[(int)enumCanvas.Stage] = GameObject.Find("StageSelectCanvas");
        canvas[(int)enumCanvas.Character] = GameObject.Find("CharacterSelectCanvas");
        canvas[(int)enumCanvas.Check] = GameObject.Find("CheckCanvas");

        highestFloor[(int)enumHighesetFloor.Easy] = GameObject.Find("EasyMaxFloor").GetComponent<TextMeshProUGUI>();
        highestFloor[(int)enumHighesetFloor.Normal] = GameObject.Find("NormalMaxFloor").GetComponent<TextMeshProUGUI>();

        clearImage[(int)enumClearImage.Easy] = GameObject.Find("EasyClear");
        clearImage[(int)enumClearImage.Normal] = GameObject.Find("NormalClear");

        defaultButton[(int)enumDefaultButton.SelectButton] = GameObject.Find("StageSelectButton");
        defaultButton[(int)enumDefaultButton.VolumeButton] = GameObject.Find("VolumeBackButton");
        defaultButton[(int)enumDefaultButton.StageButton] = GameObject.Find("EasyButton");
        defaultButton[(int)enumDefaultButton.CharacterButton] = GameObject.Find("WarriorButton");
        defaultButton[(int)enumDefaultButton.CheckBackButton] = GameObject.Find("NoButton");

        highestFloor[(int)enumHighesetFloor.Easy].text = PlayerPrefs.GetInt("EasyClearFloor").ToString();
        highestFloor[(int)enumHighesetFloor.Normal].text = PlayerPrefs.GetInt("NormalClearFloor").ToString();

        SelectWindow = GameObject.Find("SelectWindow");
        VolumeOptionWindow = GameObject.Find("VolumeOptionWindow");

        StageCheckImage = GameObject.Find("StageCheckImage").GetComponent<Image>();
        CharacterCheckImage = GameObject.Find("CharacterCheckImage").GetComponent<Image>();

        pressButtonText = GameObject.Find("PressButton").GetComponent<TextMeshProUGUI>();

        // ������\���I�u�W�F�N�g���\��
        canvas[(int)enumCanvas.Select].SetActive(false);
        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Check].SetActive(false);
        clearImage[(int)enumClearImage.Easy].SetActive(false);
        clearImage[(int)enumClearImage.Normal].SetActive(false);
        VolumeOptionWindow.SetActive(false);

        // BGM�̍Đ�
        SoundManager.Instance.PlayBGM((int)SoundManager.enumBgmNumber.Title);

        StartCoroutine(FlishingText());

    }

    void Update()
    {
        // �X�y�[�X�������ꂽ�珉���I���E�B���h�E��\���i1�x�����j
        if (!TitleOff && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
            canvas[(int)enumCanvas.Title].SetActive(false);
            canvas[(int)enumCanvas.Select].SetActive(true);
            TitleOff = true;
            EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.SelectButton]);
        }

        if (PlayerPrefs.GetInt("EasyClearFloor") == 5)
        {
            clearImage[(int)enumClearImage.Easy].SetActive(true);
        }

        if (PlayerPrefs.GetInt("NormalClearFloor") == 10)
        {
            clearImage[(int)enumClearImage.Normal].SetActive(true);
        }

    }

    // �_�ŏ���
    private IEnumerator FlishingText()
    {
        while (true)
        {
            // �t�F�[�h�A�E�g
            yield return StartCoroutine(FadeText(1f, 0f));
            // �t�F�[�h��̑ҋ@
            yield return new WaitForSeconds(flishingTime);

            // �t�F�[�h�C��
            yield return StartCoroutine(FadeText(0f, 1f));
            // �t�F�[�h��̑ҋ@
            yield return new WaitForSeconds(flishingTime);
        }
    }

    // �t�F�[�h���ʂ���������R���[�`��
    private IEnumerator FadeText(float startAlpha, float endAlpha)
    {
        Color originalColor = pressButtonText.color;
        float time = 0f;

        while (time < fadeTime)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeTime);
            originalColor.a = alpha;
            pressButtonText.color = originalColor;
            yield return null;
        }

        originalColor.a = endAlpha;
        pressButtonText.color = originalColor;
    }

    // �X�e�[�W�Z���N�g�{�^��
    public void StageSelect()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        canvas[(int)enumCanvas.Select].SetActive(false);
        canvas[(int)enumCanvas.Stage].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.StageButton]);
    }

    // ���ʒ��߃{�^��
    public void VolumeOption()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        SelectWindow.SetActive(false);
        VolumeOptionWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.VolumeButton]);
    }

    // ���ʒ��߂���߂�{�^��
    public void VolumeBack()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Back);
        VolumeOptionWindow.SetActive(false);
        SelectWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.SelectButton]);
    }

    // �Q�[���I���{�^��
    public void GameEnd()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // �X�e�[�W�I���E�B���h�E����߂�{�^��
    public void StageBack()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Back);
        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Select].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.SelectButton]);
    }

    // �L�����N�^�[�I���E�B���h�E����߂�{�^��
    public void CharacterBack()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Back);
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Stage].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.StageButton]);
    }

    // �C�[�W�[�X�e�[�W�I���{�^��
    public void Easy()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Character].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CharacterButton]);
        PlayerPrefs.SetInt("Difficulty", (int)enumDifficultyID.Easy);
    }

    // �m�[�}���X�e�[�W�X�e�[�W�I���{�^��
    public void Normal()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Character].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CharacterButton]);
        PlayerPrefs.SetInt("Difficulty", (int)enumDifficultyID.Normal);
    }

    // ��m�I���{�^��
    public void Warrior()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        PlayerPrefs.SetInt("Character", (int)enumCharacterID.Warrior);
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Check].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CheckBackButton]);
        CharacterCheckImage.sprite = Resources.Load<Sprite>("Images/PublicImages/Warrior");
        if (PlayerPrefs.GetInt("Difficulty") == (int)enumDifficultyID.Easy)
        {
            StageCheckImage.sprite = Resources.Load<Sprite>("Images/PublicImages/Easy");
        }
        else if (PlayerPrefs.GetInt("Difficulty") == (int)enumDifficultyID.Normal)
        {
            StageCheckImage.sprite = Resources.Load<Sprite>("Images/PublicImages/Normal");
        }
    }

    // ���@�g���I���{�^��
    public void Magician()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        PlayerPrefs.SetInt("Character", (int)enumCharacterID.Magician);
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Check].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CheckBackButton]);
        CharacterCheckImage.sprite = Resources.Load<Sprite>("Images/PublicImages/Magician");
        if (PlayerPrefs.GetInt("Difficulty") == (int)enumDifficultyID.Easy)
        {
            StageCheckImage.sprite = Resources.Load<Sprite>("Images/PublicImages/Easy");
        }
        else if (PlayerPrefs.GetInt("Difficulty") == (int)enumDifficultyID.Normal)
        {
            StageCheckImage.sprite = Resources.Load<Sprite>("Images/PublicImages/Normal");
        }
    }

    
    // �m�F�I�����͂�
    public void Yes()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        if (PlayerPrefs.GetInt("Difficulty") == (int)enumDifficultyID.Easy)
        {
            Initiate.Fade("MainSceneEasy", Color.black, 1.0f);
        }
        else if (PlayerPrefs.GetInt("Difficulty") == (int)enumDifficultyID.Normal)
        {
            Initiate.Fade("MainSceneNormal", Color.black, 1.0f);
        }
    }

    // �m�F�I����������
    public void No()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Back);
        canvas[(int)enumCanvas.Character].SetActive(true);
        canvas[(int)enumCanvas.Check].SetActive(false);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CharacterButton]);
    }

}
