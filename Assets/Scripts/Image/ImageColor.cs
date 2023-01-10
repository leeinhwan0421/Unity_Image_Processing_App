using OpenCvSharp.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ImageColor : MonoBehaviour
{
    public enum ColorFormat
    {
        R8G8B8A8,
        HSV,
        GRAY,
        EDGEDETECTION
    }

    private Image m_image;
    private ColorFormat curFormat;
    public ColorFormat CurrentFormat { get { return curFormat; } }

    private void Awake()
    {
        if (!TryGetComponent<Image>(out m_image))
            m_image = gameObject.AddComponent<Image>();

        curFormat = ColorFormat.R8G8B8A8;
    }

    public void InitColorFormat()
    {
        curFormat = ColorFormat.R8G8B8A8;
    }

    public void SetColorFormat(ColorFormat format)
    {
        if (curFormat == format)
            return;

        curFormat = format;

        if (curFormat == ColorFormat.GRAY)
        {
            m_image.sprite = GrayscaleImage.SpriteToGrayScale(m_image.sprite);
            m_image.color = new Color(1.0f, 1.0f, 1.0f);
        }
        else if (curFormat == ColorFormat.EDGEDETECTION)
        {
            m_image.sprite = EdgeDectectionImage.SpriteToEdgeDectection(m_image.sprite);
            m_image.color = new Color(1.0f, 1.0f, 1.0f);
        }
        else
        {
            GetComponent<ShowImage>().SetImage();
        }

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
