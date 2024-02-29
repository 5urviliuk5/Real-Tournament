using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int ammo;
    public int maxAmmo = 10;
    public int clipAmmo;
    public int clipSize;

    public bool isReloading;
    public bool isAutomatic;
    public float fireInterval = 0.5f;
    public float fireCooldown;
    public float spreadAngle = 5;
    public int bulletsPerShot = 1;

    public UnityEvent onRightClick;
    public UnityEvent onShoot;
    public UnityEvent onReload;

    void Update()
    {
        fireCooldown -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (isReloading) return;
        if (clipAmmo <= 0)
        {
            Reload();
            return;
        }
        if (fireCooldown > 0) return;
        onShoot.Invoke();
        clipAmmo--;
        fireCooldown = fireInterval;

        for (int i = 0; i < bulletsPerShot; i++)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            var offsetX = Random.Range(-spreadAngle, spreadAngle);
            var offsetY = Random.Range(-spreadAngle, spreadAngle);
            bullet.transform.eulerAngles += new Vector3(offsetX, offsetY, 0);
        }
    }

    public async void Reload()
    {
        if (clipAmmo == clipSize) return;
        if (isReloading) return;
        isReloading = true;
        onReload.Invoke();
        await new WaitForSeconds(2f);

        var ammoNeaded = Mathf.Min(clipSize - clipAmmo, ammo);
        ammo -= ammoNeaded;
        clipAmmo += ammoNeaded;

        isReloading = false;
    }
}