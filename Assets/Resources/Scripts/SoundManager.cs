using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private BGMManager bgmManager; // BGM管理用ScriptableObject
    [SerializeField] private SEManager seManager;   // SE管理用ScriptableObject

    private AudioSource bgmSource;    // BGM再生用AudioSource
    private AudioSource seSource;     // SE再生用AudioSource

    [SerializeField] private Slider bgmVolumeSlider;  // BGM音量調整用スライダー
    [SerializeField] private Slider seVolumeSlider;   // SE音量調整用スライダー

    [SerializeField] private AudioMixerGroup bgmMixerGroup;  // BGM用のAudioMixerGroup
    [SerializeField] private AudioMixerGroup seMixerGroup;   // SE用のAudioMixerGroup

    private const string BGMVolumeKey = "BGMVolume";  // BGM音量を保存するキー
    private const string SEVolumeKey = "SEVolume";    // SE音量を保存するキー

    private void Awake()
    {
        // BGM用とSE用でAudioSourceを分けて管理
        bgmSource = gameObject.AddComponent<AudioSource>();
        seSource = gameObject.AddComponent<AudioSource>();

        // BGMとSEのAudioMixerGroupを設定
        bgmSource.outputAudioMixerGroup = bgmMixerGroup;
        seSource.outputAudioMixerGroup = seMixerGroup;

        // BGMのループを有効化
        bgmSource.loop = true;

        // 保存されている音量設定をロード
        float savedBGMVolume = PlayerPrefs.GetFloat(BGMVolumeKey, 1.0f);  // デフォルトは1.0
        float savedSEVolume = PlayerPrefs.GetFloat(SEVolumeKey, 1.0f);    // デフォルトは1.0

        // 音量設定を反映
        SetBGMVolume(savedBGMVolume);
        SetSEVolume(savedSEVolume);

        // スライダーが設定されている場合、初期値としてAudioSourceの音量を設定
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

    // BGM再生
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
            Debug.LogWarning("指定されたBGMが見つかりません: " + bgmName);
        }
    }

    // BGM停止
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // SE再生
    public void PlaySE(string seName)
    {
        SEData seData = seManager.DataList.Find(se => se.SEName == seName);
        if (seData != null)
        {
            seSource.PlayOneShot(seData.AudioClip);
        }
        else
        {
            Debug.LogWarning("指定されたSEが見つかりません: " + seName);
        }
    }

    // BGMの音量を設定
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat(BGMVolumeKey, volume);  // 音量を保存
        PlayerPrefs.Save();  // PlayerPrefsを即時保存
    }

    // SEの音量を設定
    public void SetSEVolume(float volume)
    {
        seSource.volume = volume;
        PlayerPrefs.SetFloat(SEVolumeKey, volume);   // 音量を保存
        PlayerPrefs.Save();  // PlayerPrefsを即時保存
    }
}
