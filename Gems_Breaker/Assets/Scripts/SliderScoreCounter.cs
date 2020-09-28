using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScoreCounter : MonoBehaviour
{

    [SerializeField] ScoreManager _scoreScript; // Script on object with score. Add here yor gameobject with score script.

    public Slider _slider; // Reference to slider

    [SerializeField] bool isFinished;

    [Header("Slider values")] 
    [SerializeField] int maxSliderValue; // Setup from script
    [SerializeField] float currentSliderValue; // // Setup from object with currentScore
    [SerializeField] [Range(1,20)] int sliderSpeed; // Setup from script

    public bool IsFinished
    {
        get { return isFinished; }
        set { isFinished = value; }
    }

    public void StartSlider()
    {
        _slider.maxValue = _scoreScript.TotalPointsInLevel;
        if (currentSliderValue < _scoreScript.LevelScore)
        {
            currentSliderValue += sliderSpeed * (Time.deltaTime * 100);
            _slider.value = currentSliderValue;
        }
        else
        {
            _slider.value = _scoreScript.LevelScore;
            currentSliderValue = _scoreScript.LevelScore;
            IsFinished = true;
        }

    }

    
}
