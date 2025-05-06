using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("UI Components")]
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    public Toggle masterMuteToggle;
    public Toggle bgmMuteToggle;
    public Toggle sfxMuteToggle;

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
        // 초기값 반영
        ApplyVolumes();

        // 슬라이더 리스너 등록
        if (masterSlider != null)
            masterSlider.onValueChanged.AddListener(SetMasterVolume);
        if (bgmSlider != null)
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        if (sfxSlider != null)
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        // 토글 리스너 등록
        if (masterMuteToggle != null)
            masterMuteToggle.onValueChanged.AddListener(ToggleMasterMute);
        if (bgmMuteToggle != null)
            bgmMuteToggle.onValueChanged.AddListener(ToggleBGMMute);
        if (sfxMuteToggle != null)
            sfxMuteToggle.onValueChanged.AddListener(ToggleSFXMute);
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume);
        if (masterMuteToggle != null)
            masterMuteToggle.isOn = false;
        ApplyVolumes();
    }

    public void SetBGMVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        if (bgmMuteToggle != null)
            bgmMuteToggle.isOn = false;
        ApplyVolumes();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        if (sfxMuteToggle != null)
            sfxMuteToggle.isOn = false;
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

    private void ApplyVolumes()
    {
        float master = isMasterMuted ? 0f : masterVolume;

        if (bgmSource != null)
            bgmSource.volume = (isBGMMuted ? 0f : bgmVolume) * master;

        if (sfxSource != null)
            sfxSource.volume = (isSFXMuted ? 0f : sfxVolume) * master;
    }
}