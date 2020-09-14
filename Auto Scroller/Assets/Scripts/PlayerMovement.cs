using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    //public float jumpForce;
    public float jumpMinSpeed;
    public float jumpMaxSpeed;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public Animator animator;
    public UnityEvent OnLandEvent;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isNotJumping = false;
    private bool isGrounded;

    
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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (isGrounded)
        {
            OnLandEvent.Invoke();
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
        if (Input.GetButtonUp("Jump") && !isGrounded)
        {
            isNotJumping = true;
        }

        Animate();
    }

    private void FixedUpdate()
    {
        moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveDirection * moveSpeed));
        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpMaxSpeed);
            isJumping = false;
            animator.SetBool("IsJumping", true);
        }
        if (isNotJumping)
        {
            if (rb.velocity.y > jumpMinSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpMinSpeed);
                isNotJumping = false;
            }
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
