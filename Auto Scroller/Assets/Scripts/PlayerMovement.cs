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
    public FinishLineCheck checkFinish;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumping;
    private float jumpTimeCounter;
    private bool jumpAbility = true;

    
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
        animator.SetFloat("Speed", Mathf.Abs(moveSpeed));
        
        if (jumpAbility)
        {
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
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (isGrounded && isJumping == false)
        {
            OnLandEvent.Invoke();
        }
        if (!checkFinish.canJump)
        {
            jumpAbility = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
