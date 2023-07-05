using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Bird : MonoBehaviour,IAnimal
{
    private Rigidbody2D myRb;
    public float jumpPower;
    private float baseGravityScale;
    public float fallGravityScale;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        GameManager.instance.isPlayerAlive = true;
        baseGravityScale = myRb.gravityScale;
        myRb.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        if (myRb.velocity.y < 0)
        {
            transform.DORotate(Vector3.forward * -30, 0.5f);
            myRb.gravityScale = fallGravityScale;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.instance.isGameStarted == false)
        {
            UIManager.instance.onGameStart?.Invoke();
            GameManager.instance.isGameStarted = true;
        }
        if (Input.GetMouseButtonDown(0) && GameManager.instance.isGameStarted)
        {
            myRb.gravityScale = baseGravityScale;
            Move();
        }
    }

    public void Move()
    {
        myRb.AddForce(Vector2.up*jumpPower,ForceMode2D.Impulse);
        transform.DORotate(Vector3.forward * 30, 0.5f);
    }

    public void Die()
    {
        if (!UIManager.instance.IsUnityNull())
        {
            GameManager.instance.isGameStarted = false;
            GameManager.instance.isPlayerAlive = false;
            UIManager.instance.onGameEnd?.Invoke();
            transform.DOKill();
            gameObject.SetActive(false);
        }
        
    }

    public void GetScore(int value)
    {
        GameManager.instance.score += value;
        UIManager.instance.onScoreChanged?.Invoke();
        UIManager.instance.onGameEnd?.Invoke();
    }
}
