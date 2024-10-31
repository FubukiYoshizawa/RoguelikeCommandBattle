using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public GameObject optionCanavas; // �I�v�V�����L�����o�X

    public GameObject optionWindow; // �I�v�V�����E�B���h�E
    public GameObject volumeWindow; // ���ʒ��߃E�B���h�E

    private GameObject lastSelectButton; // �I�v�V�������J���O�Ō�ɑI�����Ă����{�^��

    public GameObject optionDefaultButton; // �I�v�V�����E�B���h�E�̃f�t�H���g�{�^��
    public GameObject volumeDefaultButton; // ���ʒ��߃E�B���h�E�̃f�t�H���g�{�^��

    public bool option;

    private void Start()
    {
        // �eUI�I�u�W�F�N�g�̓ǂݍ���
        optionCanavas = GameObject.Find("OptionCanvas");
        optionWindow = GameObject.Find("OptionWindow");
        volumeWindow = GameObject.Find("VolumeWindow");
        optionDefaultButton = GameObject.Find("Restart");
        volumeDefaultButton = GameObject.Find("Back");

        // ������\���I�u�W�F�N�g���\��
        optionCanavas.SetActive(false);
        volumeWindow.SetActive(false);

    }

    void Update()
    {
        // Escape�L�[�������ꂽ�Ƃ��Ƀ|�[�Y��ʂ��J���A�Q�[�����ꎞ��~
        // �|�[�Y��ʕ\�����̓|�[�Y��ʂ���ăQ�[���ĊJ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SoundManager.Instance.PlaySE((int)SoundManager.enumSENumber.Pause);
            if (!option)
            {
                Time.timeScale = 0;
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
                volumeWindow.SetActive(false);
                optionWindow.SetActive(true);
                optionCanavas.SetActive(false);
                EventSystem.current.SetSelectedGameObject(lastSelectButton);
                Time.timeScale = 1;
            }

        }
    }

    // ���X�^�[�g�{�^��
    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Initiate.Fade(currentScene.name, Color.black, 1.0f);
        Time.timeScale = 1;
    }

    // �^�C�g���V�[���ֈړ�����{�^��
    public void Title()
    {
        Initiate.Fade("TitleScene", Color.black, 1.0f);
        Time.timeScale = 1;
    }

    // ���ʐݒ�E�B���h�E�\���{�^��
    public void Volume()
    {
        optionWindow.SetActive(false);
        volumeWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(volumeDefaultButton);
    }

    // ���ʐݒ�E�B���h�E����߂�{�^��
    public void Back()
    {
        volumeWindow.SetActive(false);
        optionWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionDefaultButton);
    }

    // �|�[�Y��ʂ����{�^��
    public void Close()
    {
        option = false;
        optionCanavas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(lastSelectButton);
        Time.timeScale = 1;
    }
}
