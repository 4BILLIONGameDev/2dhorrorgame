using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resolutionchanger : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private Resolution[] resolutions;
    private int currentResolutionIndex;

    void Start()
    {
        // �̸����� UI ��Ҹ� ã�� (Canvas ������ �־�� ��)
        //resolutionDropdown = GameObject.Find("resolution").GetComponent<TMP_Dropdown>();
        //fullscreenToggle = GameObject.Find("Fullscreen").GetComponent<Toggle>();

        // ���� ó��
        if (resolutionDropdown == null || fullscreenToggle == null)
        {
            Debug.LogError("Dropdown �Ǵ� Toggle�� ã�� �� �����ϴ�. �̸��� ��Ȯ���� Ȯ���ϼ���.");
            return;
        }

        // �ػ� ��� ����
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
           if(!options.Contains(option)) 
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // �̺�Ʈ ����
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Resolution res = resolutions[currentResolutionIndex];
        Screen.SetResolution(res.width, res.height, isFullscreen);
        Debug.Log($"��üȭ��: {isFullscreen}");
    }

    public void SetResolution(int index)
    {
        currentResolutionIndex = index;
        Resolution resolution = resolutions[index];
        Resolution res = resolution;
        Screen.SetResolution(res.width, res.height, fullscreenToggle.isOn);
        Debug.Log($"�ػ� ����: {res.width} x {res.height}");
    }
}