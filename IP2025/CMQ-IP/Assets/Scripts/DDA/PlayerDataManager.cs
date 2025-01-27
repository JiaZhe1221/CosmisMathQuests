using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance { get; private set; }
    public PlayerGameData playerData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public PlayerGameData GetPlayerData()
    {
        return playerData;
    }

    public void SetPlayerData(PlayerGameData newPlayerData)
    {
        playerData = newPlayerData;
    }
}
