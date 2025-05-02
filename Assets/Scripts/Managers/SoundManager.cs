using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip clip;
    public static SoundManager Instance;
    public AudioSource backgroundMusicSource;
    public AudioSource soundEffectSource;
    // ���� ����
    [Range(0f, 1f)] public float backgroundMusicVolume = 1f;
    [Range(0f, 1f)] public float soundEffectVolume = 1f;
    void Start()
    {
        PlayBackgroundMusic(clip);
        // ���� �� ����� ���

    }
    public void PlayBackgroundMusic(AudioClip clip)
    {
        backgroundMusicSource.clip = clip;
        backgroundMusicSource.volume = backgroundMusicVolume;
        backgroundMusicSource.loop = true; // ������� �ݺ��ǵ��� ����
        backgroundMusicSource.Play();
    }
    // ����� ���� ����
    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusicVolume = volume;
        backgroundMusicSource.volume = backgroundMusicVolume;

    }

    // ȿ���� ���� ����
    public void SetSoundEffectVolume(float volume)
    {
        soundEffectVolume = volume;
        soundEffectSource.volume = soundEffectVolume;
    }
}