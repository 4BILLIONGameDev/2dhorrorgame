using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }


    public GameObject optionOverlay;
    private bool isOptionOpen = false;

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
}
