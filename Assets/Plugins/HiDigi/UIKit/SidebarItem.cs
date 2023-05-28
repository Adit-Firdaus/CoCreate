using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MyBox;

public class SidebarItem : MonoBehaviour
{
    [Header("Settings")]
    public Sprite iconImageSprite;
    public string labelTextString;

    [Header("References")]
    public Image iconImage;
    public TextMeshProUGUI labelText;

    void OnValidate()
    {
        SetIconImage(iconImageSprite);
        SetLabelText(labelTextString);
    }

    public void SetIconImage(Sprite sprite)
    {
        if (iconImage == null) return;
        iconImage.sprite = sprite;
    }

    public void SetLabelText(string text)
    {
        if (labelText == null) return;
        labelText.text = text;
    }
}
