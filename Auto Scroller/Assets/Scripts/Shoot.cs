using System;
using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject LaserPrefab;

    private float timeUntilFire;
    private bool wait = true;

    private void Start()
    {
        StartCoroutine(WaitCountdown());
    }

    IEnumerator WaitCountdown()
    {
        yield return new WaitForSeconds(3f);
        wait = false;
    }

    private void Update()
    {
        if (!wait && Input.GetKeyDown(KeyCode.S) && timeUntilFire < Time.time)
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
