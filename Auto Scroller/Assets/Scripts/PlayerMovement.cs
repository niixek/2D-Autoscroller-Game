using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float jumpTime;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public Animator animator;
    public UnityEvent OnLandEvent;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isGrounded;
    private bool isJumping;
    private float jumpTimeCounter;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveDirection * moveSpeed));
        
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButton("Jump"))
        {
            if (jumpTimeCounter > 0 && isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;

            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        Animate();
    }

    private void FixedUpdate()
    {
        moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (isGrounded && isJumping == false)
        {
            OnLandEvent.Invoke();
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
