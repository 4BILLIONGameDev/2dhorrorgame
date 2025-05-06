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
}
