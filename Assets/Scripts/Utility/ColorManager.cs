using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager
{
    public static void RGBToHSV(Color RGB, out Color HSV)
    {
        Color.RGBToHSV(RGB, out float H, out float S, out float V);
        HSV = new Color(H, S, V);
    }

    public static void HSVToRGB(Color HSV, out Color RGB)
    {
        RGB = Color.HSVToRGB(HSV.r, HSV.g, HSV.b);
    }
}