using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    private int currentSceneIndex;


    private void Start()
    {

    }

    public int GetCurrentSceneIndex()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        return currentSceneIndex;
    }

    public void LoadNextScne()
    {
        SceneManager.LoadScene(GetCurrentSceneIndex() + 1);
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(GetCurrentSceneIndex() - 1);
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(GetCurrentSceneIndex());
        FindObjectOfType<PlayerManager>().TriesCount = 3;
    }


}
