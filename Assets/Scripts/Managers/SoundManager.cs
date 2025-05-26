using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    //오디오 소스
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public TextMeshProUGUI masterText;
    public TextMeshProUGUI bgmText;
    public TextMeshProUGUI sfxText;

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
    {         // 초기값 반영
        ApplyVolumes();
        UpdateVolumeTexts();


    }

    public void OnMasterVolumeChanged(float value)
    {
        masterVolume = Mathf.Clamp01(value);
        ApplyVolumes();

        if (masterText != null)
            masterText.text = Mathf.RoundToInt(masterVolume * 100).ToString();
    }
    public void OnBGMVolumeChanged(float value)
    {
        bgmVolume = Mathf.Clamp01(value);
        ApplyVolumes();

        if (bgmText != null)
            bgmText.text = Mathf.RoundToInt(bgmVolume * 100).ToString();
    }
   public void OnSFXVolumeChanged(float value)
    {
        sfxVolume = Mathf.Clamp01(value);
        ApplyVolumes();

        if (sfxText != null)
            sfxText.text = Mathf.RoundToInt(sfxVolume * 100).ToString();
    }
    public void ToggleMasterMute(bool isMuted)//사운드 토글
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
    private void UpdateVolumeTexts()
    {
        if (masterText != null)
            masterText.text = Mathf.FloorToInt(masterVolume * 100).ToString();

        if (bgmText != null)
            bgmText.text = Mathf.FloorToInt(bgmVolume * 100).ToString();

        if (sfxText != null)
            sfxText.text = Mathf.FloorToInt(sfxVolume * 100).ToString();
    }
}