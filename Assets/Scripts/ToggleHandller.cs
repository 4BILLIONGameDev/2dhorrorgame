using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleHandler : MonoBehaviour
{
    public Image targetImage;
    public Sprite tempSprite;
    public void OnToggleChanged(bool isOn)
    {
        if (targetImage == null)
            return;

        Sprite tempImage = targetImage.sprite;
        targetImage.sprite = tempSprite;
        tempSprite = tempImage;
    }
}

