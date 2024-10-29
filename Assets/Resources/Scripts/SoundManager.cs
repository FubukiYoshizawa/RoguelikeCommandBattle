using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private BGMManager bgmManager; // BGM�Ǘ��pScriptableObject
    [SerializeField] private SEManager seManager;   // SE�Ǘ��pScriptableObject

    public int[] bgmNumber; // BGM�ԍ���\���ϐ�
    public enum enumBgmNumber
    {
        Title,
        StageEasy,
        StageNormal,
        Battle,
        StrongBattle,
        BossBattle,
        GameOver,
        GameClear,
        EventFountain,
        EventMagic,
        EventMuscle,
        Shop,
        Treasure,
        Rest,
        Num
    }
    public int[] seNumber;�@// SE�ԍ���\���ϐ�
    public enum enumSENumber
    {
        Attack,
        PowerAttack,
        PowerCharge,
        Healing,
        FireBall,
        IceLance,
        Bomb,
        Damage,
        EnemySpecialAttack,
        Scythe,
        Tornado,
        Thunder,
        Breath,
        Auro,
        Lightning,
        Select,
        Back,
        StageChange,
        Pause,
        Win,
        LvUp,
        ItemGet,
        StatusDown,
        Lose,
        Num
    }

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
        bgmManager = Resources.Load<BGMManager>("ScriptableObject/BGMManager");
        seManager = Resources.Load<SEManager>("ScriptableObject/SEManager");

        bgmNumber = new int[(int)enumBgmNumber.Num];
        seNumber = new int[(int)enumSENumber.Num];

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

    // BGM�Đ�
    public void PlayBGM(int bgmElement)
    {
        if (bgmElement >= 0 && bgmElement < bgmManager.DataList.Count)
        {
            BGMData bgmData = bgmManager.DataList[bgmElement];
            bgmSource.clip = bgmData.AudioClip;
            bgmSource.Play();
        }
        else
        {
            Debug.LogWarning("�w�肳�ꂽBGM������܂���: " + bgmElement);
        }
    }

    // BGM��~
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // SE�Đ�
    public void PlaySE(int seElement)
    {
        if (seElement >= 0 && seElement < seManager.DataList.Count)
        {
            SEData sEData = seManager.DataList[seElement];
            seSource.clip = sEData.AudioClip;
            seSource.Play();
        }
        else
        {
            Debug.LogWarning("�w�肳�ꂽSE������܂���: " + seElement);
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
    public void PlaySampleSE()
    {
        PlaySE((int)enumSENumber.Win);
    }
}
