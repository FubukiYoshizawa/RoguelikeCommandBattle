using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private BGMManager bgmManager; // BGM�Ǘ��pScriptableObject
    [SerializeField] private SEManager seManager;   // SE�Ǘ��pScriptableObject

    private AudioSource bgmSource;    // BGM�Đ��pAudioSource
    private AudioSource seSource;     // SE�Đ��pAudioSource

    [SerializeField] private Slider bgmVolumeSlider;  // BGM���ʒ����p�X���C�_�[
    [SerializeField] private Slider seVolumeSlider;   // SE���ʒ����p�X���C�_�[

    [SerializeField] private AudioMixerGroup bgmMixerGroup;  // BGM�p��AudioMixerGroup
    [SerializeField] private AudioMixerGroup seMixerGroup;   // SE�p��AudioMixerGroup

    private const string BGMVolumeKey = "BGMVolume";  // BGM���ʂ�ۑ�����L�[
    private const string SEVolumeKey = "SEVolume";    // SE���ʂ�ۑ�����L�[

    private void Awake()
    {
        // BGM�p��SE�p��AudioSource�𕪂��ĊǗ�
        bgmSource = gameObject.AddComponent<AudioSource>();
        seSource = gameObject.AddComponent<AudioSource>();

        // BGM��SE��AudioMixerGroup��ݒ�
        bgmSource.outputAudioMixerGroup = bgmMixerGroup;
        seSource.outputAudioMixerGroup = seMixerGroup;

        // BGM�̃��[�v��L����
        bgmSource.loop = true;

        // �ۑ�����Ă��鉹�ʐݒ�����[�h
        float savedBGMVolume = PlayerPrefs.GetFloat(BGMVolumeKey, 1.0f);  // �f�t�H���g��1.0
        float savedSEVolume = PlayerPrefs.GetFloat(SEVolumeKey, 1.0f);    // �f�t�H���g��1.0

        // ���ʐݒ�𔽉f
        SetBGMVolume(savedBGMVolume);
        SetSEVolume(savedSEVolume);

        // �X���C�_�[���ݒ肳��Ă���ꍇ�A�����l�Ƃ���AudioSource�̉��ʂ�ݒ�
        if (bgmVolumeSlider != null)
        {
            bgmVolumeSlider.value = bgmSource.volume;
            bgmVolumeSlider.onValueChanged.AddListener(SetBGMVolume);
        }

        if (seVolumeSlider != null)
        {
            seVolumeSlider.value = seSource.volume;
            seVolumeSlider.onValueChanged.AddListener(SetSEVolume);
        }
    }

    private void Start()
    {
        PlayBGM("BGM");
    }

    // BGM�Đ�
    public void PlayBGM(string bgmName)
    {
        BGMData bgmData = bgmManager.DataList.Find(bgm => bgm.BGMName == bgmName);
        if (bgmData != null)
        {
            bgmSource.clip = bgmData.AudioClip;
            bgmSource.Play();
        }
        else
        {
            Debug.LogWarning("�w�肳�ꂽBGM��������܂���: " + bgmName);
        }
    }

    // BGM��~
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // SE�Đ�
    public void PlaySE(string seName)
    {
        SEData seData = seManager.DataList.Find(se => se.SEName == seName);
        if (seData != null)
        {
            seSource.PlayOneShot(seData.AudioClip);
        }
        else
        {
            Debug.LogWarning("�w�肳�ꂽSE��������܂���: " + seName);
        }
    }

    // BGM�̉��ʂ�ݒ�
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat(BGMVolumeKey, volume);  // ���ʂ�ۑ�
        PlayerPrefs.Save();  // PlayerPrefs�𑦎��ۑ�
    }

    // SE�̉��ʂ�ݒ�
    public void SetSEVolume(float volume)
    {
        seSource.volume = volume;
        PlayerPrefs.SetFloat(SEVolumeKey, volume);   // ���ʂ�ۑ�
        PlayerPrefs.Save();  // PlayerPrefs�𑦎��ۑ�
    }
}
