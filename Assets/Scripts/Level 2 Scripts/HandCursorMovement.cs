using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HandCursorMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(Vector3.one * 1.5f, 0.6f).SetLoops(-1, LoopType.Yoyo);
    }

    
}
