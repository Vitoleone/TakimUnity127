using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IAnimal player))
        {
            GameManager.instance.SetCheckPoint(transform);
            UIManager.instance.onReachCheckpoint?.Invoke();
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
