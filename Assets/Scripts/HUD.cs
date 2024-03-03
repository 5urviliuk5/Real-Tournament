using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] TMP_Text ammoText;
    [SerializeField] TMP_Text healthText;

    public Weapon weapon;
    public Health health;
    public Player player;

    void Start()
    {
        UpdateUI();
        player.onChange.AddListener(CurrWeapon);
        weapon.onShoot.AddListener(UpdateUI);
        health.onDamage.AddListener(UpdateUI);
    }

    void UpdateUI()
    {
        if (weapon == null)
        {
            ammoText.text = "-";
        }
        else
        {
            ammoText.text = weapon.clipAmmo + " / " + weapon.ammo;
        }
        
        healthText.text = health.hp.ToString();
    }

    public void CurrWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
        UpdateUI();
    }

    public void SubscribeWeapon()
    {
        weapon.onShoot.AddListener(UpdateUI);
    }
}
