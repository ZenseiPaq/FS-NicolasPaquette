using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform firePoint;         
    public float fireRate = 0.5f;      
    public int maxAmmo = 6;             
    public float reloadTime = 2f;       

    private int currentAmmo;
    private float nextFireTime;
    private bool isReloading;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            if (currentAmmo > 0)
            {
                Fire();
                currentAmmo--;
                nextFireTime = Time.time + fireRate;
            }
            else
            {
                StartCoroutine(Reload()); 
            }
        }
    }

    void Fire()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

    System.Collections.IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;

    }
}