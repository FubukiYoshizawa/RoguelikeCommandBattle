using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class OptionManager : MonoBehaviour
{
    public GameObject optionCanavas;
    private GameObject lastSelectButton;
    public GameObject optionDefaultButton;
    public bool option;

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
            }
            else
            {
                option = false;
                optionCanavas.SetActive(false);
                EventSystem.current.SetSelectedGameObject(lastSelectButton);
            }

        }
    }

    public void Restart()
    {

    }

    public void Menu()
    {

    }

    public void Volume()
    {

    }

    public void End()
    {

    }
}
