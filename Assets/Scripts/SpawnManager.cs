using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Cat;

    private void Awake()
    {
        GameManager.instance.playerDie += Spawn;
    }

    public void Spawn()
    {
        if (!GameManager.instance.isPlayerAlive)
        {
            Instantiate(Cat, transform.position, quaternion.identity);
            GameManager.instance.isPlayerAlive = true;
        }
    }
}
