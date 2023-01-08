using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertRGBButton : CustomButton
{
    public override void Init()
    {
    }

    public override void OnClick()
    {
        GameObject imagePanel = GameObject.FindWithTag("ImagePanel");
        ImageColor setImageColor = imagePanel.GetComponent<ImageColor>();

        setImageColor.SetRGBColor();
    }
}
