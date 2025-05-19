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
    public void OnStartButtonClicked()//���۹�ư
    {
        Debug.Log("���� ���� ��ư Ŭ��!");
        // "GameScene"���� �� ��ȯ
        SceneManager.LoadScene("Gameplay");
    }
    public void OnExitButtonClicked()//�����ư
    {
        Debug.Log("���� ���� ��ư Ŭ��!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnOptionButtonClicked() // �ɼ� ��ư Ŭ�� �� ȣ��
    {
        Debug.Log("�ɼ� ��ư Ŭ��!");
        if (UIManager.Instance != null)
        {
            UIManager.Instance.ToggleOptionPanel();
        }
        else
        {
            Debug.LogError("UIManager �ν��Ͻ��� �����ϴ�.");
        }
    }
}

