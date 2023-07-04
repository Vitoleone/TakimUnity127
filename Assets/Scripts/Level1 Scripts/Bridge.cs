using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bridge : MonoBehaviour,IDestructable
{
    private void Awake()
    {
        GameManager.instance.bridgeParts.Add(this);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.TryGetComponent(out IAnimal animal))
        {
            Invoke(nameof(Destruct),0.5f);
        }
    }
    public void Destruct()
    {
        gameObject.SetActive(false);
    }
    
}
