using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class CURD_Db : MonoBehaviour
{
    private DatabaseReference databaseReference;
    public PlayerDataManager playerDataManager;

    void Start()
    {
        InitializeFirebase();
    }

    private void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Firebase dependencies check failed.");
                return;
            }

            string databaseUrl = "https://cosmicmathquests-default-rtdb.asia-southeast1.firebasedatabase.app/";
            FirebaseDatabase database = FirebaseDatabase.GetInstance(app, databaseUrl);
            databaseReference = database.RootReference;

            Debug.Log("Firebase Auth and Database Initialized");
        });
    }

    public void PushPlayerData()
    {
        PlayerGameData playerGameData = playerDataManager.GetPlayerData();

        if (playerGameData != null && !string.IsNullOrEmpty(playerGameData.UserID))
        {
            string userId = playerGameData.UserID;
            string path = "players/" + userId;
            string json = JsonUtility.ToJson(playerGameData);
            databaseReference.Child(path).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    Debug.Log("Player data pushed to Firebase successfully.");
                }
                else
                {
                    Debug.LogError($"Failed to push player data: {task.Exception}");
                }
            });
        }
        else
        {
            Debug.LogError("PlayerGameData is null or UserID is empty.");
        }
    }

    public void RetrievePlayerData()
    {
        PlayerGameData playerGameData = playerDataManager.GetPlayerData();

        if (playerGameData != null && !string.IsNullOrEmpty(playerGameData.UserID))
        {
            string userId = playerGameData.UserID;

            databaseReference.Child("players").Child(userId).GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    DataSnapshot snapshot = task.Result;

                    if (snapshot.Exists)
                    {
                        string json = snapshot.GetRawJsonValue();
                        playerGameData = JsonUtility.FromJson<PlayerGameData>(json);
                        Debug.Log("Player data retrieved successfully.");
                    }
                    else
                    {
                        Debug.LogWarning("Player data does not exist in the database.");
                    }
                }
                else
                {
                    Debug.LogError($"Failed to retrieve player data: {task.Exception}");
                }
            });
        }
        else
        {
            Debug.LogError("PlayerGameData is null or UserID is empty.");
        }
    }
}
