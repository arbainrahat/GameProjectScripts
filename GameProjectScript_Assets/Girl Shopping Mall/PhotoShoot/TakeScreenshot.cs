using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour {

	[SerializeField]
	//GameObject blink;

	public void TakeAShot()
	{
		StartCoroutine ("CaptureIt");
	}

	IEnumerator CaptureIt()
	{
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot" + timeStamp + ".png";
		string pathToSave = fileName;
		ScreenCapture.CaptureScreenshot(pathToSave);
		
		yield return new WaitForEndOfFrame();
		//Instantiate (blink, new Vector2(0f, 0f), Quaternion.identity);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Saved CameraScreenshot.png");

			string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
			string fileName = "Screenshot" + timeStamp + ".png";
			string pathToSave = fileName;
			ScreenCapture.CaptureScreenshot(pathToSave);
		}
	}

	public void TakePhoto()
    {
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot" + timeStamp + ".png";
		string pathToSave = fileName;
		ScreenCapture.CaptureScreenshot(pathToSave);
	}
}
