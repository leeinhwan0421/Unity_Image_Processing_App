namespace OpenCvSharp.Demo
{
	using UnityEngine;
	using System.Collections;
	using OpenCvSharp;
	using UnityEngine.UI;

	public class GrayscaleImage 
	{
		public static Sprite SpriteToGrayScale(Sprite sprite) 
		{
			Mat mat = Unity.TextureToMat(sprite.texture);
			Mat grayMat = new Mat();
			Cv2.CvtColor(mat, grayMat, ColorConversionCodes.BGR2GRAY); 
			Texture2D texture = Unity.MatToTexture(grayMat);

            UnityEngine.Rect rect = new UnityEngine.Rect(0, 0, texture.width, texture.height);
            Sprite newSprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

            return newSprite;
        }
	}
}