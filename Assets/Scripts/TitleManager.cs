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
        StageButton,
        CharacterButton,
        CheckBackButton,
        Num
    }

    private bool TitleOff = false;

    void Start()
    {
        canvas = new GameObject[(int)enumCanvas.Num];
        highestFloor = new TextMeshProUGUI[(int)enumHighesetFloor.Num];
        clearImage = new GameObject[(int)enumClearImage.Num];
        defaultButton = new GameObject[(int)enumDefaultButton.Num];

        canvas[(int)enumCanvas.Title] = GameObject.Find("TitleCanvas");
        canvas[(int)enumCanvas.Stage] = GameObject.Find("StageSelectCanvas");
        canvas[(int)enumCanvas.Character] = GameObject.Find("CharacterSelectCanvas");
        canvas[(int)enumCanvas.Check] = GameObject.Find("CheckCanvas");

        highestFloor[(int)enumHighesetFloor.Easy] = GameObject.Find("EasyMaxFloor").GetComponent<TextMeshProUGUI>();
        highestFloor[(int)enumHighesetFloor.Normal] = GameObject.Find("NormalMaxFloor").GetComponent<TextMeshProUGUI>();

        clearImage[(int)enumClearImage.Easy] = GameObject.Find("EasyClear");
        clearImage[(int)enumClearImage.Normal] = GameObject.Find("NormalClear");

        defaultButton[(int)enumDefaultButton.StageButton] = GameObject.Find("EasyButton");
        defaultButton[(int)enumDefaultButton.CharacterButton] = GameObject.Find("FighterButton");
        defaultButton[(int)enumDefaultButton.CheckBackButton] = GameObject.Find("NoButton");

        highestFloor[(int)enumHighesetFloor.Easy].text = PlayerPrefs.GetInt("EasyClearFloor").ToString();
        highestFloor[(int)enumHighesetFloor.Normal].text = PlayerPrefs.GetInt("NormalClearFloor").ToString();

        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Check].SetActive(false);
        clearImage[(int)enumClearImage.Easy].SetActive(false);
        clearImage[(int)enumClearImage.Normal].SetActive(false);
    }

    void Update()
    {
        if (!TitleOff && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            canvas[(int)enumCanvas.Title].SetActive(false);
            canvas[(int)enumCanvas.Stage].SetActive(true);
            TitleOff = true;
            EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.StageButton]);
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
    
    public void Back()
    {
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Stage].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.StageButton]);
    }

    public void Easy()
    {
        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Character].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CharacterButton]);
        PlayerPrefs.SetInt("Difficulty", 0);
    }

    public void Normal()
    {
        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Character].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CharacterButton]);
        PlayerPrefs.SetInt("Difficulty", 1);
    }

    public void Fighter()
    {
        PlayerPrefs.SetInt("Character", 0);
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Check].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CheckBackButton]);
    }

    public void Magician()
    {
        PlayerPrefs.SetInt("Character", 1);
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Check].SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CheckBackButton]);
    }

    public void Yes()
    {
        if (PlayerPrefs.GetInt("Difficulty") == 0)
        {
            Initiate.Fade("MainSceneEasy", Color.black, 1.0f);
        }
        else if (PlayerPrefs.GetInt("Difficulty") == 1)
        {
            Initiate.Fade("MainSceneNormal", Color.black, 1.0f);
        }
    }

    public void No()
    {
        canvas[(int)enumCanvas.Character].SetActive(true);
        canvas[(int)enumCanvas.Check].SetActive(false);
        EventSystem.current.SetSelectedGameObject(defaultButton[(int)enumDefaultButton.CharacterButton]);
    }

}
