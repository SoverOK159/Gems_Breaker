using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    LevelsManager levelsManager;

    [SerializeField] SceneStatus[] sceneStatus;
    [SerializeField] Button levelButtonPrefab;
    [SerializeField] Transform levelButtonParent;

    [SerializeField] GameObject levelSelectPanel;

    [SerializeField] Text playerScore;
    [SerializeField] Text playerCoins;

    [SerializeField] Sprite closedLevel;


    private void Start()
    {
        levelsManager = FindObjectOfType<LevelsManager>();

        levelSelectPanel.SetActive(false); // hide select level screen on start

        OpenScenes();

        //SetUpUI();
        SetUpLevelButton();
    }

    private void Update()
    {
        SetUpUI();
    }

    // Setup and create level select button
    void SetUpLevelButton()
    {
        foreach (SceneStatus scenes in sceneStatus)
        {
            Button button = Instantiate(levelButtonPrefab, levelButtonParent);
            button.GetComponentInChildren<Text>().text = scenes.SceneName;
            button.onClick.AddListener(() => levelsManager.LoadSceneByIndex(scenes.SceneIndex));
            if (!scenes.IsOpen)
            {
                button.image.sprite = closedLevel;
                button.GetComponentInChildren<Text>().enabled = false;
                button.enabled = false;
            }
        }
    }

    void ShowPlayerScore(int totalScore)
    {
        playerScore.text = totalScore.ToString();
    }

    void ShowPlayerCoins(int totalCoins)
    {
        playerCoins.text = totalCoins.ToString();
    }

    void SetUpUI()
    {
        if (playerScore != null && playerCoins != null)
        {
            ShowPlayerScore(FindObjectOfType<PlayerManager>().TotalScore);
            ShowPlayerCoins(FindObjectOfType<PlayerManager>().Coins);
        }
        else { return; }
    }

    public void OpenSelectLevelPanel()
    {
        levelSelectPanel.SetActive(true);
    }

    public void OpenScenes()
    {
        for (int i = 0; i < sceneStatus.Length; i++)
        {
            if (sceneStatus[i].IsComplete)
            {
                sceneStatus[i + 1].IsOpen = true;
            }
            else
            {
                return;
            }
        }
    }
}
