using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GameClearManager : MonoBehaviour
{
    public GameObject defaultButton;
    public Image CharacterImage;

    private void Start()
    {
        defaultButton = GameObject.Find("Title");
        CharacterImage = GameObject.Find("Character").GetComponent<Image>();
        if (PlayerPrefs.GetInt("Character") == 0)
        {
            CharacterImage.sprite = Resources.Load<Sprite>("Images/PublicImages/Fighter");
        }
        else if (PlayerPrefs.GetInt("Character") == 1)
        {
            CharacterImage.sprite = Resources.Load<Sprite>("Images/PublicImages/Magician");
        }
        EventSystem.current.SetSelectedGameObject(defaultButton);

        SoundManager.Instance.PlayBGM("GameClear");
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
