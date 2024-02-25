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

    void Start()
    {
        UpdateUI();
        weapon.onShoot.AddListener(UpdateUI);
        health.onDamage.AddListener(UpdateUI);
    }

    void UpdateUI()
    {
        ammoText.text = weapon.clipAmmo + " / " + weapon.ammo;
        healthText.text = health.hp.ToString();
    }
}
