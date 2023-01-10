using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSetting : MonoBehaviour
{
    private bool isFullScreen = false;
    private int widthPixel = 1600;
    private int heightPixel = 900;

    private void Awake()
    {
        SetResolution();
    }

    public void SetResolution() => Screen.SetResolution(widthPixel, heightPixel, isFullScreen);

    public void SetResoulution(int width, int height, bool isWindow) => Screen.SetResolution(width, height, isWindow);
}
