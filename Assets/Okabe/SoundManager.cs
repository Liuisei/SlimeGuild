using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _bgmAudioSource;
    [SerializeField] private AudioSource _seAudioSource;

    [SerializeField] private List<BGMSoundData> _bgmSoundDatas;
    [SerializeField] private List<SeSoundData> _seSoundDatas;

    public float _masterVolume = 1;
    public float _bgmMasterVolume = 1;
    public float _seMasterVolume = 1;

    private static SoundManager Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        var data = _bgmSoundDatas.Find(data => data._bgm == bgm);
        _bgmAudioSource.clip = data._audioClip;
        _bgmAudioSource.volume = data._volume * _bgmMasterVolume * _masterVolume;
        _bgmAudioSource.Play();
    }
    public void PlaySE(SeSoundData.Se se)
    {
        var data = _seSoundDatas.Find(data => data._se == se);
        _seAudioSource.volume = data._volume * _seMasterVolume * _masterVolume;
        _seAudioSource.PlayOneShot(data._audioClip);
    }
}

[Serializable]
public class BGMSoundData
{
    public enum BGM
    {
        Title,　//titleで常に流れる
        Game,　//戦闘sceneで常に流れる
    }

    public BGM _bgm;
    public AudioClip _audioClip;
    [Range(0, 1)] public float _volume = 1;
}
[Serializable]
public class SeSoundData
{
    public enum Se
    {
        Gacha,//ガチャが回されたときに流す
        Warrior, //この手に入れた後放置sceneで流す
        Button,　//Buttonを押したときに流れる
        ResultGacha,　//gachaのresultを出すときに流れる
        Clicker, //Click用
    }

    public Se _se;
    public AudioClip _audioClip;
    [Range(0, 1)] public float _volume = 1;
}