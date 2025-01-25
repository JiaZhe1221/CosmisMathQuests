using System;
using System.Collections.Generic;

[System.Serializable]
public class PlayerGameData
{ 
    public string UserID;
    public string Username;
    public string Email;
    public string Avatar;
    public string DisplayName;
    public string Bio;

    public List<PlanetProgress> Planets = new List<PlanetProgress>();

    public float AudioVolume;

    public float TimePlayed;

    public PlayerGameData(string userID, string username, string email)
    {
        UserID = userID;
        Username = username;
        Email = email;
        Avatar = "";
        DisplayName = "";
        Bio = "";
        AudioVolume = 1.0f;
        TimePlayed = 0f;

        for (int i = 1; i <= 4; i++)
        {
            Planets.Add(new PlanetProgress($"Planet {i}"));
        }
    }

    [System.Serializable]
    public class PlanetProgress
    {
        public string PlanetName;
        public float TimeTaken;

        public PlanetProgress(string planetName)
        {
            PlanetName = planetName;
            TimeTaken = 0f;
        }
    }
}
