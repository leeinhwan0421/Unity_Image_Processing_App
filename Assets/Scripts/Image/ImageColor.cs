using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ImageColor : MonoBehaviour
{
    enum ColorFormat
    {
        R8G8B8A8,
        HSV,
        GRAY,
    }

    private Image m_image;
    private ColorFormat curFormat;


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

    public void SetRGBColor(float r, float g, float b)
    {
        Color newColor = new Color(r, g, b);

        m_image.color = newColor;
    }

    public Color GetRGBColor()
    {
        return m_image.color;
    }
}
