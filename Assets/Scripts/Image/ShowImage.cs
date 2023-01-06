using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;

public class ShowImage : MonoBehaviour
{
    private Image m_image;

    public Sprite sprite { get { return m_image.sprite;  } }

    private void Awake()
    {
        if (!TryGetComponent<Image>(out m_image))
            m_image = gameObject.AddComponent<Image>();
    }

    #region SetImage Function
    public void SetImage(Image image)
    {
        if (image == null)
            return;

        m_image.sprite = image.sprite;
    }

    public void SetImage(Sprite sprite)
    {
        if (sprite == null)
            return;

        m_image.sprite = sprite;
    }
    #endregion
}
