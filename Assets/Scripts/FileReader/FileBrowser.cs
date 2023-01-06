using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FileBrowser
{
    private string filePath;

    public static void Open()
    {
#if UNITY_EDITOR
        EditorUtility.OpenFilePanel("Select Image File", Application.streamingAssetsPath, "png");
#else
        

#endif
    }
}
