using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;

public class ShowImage : MonoBehaviour
{
    private Image m_image;

    public Sprite sprite { get { return m_image.sprite;  } }
    public Sprite currentSprite = null;

    private void Awake()
    {
        if (!TryGetComponent<Image>(out m_image))
            m_image = gameObject.AddComponent<Image>();

        currentSprite = m_image.sprite;
    }

    #region SetImage Function
    public void SetImage(Sprite sprite)
    {
        if (sprite == null)
            return;

        GetComponent<ImageColor>().InitColorFormat();

        m_image.color = new Color(1.0f, 1.0f, 1.0f);
        m_image.sprite = sprite;
        currentSprite = sprite;
    }

    public void SetImage()
    {
        m_image.color = new Color(1.0f, 1.0f, 1.0f);
        m_image.sprite = currentSprite;
    }
    #endregion
}
