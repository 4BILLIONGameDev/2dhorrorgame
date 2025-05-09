using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipUi : MonoBehaviour
{
    public static ToolTipUi instance;

    public GameObject tooltipPanel;
    public Text tooltipText;

    void Awake()
    {
        instance = this;
        HideTooltip();
    }

    public void ShowTooltip(string content, Vector3 position)
    {
        tooltipPanel.SetActive(true);
        tooltipText.text = content;
        tooltipPanel.transform.position = position + new Vector3(50, -50, 0); // 마우스 근처
    }

    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }
}
