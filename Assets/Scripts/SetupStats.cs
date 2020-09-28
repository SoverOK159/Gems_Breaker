using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupStats : MonoBehaviour
{
    PlayerManager playerManager;

    [SerializeField] int startScore = 0;
    [SerializeField] int startCoins = 0;
    [SerializeField] int startTries = 3;

    [SerializeField] bool isFirstStart;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        CheckForFirstStart();
    }

    public bool IsFirstStart
    {
        get { return isFirstStart; }
    }

    void CheckForFirstStart()
    {
        if (PlayerPrefs.HasKey("SaveGame"))
        {
            //TODO Load all stats from player prefs
            isFirstStart = false;
        }
        else
        {
            // TODO Setup first start stats
            SetupPlayerStats(startScore, startCoins, startTries);
            isFirstStart = true;
        }
    }

    void SetupPlayerStats(int totalScore, int totalCoins, int totalTries)
    {
        SetupPlayerScore(totalScore);
        SetupPlayerCoins(totalCoins);
        SetupTriesCount(totalTries);
    }

    void SetupPlayerScore(int totalScore)
    {
        if(playerManager != null)
        {
            playerManager.TotalScore = totalScore;
        }
        else { return; }
    }

    void SetupPlayerCoins(int totalCoins)
    {
        if (playerManager != null)
        {
            playerManager.Coins = totalCoins;
        }
        else { return; }
    }

    void SetupTriesCount(int totalTriesCount)
    {
        if (playerManager != null)
        {
            playerManager.TriesCount = totalTriesCount;
        }
        else { return; }
    }
}
