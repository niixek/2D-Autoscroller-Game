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

    private void FixedUpdate()
    {
        isFinished = Physics2D.OverlapCircle(flagCheck.position, checkRadius, flag);
        if (isFinished)
        {
            animator.SetBool("IsFinished", true);
            canJump = false;
        }
    }
}
