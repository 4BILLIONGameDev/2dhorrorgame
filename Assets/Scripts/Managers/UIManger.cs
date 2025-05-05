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
    //사운드
    public SoundManager soundManager;
    public Toggle masterMuteToggle;
    public Toggle bgmMuteToggle;
    public Toggle sfxMuteToggle;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 필요하면 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen; // 현재 상태 반영
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen); // 연결
        optionOverlay.SetActive(false);
        }


    public void OnStartButtonClicked()//시작버튼
    {
        Debug.Log("게임 시작 버튼 클릭!");

        // "GameScene"으로 씬 전환
        SceneManager.LoadScene("Gameplay");
    }
    public void OnExitButtonClicked()//종료버튼
    {
        Debug.Log("게임 종료 버튼 클릭!");
        Application.Quit();
    }
    public void ToggleOptionPanel()//옵션
    {
        isOptionOpen = !isOptionOpen;
        optionOverlay.SetActive(isOptionOpen);
    }
    public void OnCloseClicked()//닫기
    {
        optionOverlay.SetActive(false);
    }
    public void SetFullscreen(bool isFullscreen)//전체화면
    {
        Debug.Log("토글에서 전달된 값: " + isFullscreen);

        int width = Screen.currentResolution.width;
        int height = Screen.currentResolution.height;
        Screen.SetResolution(width, height, isFullscreen);

        Debug.Log("현재 Screen.fullScreen 상태: " + Screen.fullScreen);
    }
    // 슬라이더에서 연결
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
    // 토글로 음소거 처리 (BGM)


    // 토글로 음소거 처리 (SFX)
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