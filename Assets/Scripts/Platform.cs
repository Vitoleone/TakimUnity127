using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Platform : MonoBehaviour,IMovableEnviroment
{
    [SerializeField] private Transform point1;
    [SerializeField] private float timeToPoint1;
  
    // Update is called once per frame
    private void Start()
    {
        if (point1 != null)
        {
            Move();
        }
    }

    public void Move()
    {
        gameObject.transform.DOMove(point1.transform.position, timeToPoint1).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
