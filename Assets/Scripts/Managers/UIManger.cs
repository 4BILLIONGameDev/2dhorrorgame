using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject saveOverlay;
    private bool isSaveOpen = false;

    public GameObject optionOverlay;
    private bool isOptionOpen = false;

    public Toggle fullscreenToggle;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen; // 현재 상태 반영
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen); // 연결
        optionOverlay.SetActive(false);
        saveOverlay.SetActive(false);
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
    public void OnCloseClicked()//옵션 닫기
    {
        optionOverlay.SetActive(false);
    }
    public void ToggleSavePanel()//세이브
    {
        isSaveOpen = !isSaveOpen;
        saveOverlay.SetActive(isSaveOpen);
    }


    public void SetFullscreen(bool isFullscreen)//전체화면
    {
        Debug.Log("토글에서 전달된 값: " + isFullscreen);

        int width = Screen.currentResolution.width;
        int height = Screen.currentResolution.height;

        Screen.SetResolution(width, height, isFullscreen);

        Debug.Log("현재 Screen.fullScreen 상태: " + Screen.fullScreen);
    }
}
