using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public int health;
    public HealthBar healthBar;
    public int maxHealth;

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        healthBar.SetHealth(health);
    }
}
