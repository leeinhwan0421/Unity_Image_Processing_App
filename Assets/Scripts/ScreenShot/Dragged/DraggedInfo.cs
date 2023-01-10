using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggedInfo
{
    private Vector2 mPosCur;   // �ǽð�(���� ������) ���콺 ��ǥ
    private Vector2 mPosBegin; // �巡�� ���� ���� ���콺 ��ǥ
    private Vector2 mPosMin;   // Rect�� �ּ� ���� ��ǥ
    private Vector2 mPosMax;   // Rect�� �ִ� ���� ��ǥ

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
