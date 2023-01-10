using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PopupRGBPanel : MonoBehaviour
{
    #region value
    private ImageColor imageColor;

    [SerializeField] private Scrollbar redScroll;
    [SerializeField] private Text redText;

    [SerializeField] private Scrollbar greenScroll;
    [SerializeField] private Text greenText;

    [SerializeField] private Scrollbar blueScroll;
    [SerializeField] private Text blueText;

    [SerializeField] private Image sampleColorImage;

    private float r;
    private float g;
    private float b;
    #endregion

    public void OnEnable()
    {
        InitializeRGBScroll();
    }

    private void InitializeRGBScroll()
    {
        GameObject imagepanel = GameObject.FindWithTag("ImagePanel");
        if (!imagepanel.TryGetComponent<ImageColor>(out imageColor))
        {
            Debug.LogError("NONE SETIMAGE COLOR AS" + gameObject.name);
            return;
        }

        Color color = imageColor.GetRGBColor();
        SetScrollValueAndText(color);
    }

    private void SetScrollValueAndText(Color color)
    {
        redScroll.value = color.r;
        redText.text = ((int)(color.r * 255)).ToString();

        greenScroll.value = color.g;
        greenText.text = ((int)(color.g * 255)).ToString();

        blueScroll.value = color.b;
        blueText.text = ((int)(color.b * 255)).ToString();

        sampleColorImage.color = color;
    }

    public void OnScrollValueChanged()
    {
        Color color = new Color(redScroll.value, greenScroll.value, blueScroll.value);
        imageColor.SetRGBColor(color.r, color.g, color.b);
        SetScrollValueAndText(color);
    }
}
