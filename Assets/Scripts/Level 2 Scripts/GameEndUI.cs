using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{

    private void Awake()
    {
        Time.timeScale = 1;
        
        if (GameObject.FindObjectOfType(typeof(Cat)))
        {
            UIManager.instance.onGameEnd += GameEndLevel1;
        }
        else if(GameObject.FindObjectOfType(typeof(Bird)))
        {
            UIManager.instance.onGameEnd += GameEndLevel2;
        }
    }
    void GameEndLevel1()
    {
        Time.timeScale = 0;
        UIManager.instance.gameEndPanel.SetActive(true);
        gameObject.SetActive(true);
    }
    void GameEndLevel2()
    {
        
        if (GameManager.instance.score >= 1500 && GameManager.instance.isPlayerAlive)
        {
            Time.timeScale = 0;
            UIManager.instance.gameEndPanel.SetActive(true);
            UIManager.instance.gameEndText.text = " ";
            UIManager.instance.tryagainButton.gameObject.SetActive(false);
            UIManager.instance.nextLevelButton.gameObject.SetActive(true);
            UIManager.instance.levelClearedImage.gameObject.SetActive(true);
            
            gameObject.SetActive(true);
        }
        else if (GameManager.instance.isPlayerAlive == false)
        {
            Time.timeScale = 0;
            UIManager.instance.gameEndPanel.SetActive(true);
            UIManager.instance.gameEndText.text = "Game Over";
            UIManager.instance.tryagainButton.gameObject.SetActive(true);
            UIManager.instance.nextLevelButton.gameObject.SetActive(false);
            UIManager.instance.levelClearedImage.gameObject.SetActive(false);
            
            gameObject.SetActive(true);
        }
    }
    
}
