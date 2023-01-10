using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertImageButton : CustomButton
{
    [SerializeField] public ImageColor.ColorFormat colorFormat;

    public override void Init() { }

    public override void OnClick()
    {
        GameObject imagePanel = GameObject.FindWithTag("ImagePanel");
        ImageColor imageColor = imagePanel.GetComponent<ImageColor>();

        imageColor.SetColorFormat(colorFormat);
    }
}
