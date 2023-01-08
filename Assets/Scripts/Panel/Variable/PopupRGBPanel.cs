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

    private float r;
    private float g;
    private float b;
    #endregion

    public void Start()
    {
        InitializeRGBScroll();
    }

    public void InitializeRGBScroll()
    {
        GameObject imagepanel = GameObject.FindWithTag("ImagePanel");
        imageColor = imagepanel.GetComponent<ImageColor>();

        if (imageColor == null)
        {
            Debug.LogError("NONE SETIMAGE COLOR AS" + gameObject.name);
            return;
        }

        Color color = imageColor.GetRGBColor();

        redScroll.value = color.r;
        redText.text = (color.r * 255).ToString();

        greenScroll.value = color.g;
        greenText.text = (color.g * 255).ToString();

        blueScroll.value = color.b;
        blueText.text = (color.b * 255).ToString();
    }

    public void MoveedScroll(float value)
    {

    }
}
