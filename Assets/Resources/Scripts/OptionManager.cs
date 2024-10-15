using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public GameObject optionCanavas;

    public GameObject optionWindow;
    public GameObject volumeWindow;

    private GameObject lastSelectButton;

    public GameObject optionDefaultButton;
    public GameObject volumeDefaultButton;

    public bool option;

    private void Start()
    {
        optionCanavas = GameObject.Find("OptionCanvas");

        optionWindow = GameObject.Find("OptionWindow");
        volumeWindow = GameObject.Find("VolumeWindow");

        optionDefaultButton = GameObject.Find("Restart");
        volumeDefaultButton = GameObject.Find("Back");

        optionCanavas.SetActive(false);
        volumeWindow.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!option)
            {
                option = true;
                if (EventSystem.current.currentSelectedGameObject != null)
                {
                    lastSelectButton = EventSystem.current.currentSelectedGameObject;
                }
                optionCanavas.SetActive(true);
                EventSystem.current.SetSelectedGameObject(optionDefaultButton);
                Time.timeScale = 0;
            }
            else
            {
                option = false;
                volumeWindow.SetActive(false);
                optionWindow.SetActive(true);
                optionCanavas.SetActive(false);
                EventSystem.current.SetSelectedGameObject(lastSelectButton);
                Time.timeScale = 1;
            }

        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();
        Initiate.Fade(currentScene.name, Color.black, 1.0f);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        Initiate.Fade("TitleScene", Color.black, 1.0f);
    }

    public void Volume()
    {
        optionWindow.SetActive(false);
        volumeWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(volumeDefaultButton);
    }

    public void Back()
    {
        volumeWindow.SetActive(false);
        optionWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionDefaultButton);
    }

    public void Close()
    {
        option = false;
        optionCanavas.SetActive(false);
        Time.timeScale = 1;
        EventSystem.current.SetSelectedGameObject(lastSelectButton);
    }
}
