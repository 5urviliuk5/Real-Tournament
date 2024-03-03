using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int hp;
    public int maxHp = 100;
    public bool shouldDestroy = true;
    public UnityEvent onDie;
    public UnityEvent onDamage;
    public GameObject deathEffect;
    public GameObject damageEffect;

    public AudioClip deathSound;

    void Start()
    {
        if (hp == 0)
        {
            hp = maxHp;
        }
    }

    public void Damage(int damage)
    {
        hp -= damage; 
        if (hp <= 0)
        {
            Die();
        }
        if (hp < 0)hp = 0;

        if (damageEffect != null) Instantiate(damageEffect, transform.position, Quaternion.identity);
        onDamage.Invoke();
    }

    public void Die()
    {
        AudioSystem.Play(deathSound);
        if(shouldDestroy)Destroy(gameObject);
        onDie.Invoke();
        if (deathEffect != null) Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
}
