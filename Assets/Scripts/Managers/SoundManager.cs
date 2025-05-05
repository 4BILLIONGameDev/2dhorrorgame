using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource bgmSource;
public AudioSource sfxSource;

private float masterVolume = 1f;
private float bgmVolume = 1f;
private float sfxVolume = 1f;

    private bool isMasterMuted = false;
    private bool isBGMMuted = false;
    private bool isSFXMuted = false;

// ������ ����
public void SetMasterVolume(float volume)
{
        masterVolume = Mathf.Clamp01(volume);
        isMasterMuted = false;
        ApplyVolumes();
    }

    // BGM/SFX ����
    public void SetBGMVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        isBGMMuted = false;  // �����̴� ���� �� ���Ұ� ����
        ApplyVolumes();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        isSFXMuted = false;  // �����̴� ���� �� ���Ұ� ����
        ApplyVolumes();
    }
    public void ToggleMasterMute(bool isMuted)
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
    // ���� ó��
    private void ApplyVolumes()
    {
        float master = isMasterMuted ? 0f : masterVolume;

        if (bgmSource != null)
            bgmSource.volume = (isBGMMuted ? 0f : bgmVolume) * master;

        if (sfxSource != null)
            sfxSource.volume = (isSFXMuted ? 0f : sfxVolume) * master;
    }

}