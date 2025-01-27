using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class ScreenshotUploader : MonoBehaviour
{
    private string supabaseUrl = "https://rrcccyhuahxgxynuccpr.supabase.co/storage/v1/object";
    private string bucketName = "Screenshots";
    private string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InJyY2NjeWh1YWh4Z3h5bnVjY3ByIiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mzc5NDc3OTYsImV4cCI6MjA1MzUyMzc5Nn0.FU97QGlieoT7Z3ljFU7gtCs90GRni_iga3682KjWQDI";

    public PlayerDataManager playerDataManager;
    public CURD_Db firebase_db;

    private void Start()
    {
        TakeScreenshotAndUpload();
    }

    public void TakeScreenshotAndUpload()
    {
        StartCoroutine(CaptureAndUploadScreenshot());
    }

    private IEnumerator CaptureAndUploadScreenshot()
    {
        string fileName = $"Screenshot_{System.DateTime.Now:yyyyMMdd_HHmmss}.png";

        // Capture screenshot to Texture2D
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        ScreenCapture.CaptureScreenshotIntoRenderTexture(renderTexture);

        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();
        RenderTexture.active = null;

        byte[] screenshotBytes = screenshot.EncodeToPNG();

        Destroy(renderTexture);
        Destroy(screenshot);

        yield return StartCoroutine(UploadToSupabase(screenshotBytes, fileName));
    }

    private IEnumerator UploadToSupabase(byte[] fileData, string fileName)
    {
        string uploadUrl = $"{supabaseUrl}/{bucketName}/{fileName}";
        UnityWebRequest request = new UnityWebRequest(uploadUrl, "POST");

        request.SetRequestHeader("apikey", apiKey);
        request.SetRequestHeader("Authorization", $"Bearer {apiKey}");
        request.SetRequestHeader("Content-Type", "image/png");

        request.uploadHandler = new UploadHandlerRaw(fileData);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Screenshot uploaded successfully to {uploadUrl}");

            string publicUrl = $"{supabaseUrl}/public/{bucketName}/{fileName}";

            PlayerGameData playerData = playerDataManager.GetPlayerData();
            if (playerData != null)
            {
                playerData.Screenshots.Add(new PlayerGameData.Screenshot(fileName, publicUrl));
                PushPlayerDataToFirebase();
            }
            else
            {
                Debug.LogError("Player data is null. Unable to add screenshot.");
            }
        }
        else
        {
            Debug.LogError($"Failed to upload screenshot: {request.error}");
            Debug.LogError($"Response: {request.downloadHandler.text}");
        }
    }

    private void PushPlayerDataToFirebase()
    {
        firebase_db.PushPlayerData();
    }
}
