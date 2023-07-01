using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public bool isPlayerAlive = true;
    public UnityAction playerDie;

    public GameManager()
    {
        if (instance.IsUnityNull())
        {
            instance = this;
        }
    }
    
}
