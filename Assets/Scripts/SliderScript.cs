using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Text totalPlayerScoreText;
    [SerializeField] int sliderMaxValue;
    [SerializeField] int counter = 0;
    [SerializeField] int sliderSpeed;
    public bool sliderStart;
    

    private void Start()
    {
        sliderStart = false;
    }

    private void Update()
    {
        sliderMaxValue = FindObjectOfType<ScoreManager>().TotalPointsInLevel;
        slider.maxValue = sliderMaxValue;
        sliderSpeed = FindObjectOfType<ScoreManager>().LevelScore / 2;
    }

    private void FixedUpdate()
    {    
        if (sliderStart)
        {
            StartSlider();
        }
    }

    void StartSlider()
    {
        if(counter != FindObjectOfType<ScoreManager>().LevelScore)
        {
            counter = counter + 1 * Mathf.RoundToInt(Time.deltaTime * sliderSpeed) ;
            slider.value = counter;
            totalPlayerScoreText.text = ((FindObjectOfType<PlayerManager>().TotalScore + counter)).ToString();
        }
        else
        {
            //FindObjectOfType<PlayerManager>().TotalScore = FindObjectOfType<PlayerManager>().TotalScore + FindObjectOfType<ScoreManager>().LevelScore;
            sliderStart = false;
        }
    }
}
