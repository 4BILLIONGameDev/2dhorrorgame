using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject optionOverlay;
    public Toggle fullscreenToggle;
    public GameObject saveLoadUIPrefab;

    private bool isOptionOpen = false;
    private GameObject currentUIInstance;
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
        
    }
    void Update()
    {
        // InputManager에서 ESC 키 입력 감지
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentUIInstance == null)
                ShowSaveLoadUI();
            else
                CloseSaveLoadUI();
        }
    }
    void ShowSaveLoadUI()
    {
        Debug.Log("로드");
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            currentUIInstance = Instantiate(saveLoadUIPrefab, canvas.transform);

            // 위치 보정
            RectTransform rt = currentUIInstance.GetComponent<RectTransform>();
            if (rt != null)
            {
                rt.anchoredPosition = Vector2.zero; // 중앙 정렬
                rt.localScale = Vector3.one; // 스케일 초기화
                rt.localRotation = Quaternion.identity; // 회전 초기화
            }
        }
        else
        {
            Debug.LogError("씬에 Canvas가 없습니다.");
        }
    }
    public void CloseSaveLoadUI()
    {
        if (currentUIInstance != null)
        {
            Destroy(currentUIInstance);
            currentUIInstance = null;
        }
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

    public void SetFullscreen(bool isFullscreen)//전체화면
    {
        Debug.Log("토글에서 전달된 값: " + isFullscreen);

        int width = Screen.currentResolution.width;
        int height = Screen.currentResolution.height;

        Screen.SetResolution(width, height, isFullscreen);

        Debug.Log("현재 Screen.fullScreen 상태: " + Screen.fullScreen);
    }
}
