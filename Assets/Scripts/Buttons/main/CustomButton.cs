using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomButton : MonoBehaviour, ButtonAction
{
    public void Awake()
    {
        Init();
    }

    public abstract void Init();

    public abstract void OnClick();
}
