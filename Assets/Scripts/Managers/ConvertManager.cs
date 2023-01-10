using System;
using System.Collections.Generic;
using UnityEngine;

public class ConvertManager
{
    #region Byte - Sprite - texture - byte // cycle
    public static Sprite ConvertByteArrayToSprite(byte[] bytes)
    {
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        texture.Apply(true);

        Rect rect = new Rect(0, 0, texture.width, texture.height);
        Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        return sprite;
    }

    public static Texture2D ConvertSpriteToTexture(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                         (int)sprite.textureRect.y,
                                                         (int)sprite.textureRect.width,
                                                         (int)sprite.textureRect.height);
            newText.SetPixels(newColors);
            newText.Apply();
            return newText;
        }
        else
            return sprite.texture;
    }
    #endregion
}
