using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject LaserPrefab;

    float timeUntilFire;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && timeUntilFire < Time.time)
        {
            Shooting();
            timeUntilFire = Time.time + fireRate;
        }
    }

    private void Shooting()
    {
        Instantiate(LaserPrefab, firingPoint.position, Quaternion.identity);
    }
}
