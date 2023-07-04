using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Bridge> bridgeParts;
    public int score = 0;
    public bool isPlayerAlive = true;
    public UnityAction playerDie;
    public Transform lastCheckpoint;

    public GameManager()
    {
        if (instance.IsUnityNull())
        {
            instance = this;
        }
    }

    public void ActiveAllBridgeParts()
    {
        foreach (var bridgePart in bridgeParts)
        {
            bridgePart.CancelInvoke();
            bridgePart.gameObject.SetActive(true);
        }
    }

    public void SetCheckPoint(Transform newCheckpoint)
    {
        lastCheckpoint = newCheckpoint;
    }
    
}
