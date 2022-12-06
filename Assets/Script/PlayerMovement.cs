using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float speed = 5;
    public float jumpForce = 5;
    public Transform groundCheckTransform;
    public LayerMask groundLayer;
    //public AudioSource jumpSound;
    public Button play;

    public bool isPause = false;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(UnPause);
        pause.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.2f, groundLayer);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //jumpSound.Play();
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
    }
    // 
    // Update is called once per frame
    void FixedUpdate()
    {
        float moveDirection = Input.GetAxis("Horizontal");

        Flip(moveDirection);

        animator.SetFloat("velocity", Math.Abs(moveDirection));
        rb.velocity = (moveDirection * Vector2.right * speed) + new Vector2(0, rb.velocity.y);
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0; //stop le temps

        pause.SetActive(true);
        
        isPause = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1;

        pause.SetActive(false);

        isPause = false;
    }
}