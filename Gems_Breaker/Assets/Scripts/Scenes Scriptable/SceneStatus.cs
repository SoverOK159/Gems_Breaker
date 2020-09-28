using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName =("Scene"), menuName = ("Scenes"))]

public class SceneStatus : ScriptableObject
{

    [SerializeField] string sceneName;
    [SerializeField] int sceneIndex;
    [SerializeField] int triesForStage;

    [SerializeField] bool isOpen;
    [SerializeField] bool isComplete;

    [SerializeField] bool isOneStar;
    [SerializeField] bool isTwoStar;
    [SerializeField] bool isThreeStar;

    public string SceneName
    {
        get { return sceneName; }
    }

    public int SceneIndex
    {
        get { return sceneIndex; }
    }

    public int TriesForStage
    {
        get { return triesForStage; }
    }

    public bool IsOpen
    {
        get { return isOpen; }
        set { isOpen = value; }
    }

    public bool IsComplete
    {
        get { return isComplete; }
        set { isComplete = value; }
    }

    public bool IsOneStar
    {
        get { return isOneStar; }
        set { isOneStar = value; }
    }

    public bool IsTwoStar
    {
        get { return isTwoStar; }
        set { isTwoStar = value; }
    }

    public bool IsThreeStar
    {
        get { return isThreeStar; }
        set { isThreeStar = value; }
    }


}
