using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cat : MonoBehaviour,IAnimal
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravityScale;
    private Rigidbody2D myRb;
    private bool isGrounded = true;
    private Tilemap tile;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Collider2D col))
        {
            isGrounded = true;
        }
    }

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Space) & isGrounded)
        {
            Jump();
        }
    }

    public void Move()
    {
        
        myRb.AddForce(Vector2.right * (moveSpeed * Input.GetAxis("Horizontal")),ForceMode2D.Force);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Jump()
    {
        myRb.gravityScale = gravityScale;
        jumpPower = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * myRb.gravityScale * -2) * myRb.mass);
        isGrounded = false;
        myRb.AddForce(Vector2.up * (jumpPower),ForceMode2D.Impulse);
    }
}
