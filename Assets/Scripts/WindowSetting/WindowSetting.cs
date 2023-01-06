using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSetting : MonoBehaviour
{
    private bool isWindow = true;
    private int widthPixel = 1280;
    private int heightPixel = 720;

    private void Awake()
    {
        SetResolution();
    }

    public void SetResolution() => Screen.SetResolution(widthPixel, heightPixel, isWindow);

    public void SetResoulution(int width, int height, bool isWindow) => Screen.SetResolution(width, height, isWindow);
}
