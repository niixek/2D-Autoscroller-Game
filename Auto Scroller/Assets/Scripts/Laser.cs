using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserSpeed = 15f;
    public int laserBaseDamage = 1;
    public Rigidbody2D rb;

    public int finalLaserDamage;

    private void FixedUpdate()
    { 
        rb.velocity = transform.right * laserSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable")) {
            collision.GetComponent<Break>().health -= finalLaserDamage;
            Destroy(gameObject);
        }
    }
}
