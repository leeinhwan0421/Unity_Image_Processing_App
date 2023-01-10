namespace OpenCvSharp.Demo
{
	using UnityEngine;
	using System.Collections;
	using OpenCvSharp;
	using UnityEngine.UI;

	public class EdgeDectectionImage 
	{
		public static Sprite SpriteToEdgeDectection(Sprite sprite) 
		{
			Mat mat = Unity.TextureToMat(sprite.texture);
			Mat egdeMat = new Mat();

            Cv2.Canny(mat, egdeMat, 50, 200);
            Texture2D texture = Unity.MatToTexture(egdeMat);

            UnityEngine.Rect rect = new UnityEngine.Rect(0, 0, texture.width, texture.height);
            Sprite newSprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

            return newSprite;
        }
	}
}