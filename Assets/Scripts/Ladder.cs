using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Cat cat))
        {
            cat.onLedder = true;
            cat.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Cat cat))
        {
            cat.onLedder = false;
            cat.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.1f;
        }
    }
}
