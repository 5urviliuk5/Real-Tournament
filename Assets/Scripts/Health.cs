using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int hp;
    public int maxHp = 100;

    public UnityEvent onDie;
    public UnityEvent onDamage;

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
        onDamage.Invoke();
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        onDie.Invoke();
    }

    void Update()
    {
        
    }
}
