using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.Android;

public class ScreenshotHandler : MonoBehaviour
{
    private static ScreenshotHandler instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void TakeScreenshot()
    {

        instance.StartCoroutine(instance.SaveScreenshot());
    }

    private IEnumerator SaveScreenshot()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenTexture.Apply();

        string name = "Screenshot_Aruvana-" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";

        NativeGallery.SaveImageToGallery(screenTexture, "AruvanaScreenshot", name);

        new NativeShare().AddFile(screenTexture).Share();
    }
}