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
        SetImageColor setImageColor = imagePanel.GetComponent<SetImageColor>();

        setImageColor.SetRGBColor();
    }
}
