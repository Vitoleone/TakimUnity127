using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.TryGetComponent(out IAnimal animal))
        {
            animal.Die();
        }
    }
}
