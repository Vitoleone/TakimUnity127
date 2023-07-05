using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Obstacle : MonoBehaviour,IMovableEnviroment
{
    void Update()
    {
        if (GameManager.instance.isPlayerAlive)
        {
            Move();    
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IAnimal bird))
        {
            
            bird.Die();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        transform.position += Vector3.left * (GameManager.instance.moveSpeed * Time.deltaTime);
    }
}
