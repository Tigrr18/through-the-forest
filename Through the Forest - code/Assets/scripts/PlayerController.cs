using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    public Rigidbody2D rb;
    public Collider2D col;
    public Animator anim;
    private SpriteRenderer sprite;

    public bool isGrounded;
    private float horizontalInput = 0f;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource walkSoundEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(col, groundLayer);

        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if ((horizontalInput>0||horizontalInput<0)&&isGrounded){
            walkSoundEffect.enabled = true;
        }else{
            walkSoundEffect.enabled = false;
        }

        UpdateAnimationUpdate();
        FixedUpdate();


        // Check if the player is grounded and the jump button is pressed
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Debug.Log("jump is being used");
            jumpSoundEffect.Play();
            // Apply the jump force
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        anim.SetBool("isJumping", !isGrounded);
    }
    private void FixedUpdate()
    {
        anim.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    private void UpdateAnimationUpdate()
    {
        if (horizontalInput > 0f)
        {
            sprite.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            sprite.flipX = true;
        }
    }
    
}

