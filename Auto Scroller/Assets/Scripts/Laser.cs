using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserSpeed = 15f;
    public float laserBaseDamage = 10f;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = transform.right * laserSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
