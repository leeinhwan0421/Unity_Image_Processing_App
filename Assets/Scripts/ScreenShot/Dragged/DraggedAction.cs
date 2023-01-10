using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggedAction : MonoBehaviour
{
    private Queue<DraggedInfo> draggedInfos;
    DraggedInfo info;

    private GUIStyle currentStyle;

    private Vector2 mPosCur;
    private bool showSelection;

    public void Awake()
    {
        draggedInfos = new Queue<DraggedInfo>();
    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }

    public void InitializeDraggedInfos()
    {
        draggedInfos.Clear();
    }

    public void SaveScreenShotWithDrawAction()
    {
        if (draggedInfos == null)
            return;
        else if (draggedInfos.Count == 0)
            return;

        GameObject screenShot = GameObject.FindWithTag("ScreenShot");
        screenShot.GetComponent<ScreenShot>().SaveScreenShot(draggedInfos, this);
    }

    private void Update()
    {
        if (info != null && Input.GetMouseButtonUp(0))
        {
            if (Vector2.Distance(info.PosMin, info.PosMax) >= 100)
                draggedInfos.Enqueue(info);

            info = null;
        }

        showSelection = Input.GetMouseButton(0);
        if (!showSelection) return;

        mPosCur = Input.mousePosition;
        mPosCur.y = Screen.height - mPosCur.y; // Y 좌표(상하) 반전

        if (Input.GetMouseButtonDown(0))
        {
            info = new DraggedInfo();
            info.SetFirstPosition(mPosCur);
        }

        info.UpdateCurrentPosition(mPosCur);
    }

    private void OnGUI()
    {
        var draggedInfos = this.draggedInfos.ToArray();

        if (currentStyle == null)
        {
            currentStyle = new GUIStyle(GUI.skin.box);
            currentStyle.normal.background = MakeTex(2, 2, new Color(1f, 0f, 0f, 0.3f));
        }
        for (int i = 0; i < draggedInfos.Length; i++)
        {
            Rect rect = new Rect();
            rect.min = draggedInfos[i].PosMin;
            rect.max = draggedInfos[i].PosMax;

            GUI.Box(rect, "", currentStyle);
        }

        if (!showSelection && info == null) return;

        Rect rectInfo = new Rect();
        rectInfo.min = info.PosMin;
        rectInfo.max = info.PosMax;

        GUI.Box(rectInfo, "", currentStyle);
    }
}
