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
        // 이름으로 UI 요소를 찾음 (Canvas 하위에 있어야 함)
        //resolutionDropdown = GameObject.Find("resolution").GetComponent<TMP_Dropdown>();
        //fullscreenToggle = GameObject.Find("Fullscreen").GetComponent<Toggle>();

        // 예외 처리
        if (resolutionDropdown == null || fullscreenToggle == null)
        {
            Debug.LogError("Dropdown 또는 Toggle을 찾을 수 없습니다. 이름이 정확한지 확인하세요.");
            return;
        }

        // 해상도 목록 세팅
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

        // 이벤트 연결
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Resolution res = resolutions[currentResolutionIndex];
        Screen.SetResolution(res.width, res.height, isFullscreen);
        Debug.Log($"전체화면: {isFullscreen}");
    }

    public void SetResolution(int index)
    {
        currentResolutionIndex = index;
        Resolution resolution = resolutions[index];
        Resolution res = resolution;
        Screen.SetResolution(res.width, res.height, fullscreenToggle.isOn);
        Debug.Log($"해상도 변경: {res.width} x {res.height}");
    }
}