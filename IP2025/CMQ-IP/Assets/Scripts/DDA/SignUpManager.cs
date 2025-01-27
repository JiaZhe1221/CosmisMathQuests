/*
using System;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Database;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class SignUpManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private DatabaseReference databaseReference;

    public string emailInputField;
    public string passwordInputField;
    public string nameInputField;

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
        string reenterPassword = "ABC1234567";
        string name = "jiazhe1221";

        string result = await SignUp(email, password, reenterPassword, name);
        Debug.Log(result);
    }

    // Sign up function
    public async Task<string> SignUp(string email, string password, string reenterPassword, string name)
    {
        if (auth == null)
        {
            Debug.LogError("FirebaseAuth is not initialized.");
            return "Firebase Authentication is not initialized.";
        }

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(reenterPassword))
        {
            return "Email, Password, and Name fields must not be empty.";
        }

        if (!IsPasswordValid(password))
        {
            return "Password must be at least 8 characters long and include at least one letter and one number.";
        }

        if (password != reenterPassword)
        {
            return "Passwords do not match. Please try again.";
        }

        if (name.Length < 3)
        {
            return "Name must be at least 3 characters long.";
        }

        var nameCheckTask = databaseReference.Child("players").OrderByChild("Username").EqualTo(name).GetValueAsync();
        var emailCheckTask = databaseReference.Child("players").OrderByChild("Email").EqualTo(email).GetValueAsync();

        await Task.WhenAll(nameCheckTask, emailCheckTask);

        DataSnapshot nameSnapshot = nameCheckTask.Result;
        DataSnapshot emailSnapshot = emailCheckTask.Result;

        if (nameSnapshot.Exists)
        {
            return "This name is already taken. Please choose another name.";
        }

        if (emailSnapshot.Exists)
        {
            return "This email is already registered. Please use a different email.";
        }

        CreateAccountWithName(email, password, name);

        return "SignUp successful!";
    }

    // Create user in Firebase Authentication and save player data
    private void CreateAccountWithName(string email, string password, string name)
    {
        if (auth == null)
        {
            Debug.LogError("FirebaseAuth is not initialized.");
            return;
        }

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("SignUp was canceled.");
                return;
            }
            else if (task.IsFaulted)
            {
                Debug.LogError("SignUp encountered an error: " + task.Exception?.Flatten().Message);
                return;
            }

            FirebaseUser newUser = task.Result.User;
            Debug.Log($"User signed up successfully. User ID: {newUser.UserId}");

            PlayerGameData newPlayerData = new PlayerGameData(newUser.UserId, name, email);
            CreateNewPlayer(newPlayerData);
        });
    }

    // Create new player in Firebase Realtime Database
    private void CreateNewPlayer(PlayerGameData playerData)
    {
        string path = "players/" + playerData.UserID;

        string json = JsonUtility.ToJson(playerData);
        databaseReference.Child(path).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Player data saved successfully.");
            }
            else
            {
                Debug.LogError("Failed to save player data: " + task.Exception?.Flatten().Message);
            }
        });
    }

    // Password validation function
    private bool IsPasswordValid(string password)
    {
        string pattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
        return Regex.IsMatch(password, pattern);
    }
}
*/