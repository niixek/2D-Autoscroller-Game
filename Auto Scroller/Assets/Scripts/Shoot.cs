using System;
using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireRate = 1f;
    public Transform firingPoint;
    public Laser laser;

    private float timeUntilFire;
    private bool wait = true;
    private float chargeTimer = 0;

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
        if (!wait && Input.GetKey(KeyCode.S))
        {
            chargeTimer += (5*Time.deltaTime);
            print(chargeTimer);
        }
        if (!wait && Input.GetKeyUp(KeyCode.S) && timeUntilFire < Time.time)
        {
            laser.finalLaserDamage = (int)(chargeTimer) + laser.laserBaseDamage;
            print(laser.finalLaserDamage);
            chargeTimer = 0;
            Shooting();
            timeUntilFire = Time.time + fireRate;
        }
    }

    private void Shooting()
    {
        Instantiate(laser, firingPoint.position, Quaternion.identity);
    }
}
