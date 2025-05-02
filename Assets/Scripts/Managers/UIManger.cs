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


    public void OnStartButtonClicked()
    {
        Debug.Log("게임 시작 버튼 클릭!");

        // "GameScene"으로 씬 전환
        SceneManager.LoadScene("Gameplay");
    }
    public void OnExitButtonClicked()
    {
        Debug.Log("게임 종료 버튼 클릭!");
        Application.Quit();
    }
    public void ToggleOptionPanel()
    {
        isOptionOpen = !isOptionOpen;
        optionOverlay.SetActive(isOptionOpen);
    }
    public void OnCloseClicked()
    {
        optionOverlay.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Debug.Log("토글에서 전달된 값: " + isFullscreen);

        int width = Screen.currentResolution.width;
        int height = Screen.currentResolution.height;
        Screen.SetResolution(width, height, isFullscreen);

        Debug.Log("현재 Screen.fullScreen 상태: " + Screen.fullScreen);
    }
}