using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.FindObjectOfType(typeof(Cat)))
        {
            UIManager.instance.onScoreChanged += UpdateScoreValueForLevel1;
        }
        else if(GameObject.FindObjectOfType(typeof(Bird)))
        {
            UIManager.instance.onScoreChanged += UpdateScoreValueForLevel2;
        }
    }

    void UpdateScoreValueForLevel1()
    {
        UIManager.instance.scoreText.text = "Score: " + GameManager.instance.score;
    }
    void UpdateScoreValueForLevel2()
    {
        UIManager.instance.scoreText.text = "Score: " + GameManager.instance.score + " / " + "1500";
    }
}
