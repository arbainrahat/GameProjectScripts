using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ScreenshotPreview : MonoBehaviour {

	
	[SerializeField]
	GameObject []Frame;     //Frames for Pictures
	[SerializeField] string[] files = null;
	int whichScreenShotIsShown= 0;

	// Use this for initialization
	//void Start () {
	//
	//	files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png");
	//	if (files.Length > 0) {
	//		GetPictureAndShowIt (Frame[0]);
	//	}
	//}
	private void Update()
	{
		files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png");

		try
		{
			//Set pictures To frames
			if (files[whichScreenShotIsShown] != null && whichScreenShotIsShown == 0)
			{
				GetPictureAndShowIt(Frame[whichScreenShotIsShown]);
				whichScreenShotIsShown++;
			}
			else if (files[whichScreenShotIsShown] != null && whichScreenShotIsShown == 1)
			{
				GetPictureAndShowIt(Frame[whichScreenShotIsShown]);
				whichScreenShotIsShown++;
			}
			else if (files[whichScreenShotIsShown] != null && whichScreenShotIsShown == 2)
			{
				GetPictureAndShowIt(Frame[whichScreenShotIsShown]);
				whichScreenShotIsShown++;
			}

		}
		catch(Exception e)
        {
			
        }
	}

		void GetPictureAndShowIt(GameObject canvas)
	    {
		string pathToFile = files [whichScreenShotIsShown];
		Texture2D texture = GetScreenshotImage (pathToFile);
		Sprite sp = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height),
			new Vector2 (0.5f, 0.5f));
		canvas.GetComponent<Image> ().sprite = sp;
	    }

	Texture2D GetScreenshotImage(string filePath)
	{
		Texture2D texture = null;
		byte[] fileBytes;
		if (File.Exists (filePath)) {
			fileBytes = File.ReadAllBytes (filePath);
			texture = new Texture2D (2, 2, TextureFormat.RGB24, false);
			texture.LoadImage (fileBytes);
		}
		return texture;
	}



	public void DeletPhotos()
    {
		for(int i = 0; i < 3; i++)
        {
			if (files.Length > 0)
			{
				string pathToFile = files[i];
				if (File.Exists(pathToFile))
				{
					File.Delete(pathToFile);
				}
				files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png");
			}
            else
            {
				whichScreenShotIsShown = 0;

			}

		}
	}



	//public void NextPicture()
	//{
	//	if (files.Length > 0) {
	//		whichScreenShotIsShown += 1;
	//		if (whichScreenShotIsShown > files.Length - 1)
	//			whichScreenShotIsShown = 0;
	//		GetPictureAndShowIt ();
	//	}
	//}
	//
	//public void PreviousPicture()
	//{
	//	if (files.Length > 0) {
	//		whichScreenShotIsShown -= 1;
	//		if (whichScreenShotIsShown < 0)
	//			whichScreenShotIsShown = files.Length - 1;
	//		GetPictureAndShowIt ();
	//	}
	//}


	//public void DeleteImage()
	//{
	//	if (files.Length > 0)
	//	{
	//		string pathToFile = files[whichScreenShotIsShown];
	//		if (File.Exists(pathToFile))
	//			File.Delete(pathToFile);
	//		files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png");
	//		if (files.Length > 0)
	//			NextPicture();
	//		else
	//			//canvas.GetComponent<Image>().sprite = defaultImage;
	//	}
	//}

		//	//Load Image
		//	public void LoadImage()
		//    {
		//		txt.text = Application.persistentDataPath;
		//		if (files.Length > 0)
		//        {
		//			txt.text = "Image Load";
		//			Debug.Log("Image File Load");
		//			GetPictureAndShowIt();
		//		}
		//
		//	}
}
