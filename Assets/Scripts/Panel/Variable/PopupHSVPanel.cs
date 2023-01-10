using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

using UnityEngine.UI;

public class PopupHSVPanel : MonoBehaviour
{
    private ImageColor imageColor;

    [SerializeField] private Scrollbar hueScroll;
    [SerializeField] private Text hueText;

    [SerializeField] private Scrollbar saturationScroll;
    [SerializeField] private Text saturationText;

    [SerializeField] private Scrollbar valueScroll;
    [SerializeField] private Text valueText;

    [SerializeField] private Image sampleColorImage;

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
        Color hsvColor;
        ColorManager.RGBToHSV(color, out hsvColor);
        SetScrollValueAndText(hsvColor);
    }

    private void SetScrollValueAndText(Color color)
    {
        hueScroll.value = color.r;
        hueText.text = ((int)(color.r * 360)).ToString();

        saturationScroll.value = color.g;
        saturationText.text = ((int)(color.g * 100)).ToString();

        valueScroll.value = color.b;
        valueText.text = ((int)(color.b * 100)).ToString();

        Color rgbColor;
        ColorManager.HSVToRGB(color, out rgbColor);
        sampleColorImage.color = rgbColor;
    }

    public void OnScrollValueChanged()
    {
        Color color = new Color(hueScroll.value, saturationScroll.value, valueScroll.value);

        Color rgbColor;
        ColorManager.HSVToRGB(color, out rgbColor);

        imageColor.SetRGBColor(rgbColor.r, rgbColor.g, rgbColor.b);
        SetScrollValueAndText(color);
    }
}
