using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SetImageColor : MonoBehaviour
{
    enum ColorFormat
    {
        R8G8B8A8,
        HSV,
        GRAY,
    }

    Image m_image;
    ColorFormat curFormat;


    private void Awake()
    {
        if (!TryGetComponent<Image>(out m_image))
            m_image = gameObject.AddComponent<Image>();

        curFormat = ColorFormat.R8G8B8A8;
    }

    public void SetHSVColor()
    {
        if (curFormat == ColorFormat.HSV)
            return;

        Color.RGBToHSV(m_image.color, out float h, out float s, out float v);
        curFormat = ColorFormat.HSV;
    }

    public void SetRGBColor()
    {
        if (curFormat == ColorFormat.R8G8B8A8)
            return;

        Color.RGBToHSV(m_image.color, out float h, out float s, out float v);
        curFormat = ColorFormat.R8G8B8A8;
    }
}
