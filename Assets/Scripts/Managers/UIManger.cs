using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject optionOverlay;
    public GameObject saveLoadUIPrefab;

    private bool isOptionOpen = false;
    private GameObject currentUIInstance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� ����
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        optionOverlay.SetActive(false);

    }
    void Update()
    {
        // InputManager���� ESC Ű �Է� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentUIInstance == null)
                ShowSaveLoadUI();
            else
                CloseSaveLoadUI();
        }
    }
    //�ɼ� UI
    public void ToggleOptionPanel()//�ɼ�
    {
        isOptionOpen = !isOptionOpen;
        optionOverlay.SetActive(isOptionOpen);
    }
    public void OnCloseClicked()//�ɼ� �ݱ�
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
    //���̺� �ε� UI
    public void ShowSaveLoadUI()
    {
        Debug.Log("�ε�");
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            currentUIInstance = Instantiate(saveLoadUIPrefab, canvas.transform);

            // ��ġ ����
            RectTransform rt = currentUIInstance.GetComponent<RectTransform>();
            if (rt != null)
            {
                rt.anchoredPosition = Vector2.zero; // �߾� ����
                rt.localScale = Vector3.one; // ������ �ʱ�ȭ
                rt.localRotation = Quaternion.identity; // ȸ�� �ʱ�ȭ
            }
        }
        else
        {
            Debug.LogError("���� Canvas�� �����ϴ�.");
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
}
