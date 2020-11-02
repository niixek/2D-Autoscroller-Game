using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserSpeed = 15f;
    public int laserBaseDamage = 10;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = transform.right * laserSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable")) {
            collision.GetComponent<Break>().health -= laserBaseDamage;
            Destroy(gameObject);
        }
    }
}
