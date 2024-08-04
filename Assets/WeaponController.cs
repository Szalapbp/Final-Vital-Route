using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    public AudioSource shotgun;
    public GameObject smoke;


    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;

        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        if(shotgun != null)
        {
            shotgun.Play();
        }

        if(smoke != null)
        {
            Instantiate(smoke, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        }
    }
}
