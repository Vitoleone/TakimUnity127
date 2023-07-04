using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private void Awake()
    {
        UIManager.instance.onScoreChanged += UpdateScoreValue;
    }

    void UpdateScoreValue()
    {
        UIManager.instance.scoreText.text = "Score: " + GameManager.instance.score;
    }
}
