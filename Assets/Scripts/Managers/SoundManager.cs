using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    //����� �ҽ�
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    private float masterVolume = 1f;
    private float bgmVolume = 1f;
    private float sfxVolume = 1f;

    private bool isMasterMuted = false;
    private bool isBGMMuted = false;
    private bool isSFXMuted = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // �ʱⰪ �ݿ�
        ApplyVolumes();


    }

    public void SetMasterVolume(float volume)// ���� �����̽� ����
    {
        masterVolume = Mathf.Clamp01(volume);
        ApplyVolumes();
    }

    public void SetBGMVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        ApplyVolumes();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        ApplyVolumes();
    }

    public void ToggleMasterMute(bool isMuted)//���� ���
    {
        isMasterMuted = isMuted;
        ApplyVolumes();
    }

    public void ToggleBGMMute(bool isMuted)
    {
        isBGMMuted = isMuted;
        ApplyVolumes();
    }

    public void ToggleSFXMute(bool isMuted)
    {
        isSFXMuted = isMuted;
        ApplyVolumes();
    }

    private void ApplyVolumes()
    {
        float master = 1f;

        if (isMasterMuted)
            master = 0f;
        else
            master = masterVolume;

        if (bgmSource != null)
        {
            if (isBGMMuted)
                bgmSource.volume = 0f * master;
            else
                bgmSource.volume = bgmVolume * master;
        }

        if (sfxSource != null)
        {
            if (isSFXMuted)
                sfxSource.volume = 0f * master;
            else
                sfxSource.volume = sfxVolume * master;
        }
    }
}