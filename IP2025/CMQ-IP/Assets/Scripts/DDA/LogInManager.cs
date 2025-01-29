/*
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using System.Threading.Tasks;
using Firebase;

public class LoginManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private DatabaseReference databaseReference;
    public PlayerGameData playerData;

    private void Start()
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

            auth = FirebaseAuth.DefaultInstance;
            string databaseUrl = "https://cosmicmathquests-default-rtdb.asia-southeast1.firebasedatabase.app/";
            FirebaseDatabase database = FirebaseDatabase.GetInstance(app, databaseUrl);
            databaseReference = database.RootReference;

            Debug.Log("Firebase Auth and Database Initialized");

            // Test
            test();

        });
    }

    public async void test()
    {
        string email = "jansonleong2005@gmail.com";
        string password = "ABC1234567";

        string result = await Login(email, password);
        Debug.Log(result);
    }

    public async Task<string> Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            return "Email and Password cannot be empty.";
        }

        try
        {
            var signInResult = await auth.SignInWithEmailAndPasswordAsync(email, password);
            if (signInResult != null)
            {
                string userID = signInResult.User.UserId;
                await RetrievePlayerData(userID);
                Debug.Log(playerData.UserID);
                return "Login successful!";
            }
            else
            {
                return "Invalid credentials. Please check your email and password.";
            }
        }
        catch
        {
            return "Invalid credentials. Please check your email and password.";
        }
    }

    private async Task RetrievePlayerData(string userID)
    {
        var playerDataTask = databaseReference.Child("players").Child(userID).GetValueAsync();

        await playerDataTask;

        if (playerDataTask.IsCompleted)
        {
            DataSnapshot snapshot = playerDataTask.Result;

            if (snapshot.Exists)
            {
                playerData = JsonUtility.FromJson<PlayerGameData>(snapshot.GetRawJsonValue());
                PlayerDataManager.Instance.SetPlayerData(playerData);

                Debug.Log("Player data retrieved successfully.");
            }
            else
            {
                Debug.LogError("Player data not found in the database.");
            }
        }
        else
        {
            Debug.LogError("Failed to retrieve player data.");
        }
    }

}
*/