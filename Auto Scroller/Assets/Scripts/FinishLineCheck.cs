using UnityEngine;

public class FinishLineCheck : MonoBehaviour
{
    public Transform flagCheck;
    public float checkRadius;
    public LayerMask flag;

    private bool isFinished;
    private Rigidbody2D rb;

    private void FixedUpdate()
    {
        isFinished = Physics2D.OverlapCircle(flagCheck.position, checkRadius, flag);
        if (isFinished)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
