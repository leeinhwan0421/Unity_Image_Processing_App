using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggedInfo
{
    private Vector2 mPosCur;   // 실시간(현재 프레임) 마우스 좌표
    private Vector2 mPosBegin; // 드래그 시작 지점 마우스 좌표
    private Vector2 mPosMin;   // Rect의 최소 지점 좌표
    private Vector2 mPosMax;   // Rect의 최대 지점 좌표

    public Vector2 PosMin { get { return mPosMin; } } 
    public Vector2 PosMax { get { return mPosMax; } }

    public int width { get { return (int)Mathf.Abs(PosMax.x - PosMin.x); } }
    public int height { get { return (int)Mathf.Abs(PosMax.y - PosMin.y); } }

    public void SetFirstPosition(Vector2 pos)
    {
        mPosBegin = pos;
    }

    public void UpdateCurrentPosition(Vector2 pos)
    {
        mPosCur = pos;

        mPosMin = Vector2.Min(mPosCur, mPosBegin);
        mPosMax = Vector2.Max(mPosCur, mPosBegin);
    }
}
