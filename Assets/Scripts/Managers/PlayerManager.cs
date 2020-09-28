using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int triesCount;
    [SerializeField] int totalScore;
    [SerializeField] int coins;

    public int TotalScore
    {
        get { return totalScore; }
        set { totalScore = value; }
    }

    public int TriesCount
    {
        get { return triesCount; }
        set { triesCount = value; }
    }

    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }
}
