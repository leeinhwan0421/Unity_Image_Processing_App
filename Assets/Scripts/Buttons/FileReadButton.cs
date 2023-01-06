using UnityEngine;
using System.Collections;
using System.IO;
using SimpleFileBrowser;

public sealed class FileReadButton : CustomButton
{
    public override void Init()
    {
        
    }

    public override void OnClick()
    {
        ShowFileBrowser();
    }

    public void ShowFileBrowser()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"));

        FileBrowser.SetDefaultFilter(".jpg");
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);

        StartCoroutine(ShowLoadDialogCoroutine());
    }

    IEnumerator ShowLoadDialogCoroutine()
    {
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files and Folders", "Load");

        if (FileBrowser.Success)
        {
            byte[] bytes = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result[0]);

            Sprite sprite = ConvertManager.ConvertByteArrayToSprite(bytes);

            GameObject imagePanel = GameObject.FindWithTag("ImagePanel");
            imagePanel.GetComponent<ShowImage>().SetImage(sprite);
        }
    }
}
