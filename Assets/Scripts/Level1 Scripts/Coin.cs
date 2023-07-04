using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour,ICollectable
{
    public int score = 100;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IAnimal animal))
        {
            Collect(animal);
        }
    }

    public void Collect(IAnimal animal)
    {
        animal.GetScore(score);
        Destroy(gameObject);
    }
}
