using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //Level 1 Attributes
    [Header("Level 1 Attributes")]
    public List<Bridge> bridgeParts;
    public Transform lastCheckpoint;
    public UnityAction catDie;
    //Level 2 Attributes
    [Header("Level 2 Attributes")]
    public float moveSpeed;
    private float timer;
    private int obstacleCreated;
    public List<GameObject> Obstacles;
    public UnityAction birdDie;
    public bool isGameStarted;
    //General Attributes
    [Header("General Attributes")]
    public int score = 0;
    public bool isPlayerAlive = true;
    
    public GameManager()
    {
        instance = this;
    }
    

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2 && isGameStarted)
        {
            SpawnRandomObstacle();
        }
        if (obstacleCreated >= 4 && isGameStarted)
        {
            IncreaseMoveSpeed();
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

    public void IncreaseMoveSpeed()
    {
        if (isPlayerAlive && Obstacles.Count >= 1)
        { 
            moveSpeed += 2f;
            obstacleCreated = 0;
        }
    }

    void SpawnRandomObstacle()
    {
        if (isPlayerAlive && Obstacles.Count >= 1)
        {
            int random = Random.Range(0, Obstacles.Capacity);
            Instantiate(Obstacles[random], transform.position, quaternion.identity);
            obstacleCreated++;
            timer = 0;
        }
       
    }
    
}
