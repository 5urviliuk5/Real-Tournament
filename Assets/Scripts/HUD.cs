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
        health.onDamage.AddListener(UpdateUI);
    }

    public void UpdateUI()
    {
        if (weapon == null)
        {
            ammoText.text = "-";
            return;
        }
        else
        {
            ammoText.text = weapon.clipAmmo + " / " + weapon.ammo;
        }

        healthText.text = health.hp.ToString();
    }
}
