using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileReadButton : CustomButton
{
    public override void Init() { }

    public override void OnClick()
    {
        FileBrowser.Open();
    }
}
