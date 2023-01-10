using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Globalization;

public class ScreenShot : MonoBehaviour
{
    private string folderPath = "C:/Users/rltjd/OneDrive/사진/Saved Pictures/";
    private string filePath = "Unity_Picture";
    private string fileFormat = ".png";
    private int fileCount = 0;

    private void Awake()
    {
        if (Directory.Exists(folderPath) == false)
        {
            Directory.CreateDirectory(folderPath);
        }

        fileCount = Directory.GetFiles(folderPath, "*.png", SearchOption.AllDirectories).Length;
    }

    private void SaveScreenShotAsPNG(Queue<DraggedInfo> infos)
    {
        while (infos.Count != 0)
        {
            DraggedInfo info = infos.Dequeue();

            Texture2D screenTex = new Texture2D(info.width, info.height, TextureFormat.RGB24, false);

            Debug.Log("Min : " + info.PosMin);
            Debug.Log("Max : " + info.PosMax);

            Rect area = new Rect();
            area.min = new Vector2(info.PosMin.x, Screen.height - info.PosMax.y);
            area.max = new Vector2(info.PosMax.x, Screen.height - info.PosMin.y);

            screenTex.ReadPixels(area, 0, 0);

            if (Directory.Exists(folderPath) == false)
            {
                Directory.CreateDirectory(folderPath);
            }

            // 스크린샷 저장
            File.WriteAllBytes(folderPath + filePath + fileCount + fileFormat, screenTex.EncodeToPNG());
            fileCount++;

            Destroy(screenTex);
        }
    }

    private IEnumerator TakeScreenShotRoutine(Queue<DraggedInfo> infos, DraggedAction action)
    {
        yield return new WaitForEndOfFrame();

        SaveScreenShotAsPNG(infos);

        action.InitializeDraggedInfos();
    }

    public void SaveScreenShot(Queue<DraggedInfo> infos, DraggedAction action)
    {
        StartCoroutine(TakeScreenShotRoutine(infos, action));
    }
}