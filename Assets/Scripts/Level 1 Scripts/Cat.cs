using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Cat : MonoBehaviour,IAnimal
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float climbSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravityScale;
    [SerializeField] private float fallingGravityScale;
    private Rigidbody2D myRb;
    public bool isGrounded = true;
    public bool onLedder = false;
    private Tilemap tile;
    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Collider2D platform))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Collider2D platform))
        {
            isGrounded = false;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Space) & isGrounded)
        {
            Jump();
        }

        if (onLedder && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
        {
            Climb();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(myRb.velocity.y >= 0)
        {
            myRb.gravityScale = gravityScale;
        }
        else if (myRb.velocity.y < 0)
        {
            myRb.gravityScale = fallingGravityScale;
        }
    }

    public void Move()
    {
        myRb.AddForce(Vector2.right * (moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime),ForceMode2D.Force);
    }
    public void Climb()
    {
        myRb.AddForce(Vector2.up * (climbSpeed * Input.GetAxis("Vertical") * Time.deltaTime),ForceMode2D.Force);
    }
    public void Die()
    {
        
        GameManager.instance.isPlayerAlive = false;
        GameManager.instance.catDie?.Invoke();
        Destroy(gameObject);
    }

    public void GetScore(int value)
    {
        GameManager.instance.score += value;
        UIManager.instance.onScoreChanged?.Invoke();
    }

    public void Jump()
    {
        myRb.gravityScale = gravityScale;
        jumpPower = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * myRb.gravityScale * -2) * myRb.mass);
        myRb.AddForce(Vector2.up * ((jumpPower) * Input.GetAxis("Jump")),ForceMode2D.Impulse);
    }

    public void LevelEnd()
    {
        UIManager.instance.onGameEnd?.Invoke();
        PlayerPrefs.SetInt("CurrentLevel",SceneManager.GetActiveScene().buildIndex+1);
    }
}
