using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartScreenUI : MonoBehaviour
{
    private void Awake()
    {
        UIManager.instance.onGameStart += StartGame;
    }

    void StartGame()
    {
        UIManager.instance.gameStartPanel.SetActive(false);
    }
}
