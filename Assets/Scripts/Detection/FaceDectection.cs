namespace OpenCvSharp.Demo
{
	using System;
	using System.IO;
	using System.Collections.Generic;
	using OpenCvSharp;
	using OpenCvSharp.Face;
	using UnityEngine.UI;
	using UnityEngine;

	public class FaceDectection : UnityEngine.MonoBehaviour
	{
		public UnityEngine.TextAsset faces;
		public UnityEngine.TextAsset recognizerXml;

		private CascadeClassifier cascadeFaces;
		private FaceRecognizer recognizer;

		private readonly Size requiredSize = new Size(128, 128);

		#region Face recognizer training
		private void TrainRecognizer(string root)
		{
			int id = 0;
			var ids = new List<int>();
			var mats = new List<Mat>();
			var namesList = new List<string>();
			
			foreach (string dir in Directory.GetDirectories(root))
			{
				string name = System.IO.Path.GetFileNameWithoutExtension(dir);
				if (name.StartsWith("-"))
					continue;

				namesList.Add(name);
				UnityEngine.Debug.LogFormat("{0} = {1}", id, name);

				foreach (string file in Directory.GetFiles(dir))
				{
					var bytes = File.ReadAllBytes(file);
					var texture = new UnityEngine.Texture2D(2, 2);
					texture.LoadImage(bytes);

					ids.Add(id);

					var mat = Unity.TextureToMat(texture);
					mat = mat.CvtColor(ColorConversionCodes.BGR2GRAY);
					if (requiredSize.Width > 0 && requiredSize.Height > 0)
						mat = mat.Resize(requiredSize);
					mats.Add(mat);
				}
				id++;
			}

			recognizer.Train(mats, ids);
			recognizer.Save(root + "/human-recognizer.xml");
		}
		#endregion

		protected virtual void Awake()
		{
			FileStorage storageFaces = new FileStorage(faces.text, FileStorage.Mode.Read | FileStorage.Mode.Memory);
			cascadeFaces = new CascadeClassifier();
			if (!cascadeFaces.Read(storageFaces.GetFirstTopLevelNode()))
				throw new System.Exception("FaceProcessor.Initialize: Failed to load faces cascade classifier");

			recognizer = FaceRecognizer.CreateFisherFaceRecognizer();
			recognizer.Load(new FileStorage(recognizerXml.text, FileStorage.Mode.Read | FileStorage.Mode.Memory));
		}

		public void Detection(Image imageSource)
		{
            Mat image = Unity.TextureToMat(imageSource.sprite.texture);

            var gray = image.CvtColor(ColorConversionCodes.BGR2GRAY);
            Cv2.EqualizeHist(gray, gray);

            OpenCvSharp.Rect[] rawFaces = cascadeFaces.DetectMultiScale(gray, 1.1, 6);

            foreach (var faceRect in rawFaces)
            {
                var grayFace = new Mat(gray, faceRect);
                if (requiredSize.Width > 0 && requiredSize.Height > 0)
                    grayFace = grayFace.Resize(requiredSize);
				recognizer.Predict(grayFace, out _, out _);

				Scalar frameColor = Scalar.Red;
                Cv2.Rectangle((InputOutputArray)image, faceRect, frameColor, 2);
            }

            // Render texture
            var texture = Unity.MatToTexture(image);
            UnityEngine.Rect rect = new UnityEngine.Rect(0, 0, texture.width, texture.height);
            Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

            imageSource.sprite = sprite;
        }
    }
}