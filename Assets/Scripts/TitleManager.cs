using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private bool TitleOff = false;
    public int difficulty;

    void Start()
    {
        canvas = new GameObject[(int)enumCanvas.Num];

        canvas[(int)enumCanvas.Title] = GameObject.Find("TitleCanvas");
        canvas[(int)enumCanvas.Stage] = GameObject.Find("StageSelectCanvas");
        canvas[(int)enumCanvas.Character] = GameObject.Find("CharacterSelectCanvas");
        canvas[(int)enumCanvas.Check] = GameObject.Find("CheckCanvas");

        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Check].SetActive(false);
    }

    void Update()
    {
        if (!TitleOff && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            canvas[(int)enumCanvas.Title].SetActive(false);
            canvas[(int)enumCanvas.Stage].SetActive(true);
            TitleOff = true;
        }
    }
    
    public void Back()
    {
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Stage].SetActive(true);
    }

    public void Easy()
    {
        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Character].SetActive(true);
        difficulty = 0;
    }

    public void Normal()
    {
        canvas[(int)enumCanvas.Stage].SetActive(false);
        canvas[(int)enumCanvas.Character].SetActive(true);
        difficulty = 1;
    }

    public void Fighter()
    {
        PlayerPrefs.SetInt("Character", 0);
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Check].SetActive(true);
    }

    public void Magician()
    {
        PlayerPrefs.SetInt("Character", 1);
        canvas[(int)enumCanvas.Character].SetActive(false);
        canvas[(int)enumCanvas.Check].SetActive(true);
    }

    public void Yes()
    {
        if (difficulty == 0)
        {
            Initiate.Fade("MainSceneEasy", Color.black, 1.0f);
        }
        else if (difficulty == 1)
        {
            Initiate.Fade("MainSceneNormal", Color.black, 1.0f);
        }
    }

    public void No()
    {
        canvas[(int)enumCanvas.Character].SetActive(true);
        canvas[(int)enumCanvas.Check].SetActive(false);
    }

}
