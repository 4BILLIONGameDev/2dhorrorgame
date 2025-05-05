using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject optionOverlay;
    private bool isOptionOpen = false;
    public Toggle fullscreenToggle;
    //����
    public SoundManager soundManager;
    public Toggle masterMuteToggle;
    public Toggle bgmMuteToggle;
    public Toggle sfxMuteToggle;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �ʿ��ϸ� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen; // ���� ���� �ݿ�
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen); // ����
        optionOverlay.SetActive(false);
        }


    public void OnStartButtonClicked()//���۹�ư
    {
        Debug.Log("���� ���� ��ư Ŭ��!");

        // "GameScene"���� �� ��ȯ
        SceneManager.LoadScene("Gameplay");
    }
    public void OnExitButtonClicked()//�����ư
    {
        Debug.Log("���� ���� ��ư Ŭ��!");
        Application.Quit();
    }
    public void ToggleOptionPanel()//�ɼ�
    {
        isOptionOpen = !isOptionOpen;
        optionOverlay.SetActive(isOptionOpen);
    }
    public void OnCloseClicked()//�ݱ�
    {
        optionOverlay.SetActive(false);
    }
    public void SetFullscreen(bool isFullscreen)//��üȭ��
    {
        Debug.Log("��ۿ��� ���޵� ��: " + isFullscreen);

        int width = Screen.currentResolution.width;
        int height = Screen.currentResolution.height;
        Screen.SetResolution(width, height, isFullscreen);

        Debug.Log("���� Screen.fullScreen ����: " + Screen.fullScreen);
    }
    // �����̴����� ����
    public void OnMasterVolumeChanged(float value)
    {
        soundManager.SetMasterVolume(value);
        if (masterMuteToggle != null)
            masterMuteToggle.isOn = false;
    }

    public void OnBGMVolumeChanged(float value)
    {
        soundManager.SetBGMVolume(value);
        if (bgmMuteToggle != null)
            bgmMuteToggle.isOn = false;
    }

    public void OnSFXVolumeChanged(float value)
    {
        soundManager.SetSFXVolume(value);
        if (sfxMuteToggle != null)
            sfxMuteToggle.isOn = false;
    }
    // ��۷� ���Ұ� ó�� (BGM)


    // ��۷� ���Ұ� ó�� (SFX)
    public void OnMasterMuteToggleChanged(bool isMuted)
    {
        soundManager.ToggleMasterMute(isMuted);
    }

    public void OnBGMMuteToggleChanged(bool isMuted)
    {
        soundManager.ToggleBGMMute(isMuted);
    }

    public void OnSFXMuteToggleChanged(bool isMuted)
    {
        soundManager.ToggleSFXMute(isMuted);
    }
}