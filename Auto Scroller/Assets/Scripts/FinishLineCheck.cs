using System;
using UnityEngine;

public class FinishLineCheck : MonoBehaviour
{
    public Transform flagCheck;
    public float checkRadius;
    public LayerMask flag;
    public Animator animator;
    public bool canJump = true;

    private bool isFinished;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isFinished = Physics2D.OverlapCircle(flagCheck.position, checkRadius, flag);
        if (isFinished)
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetBool("IsFinished", true);
            canJump = false;
        }
    }
}
