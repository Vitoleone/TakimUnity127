using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Level 1 Attributes")]
    public GameObject Cat;
    [Header("Level 2 Attributes")]
    public Transform birdSpawnPosition;
    public GameObject bird;
    
    private void Awake()
    {
        GameManager.instance.catDie += Spawn;
        GameManager.instance.birdDie += BirdSpawn;
    }

    public void Spawn()
    {
        if (!GameManager.instance.isPlayerAlive)
        {
            Instantiate(Cat, GameManager.instance.lastCheckpoint.transform.position, quaternion.identity);
            GameManager.instance.isPlayerAlive = true;
            GameManager.instance.ActiveAllBridgeParts();
        }
    }

    public void BirdSpawn()
    {
        if (!GameManager.instance.isPlayerAlive)
        {
            bird.gameObject.transform.position = birdSpawnPosition.position;
            GameManager.instance.isPlayerAlive = true;
            bird.gameObject.SetActive(true);
            
        }
    }
}
