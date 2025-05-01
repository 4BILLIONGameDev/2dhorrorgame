using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown; // TextMeshPro 사용 시 TMP_Dropdown
    public Toggle fullscreenToggle;

    private Resolution[] resolutions;
    private int currentResolutionIndex;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
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

        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Resolution res = resolutions[currentResolutionIndex];
        Screen.SetResolution(res.width, res.height, isFullscreen);
        Debug.Log("해상도: " + res.width + "x" + res.height + " / 전체화면: " + isFullscreen);
    }
    public void SetResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        Debug.Log($"해상도 변경: {res.width} x {res.height}");
    }
}