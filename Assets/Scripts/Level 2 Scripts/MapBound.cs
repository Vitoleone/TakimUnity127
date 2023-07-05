using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Bird bird))
        {
            bird.Die();
        }
    }
}
