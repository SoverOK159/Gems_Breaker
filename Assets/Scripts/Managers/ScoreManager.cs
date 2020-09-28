using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    StageManager _stageManager;
    PlayerManager _playerManager;

    [SerializeField] int levelScore;
    [SerializeField] int totalPointsInLevel;

    [SerializeField] bool scoreAdded;

    private void Start()
    {
        _stageManager = FindObjectOfType<StageManager>();
        _playerManager = FindObjectOfType<PlayerManager>();

        scoreAdded = false;
        CalculateTotalPointsInLevel();
    }

    private void Update()
    {
        if (!scoreAdded)
        {
            if (_stageManager.IsStageEnd)
            {
                AddTotalScoreToPlayer();
                scoreAdded = true;
            }
        }
    }

    public int LevelScore
    {
        get { return levelScore; }
        set { levelScore = value; }
    }

    public int TotalPointsInLevel
    {
        get { return totalPointsInLevel; }
    }

    public void AddScoreToPlayer(int gemScore)
    {
        levelScore += gemScore;
        _stageManager.SetScoreText(levelScore);
    }

    public void AddTotalScoreToPlayer()
    {
        if (_stageManager.IsStageEnd)
        {
            _playerManager.TotalScore += levelScore;
        }
    }

    public void CalculateTotalPointsInLevel()
    {
        GameObject[] gems = GameObject.FindGameObjectsWithTag("Normal Gem");
        GameObject extraGem = GameObject.FindGameObjectWithTag("Extra Gem");

        foreach (var gem in gems)
        {
            totalPointsInLevel += gem.GetComponent<Gem>().ScorePoint;
        }
        totalPointsInLevel += extraGem.GetComponent<Gem>().ScorePoint;
    }

    
}
