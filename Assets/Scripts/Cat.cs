using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour,IAnimal
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    private Rigidbody2D myRb;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Move()
    {
        myRb.AddForce(Vector2.right * (moveSpeed * Input.GetAxis("Horizontal")),ForceMode2D.Force);
    }
    public void Jump()
    {
        myRb.AddForce(Vector2.up * (jumpPower),ForceMode2D.Impulse);
    }
}
