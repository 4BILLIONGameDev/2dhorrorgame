using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip clip;
    public static SoundManager Instance;
    public AudioSource backgroundMusicSource;
    public AudioSource soundEffectSource;
    // 볼륨 변수
    [Range(0f, 1f)] public float backgroundMusicVolume = 1f;
    [Range(0f, 1f)] public float soundEffectVolume = 1f;
    void Start()
    {
        PlayBackgroundMusic(clip);
        // 시작 시 배경음 재생

    }
    public void PlayBackgroundMusic(AudioClip clip)
    {
        backgroundMusicSource.clip = clip;
        backgroundMusicSource.volume = backgroundMusicVolume;
        backgroundMusicSource.loop = true; // 배경음은 반복되도록 설정
        backgroundMusicSource.Play();
    }
    // 배경음 볼륨 변경
    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusicVolume = volume;
        backgroundMusicSource.volume = backgroundMusicVolume;

    }

    // 효과음 볼륨 변경
    public void SetSoundEffectVolume(float volume)
    {
        soundEffectVolume = volume;
        soundEffectSource.volume = soundEffectVolume;
    }
}