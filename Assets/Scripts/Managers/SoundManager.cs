using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    //����� �ҽ�
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    private Slider masterSlider, bgmSlider, sfxSlider;
    private TextMeshProUGUI masterText, bgmText, sfxText;


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
    {   // �����̴�, �ؽ�Ʈ �ڵ� ���� (������Ʈ�� �̸� ����)
        masterSlider = GameObject.Find("masterVolume").GetComponent<Slider>();
        bgmSlider = GameObject.Find("bgmVolume").GetComponent<Slider>();
        sfxSlider = GameObject.Find("sfxVolume").GetComponent<Slider>();

        masterText = GameObject.Find("MasterText").GetComponent<TextMeshProUGUI>();
        bgmText = GameObject.Find("BGMText").GetComponent<TextMeshProUGUI>();
        sfxText = GameObject.Find("SFXText").GetComponent<TextMeshProUGUI>();
        // �ʱⰪ �ݿ�
        ApplyVolumes();
        UpdateVolumeTexts();


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
        UpdateVolumeTexts();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        ApplyVolumes();
        UpdateVolumeTexts();
    }

    public void ToggleMasterMute(bool isMuted)//���� ���
    {
        isMasterMuted = isMuted;
        ApplyVolumes();
        UpdateVolumeTexts();
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
            masterText.text = Mathf.RoundToInt(masterVolume * 100).ToString();

        if (bgmText != null)
            bgmText.text = Mathf.RoundToInt(bgmVolume * 100).ToString();

        if (sfxText != null)
            sfxText.text = Mathf.RoundToInt(sfxVolume * 100).ToString();
    }
}