using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnOptionButtonClicked() // 옵션 버튼 클릭 시 호출
    {
        Debug.Log("옵션 버튼 클릭!");
        if (UIManager.Instance != null)
        {
            UIManager.Instance.ToggleOptionPanel();
        }
        else
        {
            Debug.LogError("UIManager 인스턴스가 없습니다.");
        }
    }
}

