using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Break : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth;
    public GameObject canvas;

    private bool showing = false;
    public int health;

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        canvas.SetActive(false);
    }

    void Update()
    {
        if (!showing && (health < maxHealth))
        {
            canvas.SetActive(true);
            showing = true;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            Destroy(canvas);
        }
        healthBar.SetHealth(health);
    }
}
