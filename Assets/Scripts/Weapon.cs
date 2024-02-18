using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int maxAmmo = 10;
    public int ammo;
    public bool isReloading;
    public bool isAutomatic;
    public float fireInterval = 0.1f;
    public float fireCooldown;
    public float reloadTime = 2;

    void Update()
    {
        if (!isAutomatic && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (isAutomatic && Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        fireCooldown -= Time.deltaTime;
    }

    async void Reload()
    {
        if (ammo == maxAmmo) return;
        if (isReloading) return;

        isReloading = true;

        print("Reloading...");
        await new WaitForSeconds(reloadTime);
        print("Reloaded!");

        isReloading = false;
        ammo = maxAmmo;
    }

    void Shoot()
    {
        if (isReloading) return;
        if (ammo <= 0)
        {
            Reload();
            return;
        }
        if (fireCooldown > 0) return;

        ammo--;
        fireCooldown = fireInterval;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}