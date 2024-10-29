using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TitleManager : MonoBehaviour
{
    public GameObject[] canvas;
    public enum enumCanvas
    {
        Title,
        Select,
        Stage,
        Character,
        Check,
        Num
    }
    public TextMeshProUGUI[] highestFloor;
    public enum enumHighesetFloor
    {
        Easy,
        Normal,
        Num
    }
    public GameObject[] clearImage;
    public enum enumClearImage
    {
        Easy,
        Normal,
        Num
    }
    public GameObject[] defaultButton;
    public enum enumDefaultButton
    {
        SelectButton,
        VolumeButton,
        StageButton,
        CharacterButton,
        CheckBackButton,
        Num
    }
    public int[] characterID;
    public enum enumCharacterID
    {
        Warrior,
        Magician,
        Num
    }
    public int[] DifficultyID;
    public enum enumDifficultyID
    {
        Easy,
        Normal,
        Num
    }

    public GameObject SelectWindow;
    public GameObject VolumeOptionWindow;
    public Image StageCheckImage;
    public Image CharacterCheckImage;

    public TextMeshProUGUI pressButtonText;
    public float flishingTime = 0.5f;
    public float fadeTime = 1f;


    private bool TitleOff = false;

    void Start()
    {
        canvas = new GameObject[(int)enumCanvas.Num];
        highestFloor = new TextMeshProUGUI[(int)enumHighesetFloor.Num];
        clearImage = new GameObject[(int)enumClearImage.Num];
        defaultButton = new GameObject[(int)enumDefaultButton.Num];
        characterID = new int[(int)enumCharacterID.Num];
        DifficultyID = new int[(int)enumDifficultyID.Num];

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

        canvas[(int)enumCanvas.Select].SetActive(false);
        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Check].SetActive(false);
        clearImage[(int)enumClearImage.Easy].SetActive(false);
        clearImage[(int)enumClearImage.Normal].SetActive(false);
        VolumeOptionWindow.SetActive(false);

        SoundManager.Instance.PlayBGM((int)SoundManager.enumBgmNumber.Title);

        StartCoroutine(FlishingText());

    }

    void Update()
    {
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

    private IEnumerator FlishingText()
    {
        // 無限ループで点滅を繰り返す
        while (true)
        {
            // フェードアウト
            yield return StartCoroutine(FadeText(1f, 0f)); // アルファ値1から0へ
            yield return new WaitForSeconds(flishingTime);   // フェード後の待機

            // フェードイン
            yield return StartCoroutine(FadeText(0f, 1f)); // アルファ値0から1へ
            yield return new WaitForSeconds(flishingTime);   // フェード後の待機
        }
    }

    // フェード効果を実装するコルーチン
    private IEnumerator FadeText(float startAlpha, float endAlpha)
    {
        Color originalColor = pressButtonText.color;
        float time = 0f;

        while (time < fadeTime)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeTime); // アルファ値を線形補間
            originalColor.a = alpha;
            pressButtonText.color = originalColor;
            yield return null; // 次のフレームまで待機
        }

        // 最終的なアルファ値をセット
        originalColor.a = endAlpha;
        pressButtonText.color = originalColor;
    }

    public void StageSelect()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        canvas[(int)enumCanvas.Select].SetActive(false);
        canvas[(int)enumCanvas.Stage].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.StageButton]);
    }

    public void VolumeOption()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        SelectWindow.SetActive(false);
        VolumeOptionWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.VolumeButton]);
    }

    public void VolumeBack()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Back);
        VolumeOptionWindow.SetActive(false);
        SelectWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.SelectButton]);
    }

    public void GameEnd()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void StageBack()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Back);
        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Select].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.SelectButton]);
    }

    public void CharacterBack()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Back);
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Stage].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.StageButton]);
    }

    public void Easy()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Character].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CharacterButton]);
        PlayerPrefs.SetInt("Difficulty", 0);
    }

    public void Normal()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Character].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CharacterButton]);
        PlayerPrefs.SetInt("Difficulty", 1);
    }

    public void Warrior()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        PlayerPrefs.SetInt("Character", 0);
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Check].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CheckBackButton]);
        CharacterCheckImage.sprite = Resources.Load<Sprite>("Images/PublicImages/Warrior");
        if (PlayerPrefs.GetInt("Difficulty") == (int)enumCharacterID.Warrior)
        {
            StageCheckImage.sprite = Resources.Load<Sprite>("Images/PublicImages/Easy");
        }
        else if (PlayerPrefs.GetInt("Difficulty") == (int)enumCharacterID.Magician)
        {
            StageCheckImage.sprite = Resources.Load<Sprite>("Images/PublicImages/Normal");
        }
    }

    public void Magician()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        PlayerPrefs.SetInt("Character", 1);
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

    public void No()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Back);
        canvas[(int)enumCanvas.Character].SetActive(true);
        canvas[(int)enumCanvas.Check].SetActive(false);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CharacterButton]);
    }

}
