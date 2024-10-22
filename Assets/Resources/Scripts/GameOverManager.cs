using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GameOverManager : MonoBehaviour
{
    public GameObject defaultButton;

    private void Start()
    {
        defaultButton = GameObject.Find("Title");
        EventSystem.current.SetSelectedGameObject(defaultButton);

        SoundManager.Instance.PlayBGM("GameOver");
    }

    void Update()
    {
        
    }

    public void Retry()
    {
        SoundManager.Instance.PlaySE("Select");
        if (PlayerPrefs.GetInt("Difficulty") == 0)
        {
            Initiate.Fade("MainSceneEasy", Color.black, 1.0f);
        }
        else if (PlayerPrefs.GetInt("Difficulty") == 1)
        {
            Initiate.Fade("MainSceneNormal", Color.black, 1.0f);
        }
    }

    public void Title()
    {
        SoundManager.Instance.PlaySE("Select");
        Initiate.Fade("TitleScene", Color.black, 1.0f);
    }

}
