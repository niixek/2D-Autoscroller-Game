using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Break : MonoBehaviour
{
    public int health;
    public HealthBar healthBar;
    public int maxHealth;
    public GameObject canvas;

    private bool showing = false;

    private void Start()
    {
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
