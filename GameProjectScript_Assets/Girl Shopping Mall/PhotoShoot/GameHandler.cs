using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameHandler : MonoBehaviour
{
    public UnityEvent AfterShoot;

    [SerializeField]
    GameObject blink;

   [SerializeField] int counter = 0;


    //  void Update()
    //  {
    //      if (Input.GetKeyDown(KeyCode.Space))
    //      {
    //          ScreenshotHandler.TakeScreenshot_Static(1280, 720);
    //      }
    //  }

    private void Update()
    {
        if (counter >2)
        {
            Invoke("Fun", 2f);
        }
    }

    public void TakeShot()
    {
        if (counter < 3)
        {
            StartCoroutine("CaptureIt");
            counter++;
        }
    }

    IEnumerator CaptureIt()
    {
        blink.SetActive(true);
        ScreenshotHandler.TakeScreenshot_Static(2560, 1440);
        yield return new WaitForSeconds(0.04f);
        blink.SetActive(false);
    }

    void Fun()
    {
        counter = 0;
        AfterShoot.Invoke();
    }
}
