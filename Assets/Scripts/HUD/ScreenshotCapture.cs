using UnityEngine;
using System.IO;

public class ScreenshotCapture : MonoBehaviour
{
    private string screenshotFolderPath;

    private void Awake()
    {
        // Check if there's already an instance of the script in the scene
        ScreenshotCapture[] existingInstances = FindObjectsOfType<ScreenshotCapture>();
        if (existingInstances.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        // Keep the GameObject with this script alive across scenes
        DontDestroyOnLoad(gameObject);

        // Create the "Screenshots" folder if it doesn't exist
        screenshotFolderPath = Application.dataPath + "/Screenshots";
        if (!Directory.Exists(screenshotFolderPath))
        {
            Directory.CreateDirectory(screenshotFolderPath);
        }
    }

    private void Update()
    {
        // Check if the "S" key is pressed
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Capture a screenshot and save it in the "Screenshots" folder
            string screenshotName = "Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
            string screenshotPath = Path.Combine(screenshotFolderPath, screenshotName);
            ScreenCapture.CaptureScreenshot(screenshotPath);
            Debug.Log("Screenshot captured: " + screenshotPath);
        }
    }
}