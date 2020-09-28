using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] SceneStatus[] _sceneStatus;
    
    public SceneStatus GetSceneStatus(int index)
    {
        return _sceneStatus[index];
    }


    private void Update()
    {
        //GetSceneStatus(1).IsOpen = true;
        //Debug.Log(GetSceneStatus(1).IsOpen);
    }

}
