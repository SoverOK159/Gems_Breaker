using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    PlayerManager _playerManager;
    ScoreManager _scoreManager;
    SliderScoreCounter _sliderScoreCounter;

    [SerializeField] SceneStatus sceneStatus;
    [SerializeField] GameObject levelEndCanvas;
    [SerializeField] Button nextLevelButton;

    [SerializeField] bool isStageEnd;
    [SerializeField] bool isGemsExist;
    [SerializeField] bool levelConditionSetup;

    [SerializeField] int normalGemsInLevel;
    [SerializeField] int extraGemsInLevel;

    [SerializeField] Text scoreText;
    [SerializeField] Text triesText;

    [SerializeField] Text totalScoreText;
    [SerializeField] Text totalCoinsText;


    //TODO Change next level buton color when active and when not active

    private void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _sliderScoreCounter = FindObjectOfType<SliderScoreCounter>();

        _playerManager.TriesCount = sceneStatus.TriesForStage;

        levelEndCanvas.SetActive(false);

        normalGemsInLevel = GameObject.FindGameObjectsWithTag("Normal Gem").Length;
        extraGemsInLevel = GameObject.FindGameObjectsWithTag("Extra Gem").Length;

        SetScoreText(0);
        SetPlayerTries(_playerManager.TriesCount);

        SetTotalPlayerText(_playerManager.TotalScore, _playerManager.Coins);

        Debug.Log("Level Start");
    }

    private void Update()
    {       
        IsGemsExist();
        if (!isStageEnd)
        {
            CheckLevelCondition();
        }
        else
        {
            StartCoroutine("EndStage");
        }
    }

    public bool IsStageEnd 
    {
        get { return isStageEnd; }
        set { isStageEnd = value;}
    }

    public int NormalGemsInLevel
    {
        get { return normalGemsInLevel; }
        set { normalGemsInLevel = value; }
    }
    public int ExtraGemsInLevel
    {
        get { return extraGemsInLevel; }
        set { extraGemsInLevel = value; }
    }

    IEnumerator EndStage()
    {
        yield return new WaitForSeconds(1f);

        levelEndCanvas.SetActive(true);
        if (!_sliderScoreCounter.IsFinished)
        {
            if (GameObject.FindGameObjectWithTag("Ball") != null)
            {
                GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            if (!_sliderScoreCounter.IsFinished)
            {
                _sliderScoreCounter.StartSlider();
            }
            Debug.Log("Level End");
        }
        else
        {
            SetTotalPlayerText(_playerManager.TotalScore, _playerManager.Coins);
            OpenNextLevel();
        }
    }

    //TODO Refactor for all differnt gems in level
    private bool IsGemsExist()
    {
        if (normalGemsInLevel > 0 || extraGemsInLevel > 0)
        {
            isGemsExist = true;
        }
        else
        {
            isGemsExist = false;
        }
        return isGemsExist;
    }

    public void SetScoreText(int newScoreText)
    {
        scoreText.text = newScoreText.ToString();
    }
    
    public void SetPlayerTries(int newPlayerTries)
    {
        triesText.text = newPlayerTries.ToString();
    }

    

    //TODO Fix bug with score after death
    void CheckLevelCondition()
    {
        Debug.Log("Check level condition");
        if ((_playerManager.TriesCount <= 0 && GameObject.FindGameObjectWithTag("Ball") == null) || !isGemsExist)
        {
            isStageEnd = true;
        }
        else
        {
            isStageEnd = false;
            return;
        }
    }

    void SetTotalPlayerText(int score, int coins)
    {
        totalScoreText.text = score.ToString();
        totalCoinsText.text = coins.ToString();
    }

    void OpenNextLevel()
    {
        if(_scoreManager.LevelScore >= (_scoreManager.TotalPointsInLevel / 3))
        {
            //GameManager.Instance.GetSceneStatus(sceneStatus.SceneIndex - 1).IsOpen = true;
            GameManager.Instance.GetSceneStatus(sceneStatus.SceneIndex-2).IsComplete = true;
        }
        else
        {
            Debug.Log("Try one more time");
        }
    }
    
}
