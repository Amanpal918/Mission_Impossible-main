using UnityEngine;
using System.Collections;

public class ShareScreenShot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Takescreenshot()
    {
        StartCoroutine(Capture());
    }
      IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();

        string fileName = "Screenshot_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
        string path = Application.persistentDataPath + "/" + fileName;

        ScreenCapture.CaptureScreenshot(path);

        Debug.Log("Screenshot saved at: " + path);
    }
}
