using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Weapon weapon;
    public Health health;
    public LayerMask weaponLayer;
    public GameObject grabText;
    public Transform hand;
    public HUD hud;

    void Update()
    {
        var cam = Camera.main.transform;
        var collided = Physics.Raycast(cam.position, cam.forward,out var hit, 2f, weaponLayer);
        grabText.SetActive(collided);
  
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (weapon == null && collided)
            {
                Grab(hit.collider.gameObject);
            }
            else 
            {
                Drop();
            }
        }

        if (weapon == null) return;

        if (!weapon.isAutomatic && Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }

        if (weapon.isAutomatic && Input.GetKey(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && weapon.ammo < weapon.maxAmmo)
        {
            weapon.Reload();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            weapon.onRightClick.Invoke();
        }

        void Grab(GameObject gun)
        {
            if (weapon == null) Drop();

            weapon = gun.GetComponent<Weapon>();
            weapon.GetComponent<Rigidbody>().isKinematic = true;
            weapon.transform.position = hand.position;
            weapon.transform.rotation = hand.rotation;
            weapon.transform.parent = hand;

            hud.UpdateUI();
            hud.weapon = weapon;
            weapon.onShoot.AddListener(hud.UpdateUI);
            weapon.onReload.AddListener(hud.UpdateUI);
        }

        void Drop()
        {
            if (weapon == null) return;

            weapon.GetComponent<Rigidbody>().isKinematic = false;
            weapon.transform.parent = null;
            
            hud.weapon = null;
            weapon.onShoot.RemoveListener(hud.UpdateUI);
            weapon.onReload.RemoveListener(hud.UpdateUI);

            weapon = null;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health.Damage(20);
        }
    }
}
