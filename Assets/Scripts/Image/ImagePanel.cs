using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ImagePanel : MonoBehaviour
{
    private Image m_image;

    private void Awake()
    {
        m_image = GetComponent<Image>();
    }

    private void SetImage(Image image)
    {
        if (image == null)
            return;

        m_image.sprite = image.sprite;
    }
}
