using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenColorPanelButton : CustomButton
{
    ImageColor imageColor;

    [SerializeField] private GameObject popupRGBPanel;
    [SerializeField] private GameObject popupHSVPanel;

    public override void Init()
    {
        GameObject imagePanel = GameObject.FindWithTag("ImagePanel");

        if (!imagePanel.TryGetComponent<ImageColor>(out imageColor))
            imageColor = imagePanel.AddComponent<ImageColor>();
    }

    public override void OnClick()
    {
        if (imageColor.CurrentFormat == ImageColor.ColorFormat.R8G8B8A8)
        {
            popupRGBPanel.SetActive(true);
        }
        else if (imageColor.CurrentFormat == ImageColor.ColorFormat.HSV)
        {
            popupHSVPanel.SetActive(true);
        }
    }
}
