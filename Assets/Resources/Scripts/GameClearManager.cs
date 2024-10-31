using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GameClearManager : MonoBehaviour
{
    public GameObject defaultButton; // �f�t�H���g�őI������{�^��
    public Image CharacterImage; // �L�����N�^�[�摜

    private void Start()
    {
        defaultButton = GameObject.Find("Title");
        // �I�������L�����N�^�[��\��������
        CharacterImage = GameObject.Find("Character").GetComponent<Image>();
        if (PlayerPrefs.GetInt("Character") == 0)
        {
            CharacterImage.sprite = Resources.Load<Sprite>("Images/PublicImages/Warrior");
        }
        else if (PlayerPrefs.GetInt("Character") == 1)
        {
            CharacterImage.sprite = Resources.Load<Sprite>("Images/PublicImages/Magician");
        }
        EventSystem.current.SetSelectedGameObject(defaultButton);

        SoundManager.Instance.PlayBGM((int)SoundManager.enumBgmNumber.GameClear);
    }

    // ���g���C�{�^��
    public void Retry()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        if (PlayerPrefs.GetInt("Difficulty") == (int)TitleManager.enumDifficultyID.Easy)
        {
            Initiate.Fade("MainSceneEasy", Color.black, 1.0f);
        }
        else if (PlayerPrefs.GetInt("Difficulty") == (int)TitleManager.enumDifficultyID.Normal)
        {
            Initiate.Fade("MainSceneNormal", Color.black, 1.0f);
        }
    }

    // �^�C�g���ֈړ�����{�^��
    public void Title()
    {
        SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Select);
        Initiate.Fade("TitleScene", Color.black, 1.0f);
    }
}
